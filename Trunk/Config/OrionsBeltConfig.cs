using Mono.GetOptions;
using System;
using System.Xml;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using System.Collections;
using System.IO.Compression;
using System.Collections.Generic;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Core;
using Loki.Generic;
using Loki.Generic.Formatting;
using System.Reflection;
using System.Web.Security;

[assembly: Mono.UsageComplement("")]
[assembly: Mono.About("Midgard RAD Project :: http://midgard.zi-yu.com")] 
[assembly: Mono.Author("ZI-YU.com")]

[assembly: AssemblyTitle("OrionsBelt.Config application")]
[assembly: AssemblyCopyright("(c) 2006 ZI-YU.com")]
[assembly: AssemblyDescription("Config aplication for the OrionsBelt project")]

namespace OrionsBelt.Config {
	
	public partial class OrionsBeltConfig : Options {
	
		#region Editable
		
		[Option("Does some user test...", "test")]
    	public WhatToDoNext UserTest() {
    		
			WriteInfo();
			Console.WriteLine("Write here some code...");
			
			using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance())
            {
                IList<Principal> list = persistance.Select();
                IEntityFormatter<Principal> formatter = Formatter.GetByFormat<Principal>("Sql");
                formatter.Export(Console.Out, list);

            }
			
            return WhatToDoNext.GoAhead;
    	}
		
		#endregion
	
		#region Database Access
		
		[Option("drops the database structure", "dropdb")]
    	public WhatToDoNext DropDatabase() {
    		WriteInfo();
			Console.WriteLine("Droping database...");
            NHibernateUtilities.DropSchema("DropSchema.sql");
			Console.WriteLine("Done!");
            return WhatToDoNext.GoAhead;
    	}
		
		[Option("creates the database structure", "generatedb","db")]
    	public WhatToDoNext CreateDatabase() {
    		WriteInfo();
			Console.WriteLine("Creating database...");
            NHibernateUtilities.CreateSchema("CreateSchema.sql");
			Console.WriteLine("Done!");
            return WhatToDoNext.GoAhead;
    	}
    	
		[Option("Executes an HQL query", "hql")]
    	public WhatToDoNext Query( string hql ) {
    		WriteInfo();
 
			Console.WriteLine("Executing query `{0}'", hql);
			
            foreach( object obj in NHibernateUtilities.HqlQuery(hql) ) {
				Console.WriteLine(obj);
            }
           
			Console.WriteLine("Done!");
            return WhatToDoNext.GoAhead;
    	}

        [Option("Calls dropdb & generatedb", "reset", "r")]
        public WhatToDoNext ResetDatabase(string config)
        {
            DropDatabase();
            CreateDatabase();
            
			if (string.IsNullOrEmpty(config)) {
                config = "../../DataAccessLayer/Config";
            }
            ImportDatabaseConfig(config);
            
            return WhatToDoNext.GoAhead;
        }
    	
    	#endregion Database Creation
    	
    	#region Database Utilities
    	
    	[Option("Shows the connection string", "conn")]
    	public WhatToDoNext ListConnectionString () {
    		WriteInfo();
    		return WhatToDoNext.GoAhead;
    	}
    	
    	#endregion Database Utilities
		
		#region General
    	
    	[Option("Sets the Debug Log Level", "verbose")]
    	public WhatToDoNext SetDebugLevel () {
			Log.ToDebugLevel();
    		Console.WriteLine("Log level set to: Debug");
    		return WhatToDoNext.GoAhead;
    	}
    	
    	private static System.Threading.Timer timer = null;

        [Option("Sets the max execution time", "timeout")]
        public WhatToDoNext SetTimeout(int seconds)
        {
             Console.WriteLine("Setting the max execution time to: {0} seconds at {1}", seconds, DateTime.Now);

            timer = new System.Threading.Timer(delegate(object state) {
                Console.WriteLine("*** Max execution Time reached at {0}! Shutting down...", DateTime.Now);
                Environment.Exit(1);
            }, null, seconds * 1000, System.Threading.Timeout.Infinite);

            return WhatToDoNext.GoAhead;
        }
    	
    	#endregion Database Utilities
		
		#region Code Cleanning

        [Option("Cleans white spaces", "clean")]
        public WhatToDoNext CleanCode( string path )
        {
            if (!System.IO.Directory.Exists(path)) {
                throw new Exception("'" + path + "' Directory not find");
            }

            string[] files = GetFilesToClean(path);

            foreach (string file in files) {
                string content = System.IO.File.ReadAllText(file, Encoding.UTF8);
                double originalSize = (double) content.Length;

                content = RemoveComments(content);
                content = RemoveSpecificSpaces(content);

                System.IO.File.WriteAllText(file.Replace(".2clean", ""), content, Encoding.UTF8);
                double finalSize = (double)content.Length;

                Console.WriteLine("{0:00.0}% {1}", (finalSize / originalSize ) * 100 , file, content.Length, originalSize);
            }

            return WhatToDoNext.GoAhead;
        }

        private string RemoveSpecificSpaces(string content)
        {
			content = CleanRegex(content, @"\s*\n\s*", " ");
        
            content = CleanOperators(content,"=");
            content = CleanOperators(content, @"\[");
            content = CleanOperators(content, @"\]");
            content = CleanOperators(content, "&");
            content = CleanOperators(content, @"\|");
            content = CleanOperators(content, "<");
            content = CleanOperators(content, ">");
            content = CleanOperators(content, "-");
            content = CleanOperators(content, @"\+");
            content = CleanOperators(content, @"\*");
            content = CleanOperators(content,"/");
            content = CleanOperators(content, @"\(");
            content = CleanOperators(content, @"\)");
            content = CleanOperators(content, @",");
            content = CleanOperators(content, @";");
            content = CleanOperators(content, @":");
            content = CleanOperators(content, @"\{");
            content = CleanOperators(content, @"\}");

            return content;
        }

        private static string CleanOperators(string content, string op)
        {
            content = System.Text.RegularExpressions.Regex.Replace(
                    content,
                    @"\s*" + op + @"\s*", op.Replace(@"\",""),
                    System.Text.RegularExpressions.RegexOptions.Singleline
                 );
            return content;
        }

        private static string CleanRegex(string content, string regex)
        {
            return CleanRegex(content, regex, string.Empty);
        }

        private static string CleanRegex(string content, string regex, string substitute)
        {
            content = System.Text.RegularExpressions.Regex.Replace(
                    content,
                    regex, substitute,
                    System.Text.RegularExpressions.RegexOptions.Singleline
                 );
            return content;
        }

        private string RemoveComments(string content)
        {
			// inline comments
            content = RemoveInlineComments(content);

			// block comments
            content = System.Text.RegularExpressions.Regex.Replace(
                    content, 
                    @"/\*.*?\*/","",
                    System.Text.RegularExpressions.RegexOptions.Singleline
                 );
				 
			// XML comments
			content = System.Text.RegularExpressions.Regex.Replace(
                    content,
                    @"<!--.*?-->", "",
                    System.Text.RegularExpressions.RegexOptions.Singleline
                 );

            return content;
        }
        
        private static string RemoveInlineComments(string content)
        {
            using (TextWriter writer = new StringWriter()) {
                string[] lines = content.Split('\n');
                foreach (string line in lines) {
                    string parsed = System.Text.RegularExpressions.Regex.Replace(
                            line,
                            @"^\s*//.*$", string.Empty
                         );
                    writer.Write(parsed);
                }
                return writer.ToString();
            }
        }

        private string[] GetFilesToClean(string path)
        {
            List<string> list = new List<string>();
            AddFiledToClean(list, path);
            return list.ToArray();
        }

        private void AddFiledToClean(List<string> list, string path)
        {
			list.AddRange(System.IO.Directory.GetFiles(path, "*.html"));
            list.AddRange(System.IO.Directory.GetFiles(path, "*.xml"));
            list.AddRange(System.IO.Directory.GetFiles(path, "*.js"));
            list.AddRange(System.IO.Directory.GetFiles(path, "*.css"));
            list.AddRange(System.IO.Directory.GetFiles(path, "*.aspx"));
            list.AddRange(System.IO.Directory.GetFiles(path, "*.ascx"));
            list.AddRange(System.IO.Directory.GetFiles(path, "*.master"));
            foreach (string son in System.IO.Directory.GetDirectories(path)) {
                AddFiledToClean(list, son);
            }
        }

        #endregion Code Cleanning
        
		#region Code Gziping

        [Option("Gzip script files", "gzip-scripts")]
        public WhatToDoNext GzipFiles(string path)
        {
            if (!System.IO.Directory.Exists(path)) {
                throw new Exception("'" + path + "' Directory not find");
            }

            string[] files = GetFilesToZip(path);

            Console.WriteLine("Gziping script files...");

            foreach (string file in files) {
                GzipFile(file);
                WriteStats(file);
            }
            
            return WhatToDoNext.GoAhead;
        }

        private static void WriteStats(string file)
        {
            int originalSize = File.ReadAllBytes(file).Length;
            int finalSize = File.ReadAllBytes(file+".gz").Length;
            Console.WriteLine("{0:00.0}% {1}", (finalSize / originalSize) * 100, file);
        }

        private static void GzipFile(string file)
        {
            string outputFile = string.Format("{0}.gz", file);

            if (File.Exists(outputFile)) {
                File.Delete(outputFile);
            }

            byte[] buffer = { };

            using (FileStream inFileStream = new FileStream(file, FileMode.Open)) {
                buffer = new byte[inFileStream.Length];
                inFileStream.Read(buffer, 0, buffer.Length);
            }

            using (FileStream outFileStream = new FileStream(outputFile, FileMode.OpenOrCreate)) {
                using (GZipStream compressedStream = new GZipStream(outFileStream, CompressionMode.Compress)) {
                    compressedStream.Write(buffer, 0, buffer.Length);
                }
            }
        }

        private string[] GetFilesToZip(string path)
        {
            List<string> files = new List<string>();
            AddFilesToZip(files, path);
            return files.ToArray();
        }

        private void AddFilesToZip(List<string> files, string path)
        {
            files.AddRange(System.IO.Directory.GetFiles(path, "*.js"));
            files.AddRange(System.IO.Directory.GetFiles(path, "*.css"));
            foreach (string son in System.IO.Directory.GetDirectories(path)) {
                AddFilesToZip(files, son);
            }
        }

        #endregion Code Gziping
        
        #region Xml2aspx

        [Option("Converts .m.xml files to aspx", "xml2aspx")]
        public WhatToDoNext Xml2aspx(string path)
        {
            List<string> files = GetXml2AspxFiles(path);
            string xslt = GetXml2aspxXslt(path);

            Console.WriteLine("Converting .m.xml files to aspx...");
            Console.WriteLine(" - Path: {0}", path);
            Console.WriteLine(" - Xslt: {0}", xslt);
            Console.WriteLine(" - Files found: {0}", files.Count);

            foreach (string file in files) {
                Console.WriteLine(" * {0}", file);
                Templates.Transform(file, xslt, file.Replace(".m.xml",".aspx"));
            }

            return WhatToDoNext.GoAhead;
        }

        private string GetXml2aspxXslt(string path)
        {
            return System.IO.Path.Combine(path,"Xslt/Xml2aspx/Xml2aspx.Main.xslt");
        }

        private List<string> GetXml2AspxFiles(string path)
        {
            List<string> files = new List<string>();
            SetFiles(files, path);
            return files;
        }

        private void SetFiles(List<string> files, string path)
        {
            files.AddRange(System.IO.Directory.GetFiles(path,"*.m.xml"));

            string[] folders = System.IO.Directory.GetDirectories(path);
            foreach (string folder in folders){
                SetFiles(files, folder);
            }
        }

        #endregion Xml2aspx

		#region I18N Independent
		
		public class EntryLang {
            private string lang;

            public string Lang
            {
                get { return lang; }
                set { lang = value; }
            }

            private string localized;

            public string Localized
            {
                get { return localized; }
                set { localized = value; }
            }
        };

        public class Entry {
            private string key;
            public string Key {
                get { return key; }
                set { key = value; }
            }
            private bool client;
            public bool ClientSide{
                get { return client; }
                set { client = value; }
            }
            private string file;
            public string File {
                get { return file; }
                set { file = value; }
            }
            private List<EntryLang> localization = new List<EntryLang>();
            public List<EntryLang> Localization
            {
                get { return localization; }
                set { localization = value; }
            }
        }

        public class EntryList : List<Entry> {
            public bool Cache = true;
            public bool Online = true;
			public Entry Find( string key ) {
                return base.Find(delegate(Entry e) { return e.Key == key; });
            }
        }
		
		[Option("Generates Localization Utilities", "localize")]
        public WhatToDoNext Localize( string path )
        {
            EntryList entries = GetAllEntries(path);

            GenerateResourceClass("../../WebComponents/Localization/Resources.cs", entries);
            GenerateJsonResources("../Localization/Script/", entries);
            GenerateJavascriptResources("../Localization/Script/", entries);
            GeneratePreCompiledLanguage("../Localization/", entries);

            return WhatToDoNext.GoAhead;
        }
        
        private void GeneratePreCompiledLanguage(string path, EntryList entries)
        {
            Dictionary<string, object> args = new Dictionary<string, object>();
            args["namespace"] = string.Format("{0}.WebUserInterface", "OrionsBelt");
            args["webComponents"] = string.Format("{0}.WebComponents", "OrionsBelt");;
            args["date"] = DateTime.Now;
            args["commandLine"] = Environment.CommandLine;
            args["entries"] = entries;
            args["root"] = this;

            string template = "LocalizationTemplate.PreCompiled.vtl";
            string file = Path.Combine(path, "PreCompiledLanguage.cs");

            Templates.Generate(null, template, file, true, args);
            Console.WriteLine("Generated `{0}'", file);
            Console.WriteLine("- Entries: {0}", entries.Count);
            Console.WriteLine();
        }
        
        public string Escape(string arg)
        {
            return arg.Replace("\"", "\" + '\"' + @\"");
        }

        private void GenerateJsonResources(string path, EntryList entries)
        {
            Console.WriteLine("Generating Json files:");
            Dictionary<string, object> args = new Dictionary<string, object>();
            args["date"] = DateTime.Now;
            args["entries"] = entries;

            string template = "LocalizationTemplate.json.vtl";
            Directory.CreateDirectory(path);

            foreach (string lang in GetLanguages()) {
                args["lang"] = lang;
                args["root"] = this;
                string output = Path.Combine(path, string.Format("I18N-{0}.json", lang));
                Templates.Generate(null, template, output, true, args);
                Console.WriteLine("- Generated `{0}'", output);
            }
        }
        
        public string Trim(string str)
        {
            return str.Trim().Replace(Environment.NewLine, string.Empty).Replace("\"", "'");
        }
        
        private void GenerateJavascriptResources(string path, EntryList entries)
        {
            Console.WriteLine("Generating Javascript files:");
            Dictionary<string, object> args = new Dictionary<string, object>();
            args["date"] = DateTime.Now;
            args["entries"] = entries;
            args["root"] = this;

            string template = "LocalizationTemplate.js.vtl";
            Directory.CreateDirectory(path);

            foreach (string lang in GetLanguages()) {
                args["lang"] = lang;
                string output = Path.Combine(path, string.Format("I18N-{0}.js", lang));
                Templates.Generate(null, template, output, true, args);
                Console.WriteLine("- Generated `{0}'", output);
            }
        }
        
        private string[] locales = null;
        
        #region Stats

        [Option("Generates Localization Stats", "lstats")]
        public WhatToDoNext LocalizizationStats( string path )
        {
            EntryList entries = GetAllEntries(path);
            Dictionary<string, EntryList> groupByLanguage = GroupByLanguage(entries);
            double totalEntries = GetTotal(groupByLanguage);

            Console.WriteLine("--");
            Console.WriteLine("Lang\tTokens\tPerc\tWords");
            using(StreamWriter writer = new StreamWriter(Path.Combine(path, "Report.html"))){
                writer.Write("<table class='table'>");
                writer.Write("<tr><th>Flag</th><th>Language</th><th>Tokens</th><th>Complete</th><th>Total Words</th></tr>");
                foreach (KeyValuePair<string, EntryList> pair in groupByLanguage) {
                    double percent = GetPercent(pair.Value.Count, totalEntries);
                    double totalWords = GetTotalWords(pair.Key, pair.Value);
                    Console.WriteLine("{0}\t{1}\t{2:#0.0}%\t{3}", pair.Key, pair.Value.Count, percent, totalWords);
                    writer.Write("<tr>");
                    writer.Write("<td><img src='http://resources.orionsbelt.eu/Images/Common/Flags/{0}.gif' /></td>", pair.Key);
                    writer.Write("<td>{0}</td>", pair.Key);
                    writer.Write("<td>{0}</td>", pair.Value.Count);
                    writer.Write("<td><span style='color:{1};'>{0:#0.00}%</span></td>", percent, GetColor(percent));
                    writer.Write("<td>{0}</td>", totalWords);
                    writer.Write("</tr>");
                }
                writer.Write("</table>");
            }

            foreach (KeyValuePair<string, EntryList> pair in groupByLanguage) {
                if (pair.Value.Count != totalEntries) {
                    Console.WriteLine("--");
                    Console.WriteLine("Checking missing tokens for `{0}'...", pair.Key);
                    foreach (KeyValuePair<string, EntryList> checkPair in groupByLanguage) {
                        CheckMissingTokens(pair, checkPair);
                    }
                }
            }

            Console.WriteLine("--");
            return WhatToDoNext.GoAhead;
        }
        
        private object GetColor(double percent)
        {
            if (percent > 95) {
                return "#3CB371";
            }
            if (percent > 90) {
                return "#2E8B57";
            }

            if (percent > 75) {
                return "#FF7F50";
            }
            if (percent > 40) {
                return "#FFD700";
            }
            if (percent > 20) {
                return "#B22222";
            }
            return "#8B0000";
        }

        private void CheckMissingTokens(KeyValuePair<string, EntryList> pair, KeyValuePair<string, EntryList> checkPair)
        {
            foreach (Entry entry in checkPair.Value) {
                if (!pair.Value.Contains(entry)) {
                    Console.WriteLine(" » Missing {0}:{1} File:{2}", checkPair.Key, entry.Key, entry.File);
                }
            }
        }

        private double GetTotalWords(string language, EntryList entryList)
        {
            double total = 0;

            foreach (Entry entry in entryList) {
                foreach (EntryLang lang in entry.Localization) {
                    if (lang.Lang == language) {
                        total += lang.Localized.Split(new string[] { " ", "\t", Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).Length;
                    }
                }
            }

            return total;
        }

        private double GetPercent(double actual, double totalEntries)
        {
            return actual / totalEntries * 100;
        }

        private double GetTotal(Dictionary<string, EntryList> groupByLanguage)
        {
            double max = int.MinValue;
            foreach (KeyValuePair<string, EntryList> pair in groupByLanguage) {
                if (pair.Value.Count > max) {
                    max = pair.Value.Count;
                }
            }
            return max;
        }

        private Dictionary<string, EntryList> GroupByLanguage(EntryList entries)
        {
            Dictionary<string, EntryList> dic = new Dictionary<string, EntryList>();
            
            if (locales != null) {
                foreach (string locale in locales) {
                    dic.Add(locale, new EntryList());
                }
            }

            foreach (Entry entry in entries) {
                foreach (EntryLang lang in entry.Localization) {
                    if (!dic.ContainsKey(lang.Lang)) {
                        dic.Add(lang.Lang, new EntryList());
                    }
                    dic[lang.Lang].Add(entry);
                }
            }

            return dic;
        }

        #endregion Stats

        [Option("Sets the languages", "locales")]
        public WhatToDoNext SetLanguages(string raw)
        {
            if (string.IsNullOrEmpty(raw)) {
                throw new Exception("Please specify the locales, separated by a comma");
            }

            Console.WriteLine("Setting locales: {0}", raw);
            raw = raw.Trim('\'');
            Console.WriteLine("Setting locales trimmed: {0} - ", raw);
            locales = raw.Split(';');

            foreach (string lang in locales)  {
                Console.Write("{0}, ", lang);
            }

            Console.WriteLine("Done");

            return WhatToDoNext.GoAhead;
        }

        private IEnumerable<string> GetLanguages()
        {
            Console.Write("Getting languages... ");
            if( locales != null ) {
                Console.WriteLine("from params");
                return locales;
            }
            Console.WriteLine("No params, default en");
            return new string[] { "en" };
        }

        private EntryList GetAllEntries(string path)
        {
			if (!System.IO.Directory.Exists(path)) {
                throw new Exception("'"+path+"' Directory not find");
            }
            EntryList entries = new EntryList();
            foreach (string file in GetResourcesFiles(path)) {
                System.IO.FileInfo info = new System.IO.FileInfo(file);
                GetEntryList(file, entries);
                Console.WriteLine("Handled `{0}'", info.Name);
            }
            return entries;
        }

        private void GenerateResourceClass(string file, EntryList entries)
        {
            Dictionary<string, object> args = new Dictionary<string,object>();
            args["namespace"] = string.Format( "{0}.WebComponents", "OrionsBelt");
            args["date"] = DateTime.Now;
            args["commandLine"] = Environment.CommandLine;
            args["entries"] = entries;

            string template = "LocalizationTemplate.cs.vtl";

            Templates.Generate(null, template, file, true, args );
			Console.WriteLine("Generated `{0}'", file);
			Console.WriteLine("- Entries: {0}", entries.Count);
            Console.WriteLine();
        }
        
        private static bool GetOnlineFlag(XmlDocument doc)
        {
            XmlAttribute att = doc.DocumentElement.Attributes["online"];
            if( att == null ) {
                return true;
            }
            return bool.Parse(att.Value);
        }

        private void GetEntryList(string file, EntryList list)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(file);
            list.Cache = bool.Parse(doc.DocumentElement.Attributes["cache"].Value);
            list.Online = GetOnlineFlag(doc);

            foreach (XmlNode elem in doc.DocumentElement) {
                if (elem is XmlComment) {
                    continue;
                }
                Entry entry = new Entry();
                
                entry.File = file;
                entry.Key = elem.Attributes["key"].Value;
                entry.ClientSide = GetClientSide(list.Online, elem);

                foreach (XmlNode son in elem.ChildNodes) {
                    if (son is XmlComment) {
                        continue;
                    }
                    EntryLang lang = new EntryLang();

                    lang.Lang = son.Attributes["key"].Value;
                    lang.Localized = son.InnerXml.Trim().Replace("\t", " ").Replace("     ", " ");
                    
                    if (entry.Localization.Find(delegate(EntryLang e) { return e.Lang == lang.Lang; }) != null) {
                        throw new Exception(string.Format("Entry '{0}' at {1} already has language '{2}'",
                                entry.Key, entry.File, lang.Lang
                            ));
                    }

                    entry.Localization.Add(lang);
                }

                Log.Info("Loaded `{0}'", entry.Key);
				
				Entry found = list.Find(entry.Key);
                if (found != null) {
                    throw new Exception(string.Format("** Detected duplicate `{0}' in file `{1}'", entry.Key, file));
                }
				
                list.Add(entry);
            }
        }

        private bool GetClientSide(bool online, XmlNode elem)
        {
			if (!online) {
                return false;
            }
            bool result = true;
            XmlAttribute att = elem.Attributes["cache"];
            if (att == null) {
                return true;
            }
            if (bool.TryParse(att.Value, out result)) {
                return result;
            }
            return true;
        }

        private IEnumerable<string> GetResourcesFiles(string path)
        {
            string[] files = System.IO.Directory.GetFiles(path,"*.xml");
            foreach( string file in files ) {
                yield return file;
            }

            foreach (string dir in System.IO.Directory.GetDirectories(path)) {
                foreach( string file in System.IO.Directory.GetFiles(dir,"*.xml")) {
                    yield return file;
                }
            }
        }
		
		#endregion I18N Independent
				
		#region Main
		
		public static void Main( string[] args ) {
			DateTime start = DateTime.Now;
			OrionsBeltConfig options = new OrionsBeltConfig();
            if( args.Length == 0 ) {
                args = new string[]{ "--help" };
            }
            options.ProcessArgs( args );
            TimeSpan elapsed = DateTime.Now - start;
            Console.WriteLine("#Elapsed: {0}m", elapsed.TotalMinutes);
		}
		
		#endregion
		
		#region Utilities
		
		private void WriteInfo()
		{
			Console.WriteLine("--- Database Information ----");
			Console.WriteLine("Conn: '{0}'", NHibernateUtilities.ConnectionString);
			Console.WriteLine("-----------------------------");
		}
		
		#endregion Utilities
		
		#region Data Import/Export
		
        [Option("Ganerates a sample DatabasConfig file", "sampledbconfig")]
        public WhatToDoNext SampleDatabaseConfig(string file)
        {
            Console.Write("Generating sample config file... ");
            Importer.GenerateSampleConfig(file);
            Console.WriteLine("Done");

            return WhatToDoNext.GoAhead;
        }

        [Option("Imports data from DatabaseConfig.xml", "import")]
        public WhatToDoNext ImportDatabaseConfig(string baseDir)
        {
            try {
            
				Console.WriteLine("--");
                Console.WriteLine("Importing entities...");
                
                DateTime start = DateTime.Now;
                Importer.Import(baseDir);

                Console.WriteLine("--");
                Console.WriteLine("Import Information:");

                int sum = 0;

                foreach (Importer.EntityStats stats in Importer.Stats.Values) {
                    Console.WriteLine(" - {0} {1}'s in {2}s", stats.EntityCount, stats.EntityName, stats.Duration.TotalSeconds);
                    sum += stats.EntityCount;
                }

                Console.WriteLine("--");
                Console.WriteLine("Elapsed: {0}m", (DateTime.Now-start).TotalMinutes);
                Console.WriteLine("TotalEntities: {0}", sum);
                
            } catch (DALException) {
                return WhatToDoNext.AbandonProgram;
            }

            return WhatToDoNext.GoAhead;
        }
        
        [Option("Exports the repository", "export")]
        public WhatToDoNext ExportDatabase(string baseDir)
        {
            try {
                Exporter.Export(baseDir);
            } catch (DALException) {
                return WhatToDoNext.AbandonProgram;
            }

            return WhatToDoNext.GoAhead;
        }
        
        #endregion Data Import/Export
		
	};

}