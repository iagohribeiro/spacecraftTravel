using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace isarAssignment
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        
        static void readJson (ref JsonData result)
        {
            using (StreamReader r = new StreamReader("C:\\Users\\Iagoh Ribeiro Lima\\Downloads\\DotNetAssignment\\data.json"))
            {
                string json = r.ReadToEnd();
                result = JsonConvert.DeserializeObject<JsonData>(json);
            }

        }
        static void Main()
        {
           /* var result = new JsonData();

            readJson(ref result);

            foreach (Planet item in result.Planet)
            {
                Console.WriteLine(item.Name);
            }

            foreach (Spacecrafts item in result.Spacecrafts)
            {
                Console.WriteLine(item.Name);
            }*/

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new s());

        }
    }
}
