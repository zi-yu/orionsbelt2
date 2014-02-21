using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.Generic;
using Loki.DataRepresentation;
using System.IO;

namespace OrionsBelt.Engine.Actions {

    /// <summary>
    /// Manages actions
    /// </summary>
    public static class ActionManager 
    {
        private static bool alreadyCreated = false;
        #region Action Processing

        private static void ProcessPublicEvents()
        {
            ProcessActions(Visibility.Public);
        }

        public static void ProcessActions(Visibility visibility)
        {
            IList<TimedActionStorage> actionStorageList = ActionUtils.GetActionsToRun(visibility);
            ProcessActions(actionStorageList);
        }

        public static void ProcessActions(IPersistanceSession session, IPlayer player)
        {
            int currentTick = Clock.Instance.Tick;
            int start = player.LastProcessedTick + 1;
            int turnsToProcess = currentTick - player.LastProcessedTick;

            for (int i = 0; i < turnsToProcess; ++i) {
                int tick = start + i;
                player.LastProcessedTick = tick;
                foreach (ITimedAction action in player.Actions) {
                    if (ActionUtils.IsToRun(action, tick)) {
                        action.Process();
                        UpdateAction(session, action,player);
                    }
                }
                player.SyncActions();
            }
        }

        public static void ProcessActions(IList<TimedActionStorage> actionStorageList)
        {
            FileInfo fileToWrite = GetStatsFile();
            using(StreamWriter sw = new StreamWriter(fileToWrite.FullName,true)) {
                
                Console.WriteLine("- Running {0} Actions...", actionStorageList.Count);
                using(ITimedActionStoragePersistance persistance = Persistance.Instance.GetTimedActionStoragePersistance()) {

                    foreach (TimedActionStorage storage in actionStorageList) {
                        try {
                            persistance.StartTransaction();
                            Persistance.ResetSession();
                            ITimedAction action = ActionConversion.ConvertStorageToAction(storage);
                            DateTime start = DateTime.Now;
                            action.Process();
                            TimeSpan total = DateTime.Now - start;
                            UpdateAction(persistance, action, null);
                            Console.WriteLine(" » {0} spent {1} ms", action.Name, total.TotalMilliseconds);
                            sw.WriteLine("{0},{1},{2}", DateTime.Now, action.Name, total.TotalMilliseconds.ToString().Replace(',', '.'));
                            Console.Write("\tFlushing... ");
                            persistance.CommitTransaction();
                            Console.WriteLine("Done");
                        } catch (Exception e) {
                            Console.WriteLine(e.ToString());
                            persistance.RollbackTransaction();
                        }
                    }
                    LogStats(sw, persistance);
                }
				sw.Close();
            }

        }

        private static FileInfo GetStatsFile()
        {
            string dirBin = AppDomain.CurrentDomain.BaseDirectory;
            DirectoryInfo info = new DirectoryInfo(dirBin).Parent;
            lock (dirBin)
            {
                if (!alreadyCreated)
                {
                    alreadyCreated = true;
                    info = CreateFolderStructure(info);
                }
                else
                {
                    info = new DirectoryInfo(string.Format("{0}/Jobs/Stats", info.FullName));
                }
            }

            FileInfo fileToWrite = info.GetFiles("TickStats.csv")[0];
            return fileToWrite;
        }

        private static void LogStats(StreamWriter sw, ITimedActionStoragePersistance persistance)
        {
            using (ISectorStoragePersistance persistance2 = Persistance.Instance.GetSectorStoragePersistance(persistance))
            {
                long count = persistance2.ExecuteScalar("select count(e.Id) from SpecializedSectorStorage e where e.IsMoving=1");
                long total = persistance2.ExecuteScalar("select count(e.Id) from SpecializedSectorStorage e where e.Type='FleetSector'");
                sw.WriteLine("Number of moving fleet:,{0},In a total of:,{1}", count, total);
            }
        }

        private static DirectoryInfo CreateFolderStructure(DirectoryInfo info)
        {
            string folder = string.Format("{0}/Jobs", info.FullName);
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            folder = string.Format("{0}/Stats", folder);
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            info = new DirectoryInfo(folder);
            FileInfo[] file = info.GetFiles("TickStats.csv");

            if (0 == file.Length)
            {
                FileStream fs = File.Create(string.Format("{0}/TickStats.csv", info));
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine("Date,Action,Time Taken");
                sw.Close();
                fs.Close();
            }
            return info;
        }

        private static void UpdateAction(ITimedAction action)
        {
            using (ITimedActionStoragePersistance persistance = Persistance.Instance.GetTimedActionStoragePersistance()) {
                UpdateAction(persistance, action, null);
            }
        }

        private static void UpdateAction(IPersistanceSession session, ITimedAction action, IActionOwner owner)
        {
            using(ITimedActionStoragePersistance persistance = Persistance.Instance.GetTimedActionStoragePersistance(session)){
                if (action.Ended){
                    if (action.IsPersistable) {
                        ActionUtils.DeleteAction(persistance, action.Storage.Id);
                    }
                    if (owner != null) {
                        owner.RemoveAction(action);
                    }
                } else {
                    if (action.IsPersistable){
                        ActionConversion.SetStorage(action.Storage, action);
                        ActionUtils.PersistAction(persistance, action.Storage);
                    }
                }
            }
        }

        #endregion Action Processing

    };
}
