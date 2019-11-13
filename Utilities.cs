using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace BibliotecaBase
{
    public abstract class Utilities
    {
        /// <summary>
        /// Metodo que executa um arquivo bat
        /// </summary>
        /// <example>
        /// <code>
        /// BibliotecaBase.ExecuteBatFileWin(@"c/data/", @"/teste.bat", "prod");
        /// </code>
        /// </example>
        /// <returns>void</returns>
        public static void ExecuteBatFileWin(string batDir, string filemane, string args = "")
        {
            Process proc = null;
            try
            {
                string targetDir = string.Format(batDir);   //this is where mybatch.bat lies
                proc = new Process();
                proc.StartInfo.WorkingDirectory = targetDir;
                proc.StartInfo.FileName = filemane;
                proc.StartInfo.Arguments = args;  //this is argument
                proc.StartInfo.CreateNoWindow = false;
                proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;  //this is for hiding the cmd window...so execution will happen in back ground.
                proc.Start();
                proc.WaitForExit();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Occurred :{0},{1}", ex.Message, ex.StackTrace.ToString());
            }
        }

        /// <summary>
        /// Metodo que executa a leitura de um arquivo csv
        /// </summary>
        /// <example>
        /// <code>
        /// BibliotecaBase.ReadCsv(@"c/data/", ",");
        /// </code>
        /// </example>
        /// <returns>List<T>s>
        /// <returns></summary>
        public static async Task<List<T>> ReadCsvAsync<T>(string pathFile, string separador = ",") where T : class
        {
            List<T> ListTraffic = new List<T>();

            try
            {
                using (TextReader reader = File.OpenText(pathFile))
                {
                    CsvReader csv = new CsvReader(reader);
                    csv.Configuration.Delimiter = separador;
                    csv.Configuration.MissingFieldFound = null;
                    while (await csv.ReadAsync())
                    {
                        T Record = csv.GetRecord<T>();
                        ListTraffic.Add(Record);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return ListTraffic;
        }

        /// <summary>
        /// Metodo que grava um arquivo csv
        /// </summary>
        /// <example>
        /// <code>
        /// BibliotecaBase.WriteCsv(objs, @"c/data/saida.csv", false ",");
        /// </code>
        /// </example>
        /// <returns>void</returns>
        public static void WriteCsv<T>(List<T> objs, string filePath, string delimiter = ",", bool manterDadosAnteriores = true) where T : class
        {
            try
            {
                using (MemoryStream stream = new MemoryStream())
                using (StreamWriter writer = new StreamWriter(filePath, manterDadosAnteriores))
                {
                    CsvWriter csv = new CsvWriter(writer, new Configuration { HasHeaderRecord = !manterDadosAnteriores });
                    csv.Configuration.Delimiter = delimiter;
                    csv.WriteRecords(objs);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}