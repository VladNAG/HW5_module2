using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HW5_module2
{
    public static class FileService
    {
        private static readonly string _filePas;
        static FileService()
        {
            _filePas = CreateFile();
        }

        public static void WriteToFile(string log)
        {
            File.AppendAllText(_filePas, log);
        }

        private static string CreateFile()
        {
            var configFile = File.ReadAllText("FileSetingServise.json");
            var config = JsonConvert.DeserializeObject<FileServiseSetings>(configFile);
            if (!Directory.Exists(config.Dirictoryneme))
            {
                Directory.CreateDirectory(config.Dirictoryneme);
            }

            string fileneme = $"{config.Dirictoryneme}\\{DateTime.Now.ToString("hh.mm.ss dd.MM.yyyy")}.txt";
            string[] files = Directory.GetFiles("LogFiles");

            if (files.Length >= 3)
            {
                DeleteFile();
            }

            using (FileStream fs = File.Create(fileneme))
            {
            }

            return fileneme;
        }

        private static void DeleteFile()
        {
            string folderPath = "LogFiles";
            DirectoryInfo directoryInfo = new DirectoryInfo(folderPath);
            FileInfo[] files = directoryInfo.GetFiles();
            FileInfo oldestFile = files[0];
            foreach (FileInfo file in files)
            {
                if (file.LastWriteTime < oldestFile.LastWriteTime)
                {
                    oldestFile = file;
                }
            }

            oldestFile.Delete();
        }
    }
}
