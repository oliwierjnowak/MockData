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
            var path =
                @"/Users/philippschaffer/projects/dbi-mockdata/MockData/CSV/test.csv"; // Habeeb, "Dubai Media City, Dubai"
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

        public String readRevier()
        {
            var path =
                @"/Users/philippschaffer/projects/dbi-mockdata/MockData/CSV/test.csv";
            ArrayList arrayList = new ArrayList();
            using (TextFieldParser csvParser = new TextFieldParser(path))
            {
                //csvParser.CommentTokens = new string[] { "#" };
                csvParser.SetDelimiters(new string[] { ";" });
                csvParser.HasFieldsEnclosedInQuotes = true;
                string str = "";

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
                    str += "Insert into r_revier( r_id, r_ab_id, r_ersteller, r_s_id, r_name, r_adresse) VALUES (" +
                           fields[0] + ", " + 69 + ", " + 420 + ", " + 666 + ", " + fields[5] + ", addresse)\n";
                    //Insert into r_revier( r_id, r_ab_id, r_ersteller, r_s_id, r_name, r_adresse) VALUES (1 , 1, 1,1, 'Fish and go', '1010 Wienn, spengergasse'); 
                }

                return str;
            }
        }

        public string ReadAusuebungsberechtigte()
        {
            var path =
                @"/Users/philippschaffer/projects/dbi-mockdata/MockData/CSV/test.csv";
            string str = "";
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

                    str += "Insert into ab_ausuebungsberechtigte( ab_id, ab_name, ab_datum) VALUES (" + fields[0] +
                           ", " + fields[11] + ", " + fields[12] + ")\n";
                }
                //Insert into r_revier( r_id, r_ab_id, r_ersteller, r_s_id, r_name, r_adresse) VALUES (1 , 1, 1,1, 'Fish and go', '1010 Wienn, spengergasse'); 
            }

            return str;
        }

        public string ReadBezirk()
        {
            string str = "";
            for (int i = 1; i < 11; i++)
            {
                str += "Insert into b_bezirk( b_id, b_name) VALUES (" + i + ", "+"Wolfsberg" +")\n";
            }

            return str;
        }

        public string ReadGewaesser()
        {
            var path =
                @"/Users/philippschaffer/projects/dbi-mockdata/MockData/CSV/test.csv";
            string str = "";
            using (TextFieldParser csvParser = new TextFieldParser(path))
            {
                csvParser.SetDelimiters(new string[] { ";" });
                csvParser.HasFieldsEnclosedInQuotes = true;


                csvParser.ReadLine();
                while (!csvParser.EndOfData)
                {
                    string[] fields = csvParser.ReadFields();

                    str += "Insert into g_gewaesser(g_id, g_name, g_bezirk_b_id,g_typ) VALUES (" + fields[0] + ", " +
                           fields[5] + ", " + 10 + fields[6] + ")\n";
                }
            }

            return str;
        }
    }
}
   

