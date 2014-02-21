using Mono.GetOptions;
using System;
using System.Xml;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using System.Collections;
using System.Collections.Generic;
using Language.DataAccessLayer;
using Language.Core;
using Loki.Generic;
using Loki.Generic.Formatting;
using System.Reflection;
using System.Web.Security;
using Loki.DataRepresentation;

namespace Language.Config {
	
	public partial class LanguageConfig {

        #region Build Databse

        private string languageProjectName;
        [Option("Specifies the language project", "lang-project")]
        public WhatToDoNext ImportLanguageXmlProject(string project)
        {
            languageProjectName = project;
            return WhatToDoNext.GoAhead;
        }

        private EntryList allentries;
        [Option("Build the Language database with the XML files", "import-lang-xml")]
        public WhatToDoNext ImportLanguageXml(string path)
        {
            if (string.IsNullOrEmpty(languageProjectName)) {
                throw new Exception("No project set, use --lang-project:NAME");
            }

            allentries = GetAllEntries(path);

            using(IPersistanceSession session = Persistance.Instance.GetGenericPersistance()) {
                session.StartTransaction();
                foreach (Entry entry in allentries) {
                    AddEntryDoDatabase(entry, session);
                }
                session.CommitTransaction();
            }

            return WhatToDoNext.GoAhead;
        }

        private void AddEntryDoDatabase(Entry entry, IPersistanceSession session)
        {
            string file = GetEntryFileName(entry);

            using (ILanguageEntryPersistance persistance = Persistance.Instance.GetLanguageEntryPersistance(session)) {
                Console.WriteLine("Getting token '{0}'...", entry.Key);
                LanguageEntry langEntry = GetLanguageEntry(entry, persistance);
                AddEntryLanguages(entry, langEntry, persistance);
            }
        }

        private void AddEntryLanguages(Entry entry, LanguageEntry langEntry, IPersistanceSession session)
        {
            using(ILanguageTranslationPersistance persistance = Persistance.Instance.GetLanguageTranslationPersistance(session)){
                foreach (EntryLang curr in entry.Localization) {
                    LanguageTranslation trans = GetLanguageTranslation(curr, langEntry, session);
                    if (IsToUpdateLanguageTranslation(curr, trans)) {
                        persistance.Update(trans);
                    }
                }
            }
        }

        private static bool IsToUpdateLanguageTranslation(EntryLang curr, LanguageTranslation trans)
        {
            if (trans.Text == curr.Localized) {
                Console.WriteLine("\tSync ({0})", curr.Lang);
                return false;
            }

            if (string.IsNullOrEmpty(trans.Text)) {
                // no trnaslation, update
                Console.WriteLine("\tUpdated DB ({0})", curr.Lang);
                trans.Text = curr.Localized;
                return true;
            }

            Console.WriteLine("\tEntry date: ({0}) is last 24h? {1}", trans.LanguageEntry.UpdatedDate, (trans.LanguageEntry.UpdatedDate > DateTime.Now.AddHours(-24)));
            if (trans.LanguageEntry.UpdatedDate > DateTime.Now.AddHours(-24)) {
                Console.WriteLine("\tKept DB ({0})", curr.Lang);
                // leave the one at the database
                return false;
            }

            Console.WriteLine("\tUpdated DB ({0})", curr.Lang);
            trans.Text = curr.Localized;
            return true;
        }

        private LanguageTranslation GetLanguageTranslation(EntryLang lang, LanguageEntry langEntry, IPersistanceSession session)
        {
            foreach (LanguageTranslation trans in langEntry.Translations) {
                if (trans.Locale == lang.Lang) {
                    return trans;
                }
            }
            using (ILanguageTranslationPersistance persistance = Persistance.Instance.GetLanguageTranslationPersistance(session)) {
                LanguageTranslation newTrans = persistance.Create();
                newTrans.LanguageEntry = langEntry;
                newTrans.Locale = lang.Lang;
                return newTrans;
            }
        }

        private LanguageEntry GetLanguageEntry(Entry entry, ILanguageEntryPersistance persistance)
        {
            IList<LanguageEntry> foundEntries = persistance.TypedQuery("select e from SpecializedLanguageEntry e left join fetch e.TranslationsNHibernate loc where e.Name = '{0}' and e.LanguageFileNHibernate.ProjectNHibernate.Name = '{1}'", entry.Key, languageProjectName);
            if (foundEntries != null && foundEntries.Count > 0) {
                return foundEntries[0];
            }
            LanguageEntry langEntry = persistance.Create();
            langEntry.Name = entry.Key;
            langEntry.LanguageFile = GetLanguageFile(entry, persistance);
            persistance.Update(langEntry);
            return langEntry;
        }

        private static List<LanguageFile> files = null;
        private LanguageFile GetLanguageFile(Entry entry, IPersistanceSession session)
        {
            string name = GetEntryFileName(entry);
            using (ILanguageFilePersistance persistance = Persistance.Instance.GetLanguageFilePersistance(session)) {
                if (files == null) {
                    files = (List<LanguageFile>)persistance.TypedQuery("select file from SpecializedLanguageFile file where file.ProjectNHibernate.Name = '{0}'", languageProjectName);
                }

                foreach (LanguageFile f in files) {
                    if (f.Name == name ) {
                        return f;
                    }
                }

                LanguageFile file = persistance.Create();
                file.Name = name;
                file.Online = false;
                file.Project = GetLanguageProject(persistance);
                persistance.Update(file);
                files.Add(file);
                return file;
            }
        }

        private LanguageProject currProject;
        private LanguageProject GetLanguageProject(IPersistanceSession session)
        {
            if (currProject != null) {
                return currProject;
            }

            using (ILanguageProjectPersistance persistance = Persistance.Instance.GetLanguageProjectPersistance(session)) {
                IList<LanguageProject> projects = persistance.TypedQuery("select p from SpecializedLanguageProject p where p.Name = '{0}'", languageProjectName);
                if (projects != null && projects.Count > 0) { 
                    currProject = projects[0];
                    return currProject;
                }

                currProject = persistance.Create();
                currProject.Name = languageProjectName;

                persistance.Update(currProject);
                return currProject;
            }
        }
        
        private string GetEntryFileName(Entry entry)
        {
            FileInfo info = new FileInfo(entry.File);
            string fileName = info.Name;
            string topDir = info.Directory.Name;

            return string.Format("{0}/{1}", topDir, fileName);
        }

        #endregion Build Databse

        #region Export to XML

        [Option("Specifies the language project", "export-lang-xml")]
        public WhatToDoNext ExportLanguageXml(string output)
        {
            Console.WriteLine("Output: {0}", output);
            if (!Directory.Exists(output)) {
                throw new Exception("Directory not found");
            }

            foreach (LanguageProject project in Hql.Unify<LanguageProject>(Hql.Query<LanguageProject>("from SpecializedLanguageProject p inner join fetch p.FilesNHibernate file"))) {
                Console.WriteLine("Writing project {0}...", project.Name);
                WriteProject(project, output);
            }

            return WhatToDoNext.GoAhead;
        }

        private void WriteProject(LanguageProject project, string output)
        {
            string projectDir = Path.Combine(output, project.Name);
            Directory.CreateDirectory(projectDir);
            
            foreach (LanguageFile file in project.Files) {
                Console.WriteLine(" - Writing file {0}...", file.Name);
                string outputFile = Path.Combine(projectDir, file.Name);
                Directory.CreateDirectory(new FileInfo(outputFile).DirectoryName);
                
                using (StreamWriter writer = new StreamWriter(outputFile, false, Encoding.UTF8)) {
                    writer.WriteLine("<?xml version=\"1.0\" ?>");
                    writer.WriteLine("<resources cache=\"true\" online=\"{0}\">", file.Online.ToString().ToLower());
                    writer.WriteLine();
                    foreach (LanguageEntry entry in Hql.Unify<LanguageEntry>(Hql.Query<LanguageEntry>("select e from SpecializedLanguageEntry e inner join fetch e.TranslationsNHibernate trans where e.LanguageFileNHibernate.Id = :fileId order by e.Name asc, trans.Locale asc", Hql.Param("fileId", file.Id)))) {
                        WriteEntry(writer, entry);
                    }
                    writer.WriteLine("</resources>");
                }
            }
        }

        private void WriteEntry(StreamWriter writer, LanguageEntry entry)
        {
            writer.WriteLine("\t<entry key=\"{0}\">", entry.Name);
            foreach (LanguageTranslation trans in entry.Translations) {
                writer.WriteLine("\t\t<lang key=\"{0}\">{1}</lang>", trans.Locale, trans.Text);
            }
            writer.WriteLine("\t</entry>");
            writer.WriteLine();
        }

        #endregion Export to XML

    };

}