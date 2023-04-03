using System.Collections;
using Microsoft.VisualBasic.FileIO;
using MockData.Model;

namespace MockData.Reader
{

    public class Reader
    {
        public Reader()
        {
            OliRead();
        }

        public String read()
        {
            string path = Path.Combine(Environment.CurrentDirectory, @"CSV/test.csv"); // Habeeb, "Dubai Media City, Dubai"
            using (TextFieldParser csvParser = new TextFieldParser(path))
            {
                //csvParser.CommentTokens = new string[] { "#" };
                csvParser.SetDelimiters(new string[] { ";" });
                csvParser.HasFieldsEnclosedInQuotes = true;

                // Skip the row with the column names
                csvParser.ReadLine();
                string str = "";
                int i = 0;
                while (!csvParser.EndOfData)
                {
                    // Read current line fields, pointer moves to the next line.
                    string[] fields = csvParser.ReadFields();
                    str += fields[0] + " ,aufseher_id" + ", ersteller_id" + "s_id, " + fields[5] + ", adresse";
                    //Insert into r_revier( r_id, r_ab_id, r_ersteller, r_s_id, r_name, r_adresse) VALUES (1 , 1, 1,1, 'Fish and go', '1010 Wienn, spengergasse'); 
                    i++;
                }

                return str;
            }
        }

        public record CSVRecord
        {
            public string? REVIER_ID { get; set; }
            public string? BKZ { get; set; }
            public string? BEZIRK_NAME { get; set; }
            public string? BEZIRK_KFZ { get; set; }
            public string? REVIER_NR { get; set; }
            public string? REVIER_NAME { get; set; }
            public string? TYP { get; set; }
            public string? BESCHREIBUNG { get; set; }
            public string? ANMERKUNG { get; set; }
            public string? BERECHTIGTER { get; set; }
            public string? AUSUEBUNGSBERECHTIGTE { get; set; }
            public string? AUFSICHTSORGANE { get; set; }
            public string? DATUM { get; set; }


        }
        public record CSVRecord2
        {
            public string? BEZIRK_NAME { get; set; }
            public string? REVIER_NAME { get; set; }
            public string? TYP { get; set; }
            public string? AUSUEBUNGSBERECHTIGTE { get; set; }
            public string? AUFSICHTSORGANE { get; set; }



        }
        public IEnumerable<CSVRecord2> OliRead()
        {
            string path = Path.Combine(Environment.CurrentDirectory, @"CSV/test.csv");

           var x1 =  System.IO.File.ReadAllText(path);
            var objects = x1.Split("206 ");
            var x = new List<CSVRecord2>();
            foreach (string line in objects)
            {
                string[] columns = line.Split(';');

                x.Add(new CSVRecord2
                {
                    BEZIRK_NAME = columns[2],
                    REVIER_NAME = columns[5],
                    TYP = columns[6],
                    AUSUEBUNGSBERECHTIGTE = columns[columns.Length - 2],
                    AUFSICHTSORGANE = columns[columns.Length -3]
                });
                


            }
            return x;
        }

        public ArrayList readRevier()
            {

            string path = Path.Combine(Environment.CurrentDirectory,@"CSV/test.csv");
                ArrayList arrayList = new ArrayList();
                using (TextFieldParser csvParser = new TextFieldParser(path))
                {
                    //csvParser.CommentTokens = new string[] { "#" };
                    csvParser.SetDelimiters(new string[] { ";" });
                    csvParser.HasFieldsEnclosedInQuotes = true;

                    // Skip the row with the column names
                    csvParser.ReadLine();
                    while (!csvParser.EndOfData)
                    {
                        // Read current line fields, pointer moves to the next line.
                        string[] fields = csvParser.ReadFields();
                        var obj = new
                        {
                            r_id = fields[0],
                            r_ab_id = 69,
                            r_ersteller = 420,
                            r_s_id = 666,
                            r_name = fields[5],
                            r_adresse = "adresse"
                        };
                        arrayList.Add(obj);
                        //Insert into r_revier( r_id, r_ab_id, r_ersteller, r_s_id, r_name, r_adresse) VALUES (1 , 1, 1,1, 'Fish and go', '1010 Wienn, spengergasse'); 
                    }

                    return arrayList;
                }
            }
        }
    }

