# Sepperin. Distributed consensus protocol based on .Net platform

Quick start

       using Raft;

       static IWarningLog log = null;

       public class Logger : IWarningLog
       {
           public void Log(WarningLogEntry logEntry)
           {
               Console.WriteLine(logEntry.ToString());
           }
       }


       log = new Logger();
 
        TcpRaftNode rn1 = TcpRaftNode.GetFromConfig(System.IO.File.ReadAllText("pathToConfigJSON"),
               "pathToDBreezeFolder e.g. D:\Temp\DBreeze\Node1", 4250, log,
               (entityName, index, data) => { Console.WriteLine($"Committed {entityName}/{index}"); return true; });

       TcpRaftNode rn2 = TcpRaftNode.GetFromConfig(System.IO.File.ReadAllText("pathToConfigJSON"),
               "pathToDBreezeFolder e.g. D:\Temp\DBreeze\Node2", 4251, log,
               (entityName, index, data) => { Console.WriteLine($"Committed {entityName}/{index}"); return true; });

       TcpRaftNode rn3 = TcpRaftNode.GetFromConfig(System.IO.File.ReadAllText("pathToConfigJSON"),
               "pathToDBreezeFolder e.g. D:\Temp\DBreeze\Node3", 4252, log,
               (entityName, index, data) => { Console.WriteLine($"Committed {entityName}/{index}"); return true; });

       rn1.Start();
       rn2.Start();
       rn3.Start();
       
       
       
       rn1.AddLogEntry(new byte[] { 23 })
       rn2.AddLogEntry(new byte[] { 27 })
       rn3.AddLogEntry(new byte[] { 29 })

       await rn1.AddLogEntryAsync(new byte[] { 27 }, entityName: "inMemory2");
