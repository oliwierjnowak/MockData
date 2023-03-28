using System.Collections;
using Microsoft.VisualBasic.FileIO;
using MockData.Model;

namespace MockData.Reader
{

    public class Reader
    {
        public Reader()
        {
            read();
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

