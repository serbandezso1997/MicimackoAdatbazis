using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.IO;

namespace MicimackoAdatbazis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> utasitasokLista = new List<string>();
            List<string> lekerdezett = new List<string>();
            SQLiteConnection kapcsolat = new SQLiteConnection("Data Source=Micimacko.db");
            kapcsolat.Open();
            //Adatok();
            utasitasokLista=SqlUtasitasok();
            SQLiteCommand parancs = new SQLiteCommand(kapcsolat);
            for (int i = 0; i < utasitasokLista.Count; i++) 
            {
                parancs.CommandText = utasitasokLista[i];
                parancs.ExecuteNonQuery();
                
            }

            string lekerdez = "SELECT * FROM `Szereplok`;";
            parancs.CommandText = lekerdez;
            SQLiteDataReader sQLiteDataReader = parancs.ExecuteReader();
            int index = 0;
            while (sQLiteDataReader.Read()) 
            {
                // lekerdezett.Add(sQLiteDataReader.GetString(index));
                if (index >= sQLiteDataReader.FieldCount) 
                {
                    break;
                }
                lekerdezett.Add(sQLiteDataReader.GetValue(index++).ToString());
                //index++;
            }
            kapcsolat.Close();
            Console.WriteLine("A kinyert adatok:");
            foreach (string s in lekerdezett)
            {
                Console.WriteLine(s);
            }

        }

        //adatok legenerálása
        static void Adatok()
        {
            
            //a mese szereplői (9fő)
            string[] szereplok = new string[] { 
                "Micimackó",
                "Malacka",
                "Füles",
                "Nyuszi",
                "Róbert Gida",
                "Kanga",
                "Zsebibaba",
                "Bagoly",
                "Tigris"
            };

            //gyümölcsök
            string[] gyum = new string[] {
                "Alma",
                "Körte",
                "Szőlő",
                "Eper",
                "Kivi",
                "Cseresznye",
                "Meggy",
                "Szilva",
                "Áfonya"
            };

            Random rnd = new Random();
           
            int sor = 0;
            //előfordulások megszámlálása
            int midb = 0;
            int madb = 0;
            int fudb = 0;
            int nyudb = 0;
            int rgdb = 0;
            int kadb = 0;
            int zsedb = 0;
            int bagdb = 0;
            int tigdb = 0;


            while (midb == 0 || madb == 0 || fudb == 0 || nyudb == 0 || rgdb == 0 || kadb == 0 ||
                  zsedb == 0 || bagdb == 0 || tigdb == 0)
            {
                int vel1 = rnd.Next(0,szereplok.Length);//szereplők véletlen száma
                int vel2 = rnd.Next(0, gyum.Length);//Gyümölcsök véletlen száma
                if (vel1 == 0) midb++;
                else if (vel1 == 1) madb++;
                else if (vel1 == 2) fudb++;
                else if (vel1 == 3) nyudb++;
                else if (vel1 == 4) rgdb++;
                else if (vel1 == 5) kadb++;
                else if (vel1 == 6) zsedb++;
                else if (vel1 == 7) bagdb++;
                else if (vel1 == 8) tigdb++;
                Console.WriteLine($"{sor + 1}. {szereplok[vel1]} szereti:{gyum[vel2]}");
                sor++;
            }
        }

        //Külső fájlból olvasás
        static List<string> SqlUtasitasok()
        {
            StreamReader olvas = new StreamReader(@"d:\Program Files (x86)\Programozas\suli_programozas\c#\gyakorlas\MicimackoAdatbazis\MicimackoAdatbazis\utasitasok.sql",Encoding.Default);
            //String[] sqlUtasitasok = new string[15];
            List<string> sqlUtasitasok = new List<string>();
            //sorok beolvasása
            while ( !olvas.EndOfStream )
            {
                //  string sor = olvas.ReadLine().Split(':').ToString();
                string[] sor = olvas.ReadToEnd().Split(':');
                //Console.WriteLine(sor.ToString());
                for ( int i = 0; i < sor.Length; i++)
                {
                    sqlUtasitasok.Add(sor[i]);
                }
                //sqlUtasitasok.Add(sor);
            }
            olvas.Close();
            return sqlUtasitasok;

        }



    }
}
