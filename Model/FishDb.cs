using MockData.Helpers;
using System.Collections;
using System.Reflection;
using System.Linq;
using Newtonsoft.Json;
using RestSharp;

namespace MockData.Model
{
    public class FishDb
    {
        public readonly static string insertstatement = "Insert into ";
        #region tables
        public readonly string gewaesser_table = "test.g_gewaesser";
        public readonly string fishart_table = "test.fa_fischart";
        public readonly string fish_table = "test.f_fisch";
        public readonly string bezrik_table = "test.b_bezirk";
        public readonly string ausuebungsberechtigte_table = "test.ab_ausuebungsberechtigte";
        public readonly string aufsichtsorgane_table = "test.ao_aufsichtsorgane";
        public readonly string revier_table = "test.r_revier";
        public readonly string users_table = "test.u_users";
        public readonly string bewertung_table = "test.b_bewertung";
        public readonly string rating_table = "test.r_rating";
        public readonly string revier_values_table = "test.rv_revier_values";
        public readonly string revier_attributes_table = "test.ra_revier_attributes";
        public readonly string verkauf_table = "test.v_verkauf";
        public readonly string karte_table = "test.k_karte";
        #endregion

        #region records
        public record AufsichtsOrganeRecord
        {
            public int ao_u_id { get; set; }
            public int ao_r_id { get; set; }

        }
        public string AufsichtsOrganeInsert(AufsichtsOrganeRecord value)
        {
            return insertstatement + aufsichtsorgane_table+
                $"( {value.GetType().GetProperties()[0].Name}, {value.GetType().GetProperties()[1].Name}) " +
                $"VALUES ({value.ao_u_id} , {value.ao_r_id}); \n";
        }

        public record FischRecord
        {
            public int f_id { get; set; }
            public string? f_name { get; set; }

        }
        public string FischInsert(FischRecord value)
        {
            return insertstatement+ fish_table +  
                $"( {value.GetType().GetProperties()[0].Name}, {value.GetType().GetProperties()[1].Name}) " +
                $"VALUES ({value.f_id} , '{value.f_name}'); \n";
        }
        public record GewaesserRecord
        {
            public int g_id { get; set; }
            public int g_b_id { get; set; }
            public string? g_name { get; set; }
            public string? g_typ { get; set; }
        }
        public string GewaesserInsert(GewaesserRecord value)
        {
            return insertstatement + gewaesser_table +
                $"( {value.GetType().GetProperties()[0].Name}, {value.GetType().GetProperties()[1].Name}," +
                $"{value.GetType().GetProperties()[2].Name},{value.GetType().GetProperties()[3].Name} ) " +
                $"VALUES ({value.g_id} , {value.g_b_id}, '{value.g_name}','{value.g_typ}'); \n";
        }
        public record FishArtRecord
        {
            public int fa_s_id { get; set; }
            public int fa_f_id { get; set; }
           
        }
        public string FischArtInsert(FishArtRecord value)
        {
            return insertstatement + fishart_table +
                $"( {value.GetType().GetProperties()[0].Name}, {value.GetType().GetProperties()[1].Name}) VALUES ({value.fa_s_id} , {value.fa_f_id}); \n";
        }
        public record BezirkRecord
        {
            public int b_id { get; set; }
            public string? b_name { get; set; }
        }
        public string BezirkInsert(BezirkRecord value)
        {
            return insertstatement + bezrik_table+
                $"( {value.GetType().GetProperties()[0].Name},{value.GetType().GetProperties()[1].Name}) " +
                $"VALUES ({value.b_id} , '{value.b_name}'); \n";
        }
        public record AusuebungsberechtigteRecord
        {
            public int ab_id { get; set; }
            public string? ab_name { get; set; }
            public DateOnly ab_datum { get; set; }
        }
        public string AusuebungsberechtigteInsert(AusuebungsberechtigteRecord value)
        {
            return insertstatement + ausuebungsberechtigte_table +
                $"( {value.GetType().GetProperties()[0].Name}, {value.GetType().GetProperties()[1].Name},{value.GetType().GetProperties()[2].Name}) VALUES ({value.ab_id} , '{value.ab_name}', '{value.ab_datum.ToString("yyyy-MM-dd")}'); \n";
        }
        public record RevierRecord
        {
            public int r_id { get; set; }
            public int r_ab_id { get; set; }
            public int r_ersteller { get; set; }
            public int r_g_id { get; set; }
            public string? r_name { get; set; }
            public string? r_addresse { get; set; }
        }
        public string RevierInsert(RevierRecord value)
        {
            return insertstatement + revier_table +
                $"( {value.GetType().GetProperties()[0].Name}, {value.GetType().GetProperties()[1].Name}, " +
                $"{value.GetType().GetProperties()[2].Name}, {value.GetType().GetProperties()[3].Name}, " +
                $"{value.GetType().GetProperties()[4].Name}, {value.GetType().GetProperties()[5].Name}) "+
                 $"VALUES ({value.r_id} , {value.r_ab_id}, {value.r_ersteller},{value.r_g_id}, '{value.r_name}', '{value.r_addresse}'); \n";
        }
        public record RevierValuesRecord
        {
            public int rv_r_id { get; set; }
            public int rv_ra_id { get; set; }
            public DateTime? rv_datetime_value { get; set; }
            public string? rv_string_value{ get; set; }
            public int? rv_int_value { get; set; }
        }
        public string RevierValuesInsert(RevierValuesRecord value)
        {
            var insertval = "";
            var insertprop = "";
            if (value.rv_datetime_value != null)
            {
                insertprop = $"{value.GetType().GetProperties()[2].Name})";
                DateTime a = (DateTime)value.rv_datetime_value;
                insertval = ",'" + a.ToString("yyyy-MM-dd HH:mm:ss.fff") + "')\n";

            }
            var insertvalString = "";
            var insertpropString = "";
            if (value.rv_string_value != null)
            {
                insertpropString = $"{value.GetType().GetProperties()[3].Name})";
                insertvalString = $",'{value.rv_string_value}');\n";
            }
            var insertvalInt = "";
            var insertpropInt = "";
            if (value.rv_int_value != null)
            {
                insertpropString = $"{value.GetType().GetProperties()[4].Name}) ";
                insertvalString = $", {value.rv_int_value});\n";
            }
            return insertstatement + revier_values_table +
                $"( {value.GetType().GetProperties()[0].Name}," +
                $"{value.GetType().GetProperties()[1].Name}," +
                insertprop +
                insertpropString +
                 insertpropInt +
                $"VALUES ({value.rv_r_id} , {value.rv_ra_id} {insertval} {insertvalString} {insertvalInt}";
        }
        public record RevierAttributesRecord
        {
            public int ra_id { get; set; }
            public string? ra_name { get; set; }
        }
        public string RevierAttributesInsert(RevierAttributesRecord value)
        {
            return insertstatement + revier_attributes_table +
                $"( {value.GetType().GetProperties()[0].Name},{value.GetType().GetProperties()[1].Name}) VALUES ({value.ra_id} , '{value.ra_name}');\n";
        }
        public record UsersRecord
        {
            public int u_id { get; set; }
            public string? u_name { get; set; }
            public string? u_telnr { get; set; }
            public string? u_email { get; set; }
        }
        public string UsersInsert(UsersRecord value)
        {
            return insertstatement + users_table+
                $"( {value.GetType().GetProperties()[0].Name}," +
                $"{value.GetType().GetProperties()[1].Name}," +
                $" {value.GetType().GetProperties()[2].Name}," +
                $"{value.GetType().GetProperties()[3].Name}) " +
                $"VALUES ({value.u_id} , '{value.u_name}','{value.u_telnr}','{value.u_email}');\n";
        }
        public record BewertungRecord
        {
            public int b_id { get; set; }
            public int b_u_id { get; set; }
            public int b_r_id { get; set; }
            public int b_rating_id { get; set; }
            public string? b_kommentar { get; set; }
            public int b_aktiv{ get; set; }
            public DateTime b_datum{ get; set; }
        }
        public string BewertungInsert(BewertungRecord value)
        {
            return insertstatement + bewertung_table+
                $"( {value.GetType().GetProperties()[0].Name}," +
                $"{value.GetType().GetProperties()[1].Name}," +
                $"{value.GetType().GetProperties()[2].Name}," +
                $"{value.GetType().GetProperties()[3].Name}," +
                $"{value.GetType().GetProperties()[4].Name}," +
                $"{value.GetType().GetProperties()[5].Name}," +
                $"{value.GetType().GetProperties()[6].Name})" +
                $" VALUES ({value.b_id}, {value.b_u_id},{value.b_r_id},{value.b_rating_id}, '{value.b_kommentar}',{value.b_aktiv}, '{value.b_datum.ToString("yyyy-MM-dd HH:mm:ss.fff")}');\n";
        }

        public record RatingRecord
        {
            public int r_id { get; set; }
            public int r_value { get; set; }
        }
        public string RatingInsert(RatingRecord value)
        {
            return insertstatement + rating_table +
                $"( {value.GetType().GetProperties()[0].Name},{value.GetType().GetProperties()[1].Name}) " +
                $"VALUES ({value.r_id}, {value.r_value});\n";
        }
        public record KarteRecord
        {
            public int k_id { get; set; }
            public int k_r_id { get; set; }
            public DateTime k_von { get; set; }
            public DateTime k_bis { get; set; }
            public int k_preis { get; set; }
        }
        public string KarteInsert(KarteRecord value)
        {
            return insertstatement + karte_table+
                $"( {value.GetType().GetProperties()[0].Name}," +
                $"{value.GetType().GetProperties()[1].Name}," +
                $"{value.GetType().GetProperties()[2].Name}," +
                $"{value.GetType().GetProperties()[3].Name},  " +
                 $"{value.GetType().GetProperties()[4].Name}) " +
                $"VALUES ({value.k_id} , {value.k_r_id},'{value.k_von.ToString("yyyy-MM-dd HH:mm:ss.fff")}', '{value.k_bis.ToString("yyyy-MM-dd HH:mm:ss.fff")}',{value.k_preis});\n";
        }
        public record VerkaufRecord
        {
            public int v_id { get; set; }
            public int v_k_id { get; set; }
            public int v_u_id { get; set; }
            public DateTime v_datum { get; set; }
        }
        public string VerkaufInsert(VerkaufRecord value)
        {
            return insertstatement + verkauf_table+
                $"( {value.GetType().GetProperties()[0].Name},{value.GetType().GetProperties()[1].Name}," +
                $"{value.GetType().GetProperties()[2].Name},{value.GetType().GetProperties()[3].Name}) " +
                $"VALUES ({value.v_id} , {value.v_k_id},{value.v_u_id}, (convert(datetime,'{value.v_datum}',5)));\n";
        }
        #endregion

        public Reader.Reader reader;
        List<Reader.Reader.CSVRecord2> arrayList; 

        public string Script { get; set; }
        GeneralHelpers ghelper; 
        public FishDb()
        {
            ghelper = new GeneralHelpers();
            Script = "";
            //independent tables
            reader = new Reader.Reader();
            arrayList = (List<Reader.Reader.CSVRecord2>?)reader.OliRead();


            GenerateFish();
            GenerateBezirk();
            GenerateGewaesser();
            GenerateAusuebungsberechtigte();
            GenerateRevierAttributes();
            GenerateRating();
            GenerateUsers();
            GenerateReviers(arrayList);
            GenerateAufsichtsorgane();
            GenerateBewertung();
            GenerateKarten();
            GenerateRevierValues();

            //arraylist with real revier name and id

        }
        //independent
        // Fisch
        // Bundesland
        // ausuebungsberechtigte
        // Revier attributes
        // Rating
        // users
        private int fishid = 0;
        public void GenerateFish()
        {
            var a = FischInsert(new FischRecord
            {
                f_id = fishid,
                f_name = "Regenbogenforelle"
            });
            fishid++;
            Script += a;
             a = FischInsert(new FischRecord
            {
                f_id = fishid,
                f_name = "Bachsaibling"
            });
            fishid++;
            Script += a;
             a = FischInsert(new FischRecord
            {
                f_id = fishid,
                f_name = "Karpfen"
            });
            fishid++;
            Script += a;
            a = FischInsert(new FischRecord
            {
                f_id = fishid,
                f_name = "Europäischer Aal"
            });
            fishid++;
            Script += a;
            a = FischInsert(new FischRecord
            {
                f_id = fishid,
                f_name = "Atlantischer Lachs"
            });
            fishid++;
            Script += a;
            a = FischInsert(new FischRecord
            {
                f_id = fishid,
                f_name = "Thunfisch"
            });
            fishid++;
            Script += a;
            a = FischInsert(new FischRecord
            {
                f_id = fishid,
                f_name = "Atlantischer Hering"
            });
            fishid++;
            Script += a;
            a = FischInsert(new FischRecord
            {
                f_id = fishid,
                f_name = "Dorsch"
            });
            fishid++;
            Script += a;
            a = FischInsert(new FischRecord
            {
                f_id = fishid,
                f_name = "Sardine"
            });
            fishid++;
            Script += a + "\n\n";
        }

        private int bezirkid = 0;
        public void GenerateBezirk()
        {
            var a = BezirkInsert(
                new BezirkRecord { 
                    b_id = bezirkid,
                    b_name= "Spittal an der Drau"
                }
                ) ;
     
            bezirkid++;
            Script += a+"\n\n";
        }

        public void GenerateAusuebungsberechtigte()
        {

            Script += "\n\n\n\n\n";
            var a = AusuebungsberechtigteInsert(
                new AusuebungsberechtigteRecord
                {
                    ab_id = 0,
                    ab_datum = DateOnly.Parse("2022-01-14"),
                    ab_name = "VIP Fishing"
                }
                ) ;
            Script += a;
            string path = Path.Combine(Environment.CurrentDirectory, @"scripts/test.ab_ausuebungsberechtigte.sql");
            string text = File.ReadAllText(path);
            Script += text;
            Script += "\n\n\n\n\n";

        }
        public int RevierAttributesID =1;
        public void GenerateRevierAttributes()
        {
            Script += RevierAttributesInsert(
                new RevierAttributesRecord
                {
                    ra_id = RevierAttributesID,
                    ra_name = "Maximale Tiefe"
                }
                );
            RevierAttributesID++;
            Script += RevierAttributesInsert(
                new RevierAttributesRecord
                {
                    ra_id = RevierAttributesID,
                    ra_name = "Gratis parkplatz"
                }
                );
            RevierAttributesID++;
            Script += RevierAttributesInsert(
                new RevierAttributesRecord
                {
                    ra_id = RevierAttributesID,
                    ra_name = "Kann man schwimmen"
                }
                );
            RevierAttributesID++;
            Script += RevierAttributesInsert(
                new RevierAttributesRecord
                {
                    ra_id = RevierAttributesID,
                    ra_name = "Wasserreinheit"
                }
                );
            RevierAttributesID++;
            Script += RevierAttributesInsert(
                new RevierAttributesRecord
                {
                    ra_id = RevierAttributesID,
                    ra_name = "Bootfahren erlaubt"
                }
                );

        }
        public void GenerateRating()
        {
            #region 5 ratings
            var a = RatingInsert(
                new RatingRecord
                {
                    r_id = 1 ,
                    r_value = 1
                }
                );
             a += RatingInsert(
                new RatingRecord
                {
                    r_id = 2,
                    r_value = 2
                }
                );
            a += RatingInsert(
               new RatingRecord
               {
                   r_id = 3,
                   r_value = 3
               }
               );
            a += RatingInsert(
               new RatingRecord
               {
                   r_id = 4,
                   r_value = 4
               }
               );
            a += RatingInsert(
               new RatingRecord
               {
                   r_id = 5,
                   r_value = 5
               }
               );
            #endregion
            Script += a;
        }
        public void GenerateUsers()
        {
            Script += "\n\n\n\n\n";

            GeneralHelpers ghelper = new GeneralHelpers();
            var a = UsersInsert(
                new UsersRecord
                {
                    u_id = 0,
                    u_name = "Oliwier Nowak",
                    u_telnr = "+43 999999999",
                    u_email = ghelper.GenerateEmail("Oliwier Nowak")
                }
                ); ;
            Script += a;
            string path = Path.Combine(Environment.CurrentDirectory, @"scripts/test.u_users.sql");
            string text = File.ReadAllText(path);
            Script += text;
            Script += "\n\n\n\n\n";

        }
        public void GenerateGewaesser()
        {
           var a = GewaesserInsert(new GewaesserRecord
           {
               g_id = 1,
               g_b_id = bezirkid-1,
               g_name = "Egelsee",
               g_typ = "stehendes wasser"
           });
            Script += a;
             a = GewaesserInsert(new GewaesserRecord
            {
                g_id = 2,
                g_b_id = bezirkid-1,
                g_name = "Drau",
                g_typ = "fliessendes wasser"
            });
            Script += a;
        }



        //less independent
        //revier
        //aufsichtsorgane
        //bewertung
        //karte
        //verkauf
        //revierAttributes
        public int reviersid = 0;
        public void GenerateReviers(List<Reader.Reader.CSVRecord2> csvrecords)
        {

            //r_ab reandom zahl between 1 30

            Random rd = new Random();

            
            csvrecords.RemoveAt(0);
            csvrecords.RemoveRange(0, 220);
            foreach(var x in csvrecords)
            {
                var rand = rd.Next(1, 80);
                    Script += RevierInsert(
                    new RevierRecord
                    {
                        r_id = reviersid,
                        r_ab_id = rand%28+1,
                        r_addresse = x.AUFSICHTSORGANE,
                        r_ersteller = rand,
                        r_name = x.REVIER_NAME,
                        r_g_id = rand%2+1
                    }
                    );
                     reviersid++;         
            }
                     
        }
        public void GenerateAufsichtsorgane()
        {
            var a = AufsichtsOrganeInsert(
                new AufsichtsOrganeRecord
                {
                    ao_r_id = 1,
                    ao_u_id = 1
                }
                );
            Script += $"insert into test.ao_aufsichtsorgane " +
                $"select top 20 u_id,r_id from test.u_users,test.r_revier order by newID(); ";
            Script += "\n\n\n\n\n";
        }
        public record FetchBody
        {
            public string Body { get; set; }
        };
        public void GenerateBewertung()
        {


            var client = new RestClient("https://dummyjson.com/comments?limit=20");
            var request = new RestRequest();

            var aqq = client.Execute(request).Content;
            dynamic json = JsonConvert.DeserializeObject(aqq);

           // FetchBody users = new();
            var comments = new List<string>();

            foreach (var user in json["comments"])
            {
                comments.Add( Convert.ToString(user["body"]));
            }
            Random rand = new Random();

            int id = 1;
            Script += "\n\n\n\n\n";
            foreach (var comment in comments)
            {
                var ran = rand.Next(1, 100);
                Script += BewertungInsert(
                new BewertungRecord
                {
                    b_id = id,
                    b_u_id = ran % 78 + 1,
                    b_r_id = ran % 29 + 1,
                    b_rating_id = ran%4+1,
                    b_aktiv = ran % 2 +1,
                    b_datum = DateTime.Now,
                    b_kommentar = comment
                }
                );
                id++;
            }
            Script += "\n\n\n\n\n";

        }
        public void GenerateKarten()
        {
            Random rand = new Random();

            for(int i = 1; i < 15; i++)
            {
                var x = rand.Next(1,20);
                Script += KarteInsert(
                new KarteRecord
                {
                    k_id = i,
                    k_r_id = x,
                    k_bis = DateTime.Now.AddDays(x),
                    k_von = DateTime.Now,
                    k_preis = x * 2
                }
                );
            }
            Script += "\n\n\n\n\n";
        }

        public void GenerateVerkauf()
        {
            var a = VerkaufInsert(
                new VerkaufRecord
                {
                    v_id = 1,
                    v_k_id = 1,
                    v_u_id = 1,
                    v_datum = DateTime.Now
                }
                ) ;
            Script += a;
        }

        public record AttributeRevier
        {
            public int RevierID { get; set; }
            public int AttributeID { get; set; }

        }


        public void GenerateRevierValues()
        {
            Script += RevierValuesInsert(
                new RevierValuesRecord
                {
                    rv_r_id=1,
                    rv_ra_id=1,
                    rv_int_value=100
                }
                );
            Script += RevierValuesInsert(
             new RevierValuesRecord
             {
                 rv_r_id = 1,
                 rv_ra_id = 2,
                 rv_string_value = "Ja"
             }
             );
            Script += RevierValuesInsert(
              new RevierValuesRecord
              {
                  rv_r_id = 1,
                  rv_ra_id = 3,
                  rv_string_value = "Ja"
              }
              );
            Script += RevierValuesInsert(
              new RevierValuesRecord
              {
                  rv_r_id = 1,
                  rv_ra_id = 4,
                  rv_int_value = 70
              }
              );
            Script += RevierValuesInsert(
             new RevierValuesRecord
             {
                 rv_r_id = 1,
                 rv_ra_id = 5,
                 rv_string_value = "Ja"
             }
             );

            Random rd = new Random();
        

            List<AttributeRevier> vallist = new List<AttributeRevier>();
            
            int i = 0;
            while (i < 20)
            {
                
                int rand_revier_id = rd.Next(2, 20);
                int rand_attribute_id = rd.Next(1, 5);
                var j = vallist.Where(x => x.RevierID.Equals(rand_revier_id));
                if (  j.Count() == 0 || !j.Any(x=> x.AttributeID.Equals(rand_attribute_id))  )
                {
                    var valuetoinsert = "";
                    vallist.Add(new AttributeRevier
                    {
                        RevierID = rand_revier_id,
                        AttributeID = rand_attribute_id
                    } );
                    switch (rand_attribute_id)
                    {
                        case 1:
                            Script += RevierValuesInsert(
                              new RevierValuesRecord
                              {
                                rv_r_id = rand_revier_id,
                                rv_ra_id = rand_attribute_id,
                                rv_int_value = rd.Next(20, 90)
                               }
                            );
                            break;
                        case 2:
                            Script += RevierValuesInsert(
                              new RevierValuesRecord
                              {
                                  rv_r_id = rand_revier_id,
                                  rv_ra_id = rand_attribute_id,
                                  rv_string_value = (rand_revier_id + rand_revier_id) % 2 > 0 ? "Ja" : "Nein"
                              }
                            );
                            break;
                        case 3:
                            Script += RevierValuesInsert(
                              new RevierValuesRecord
                              {
                                  rv_r_id = rand_revier_id,
                                  rv_ra_id = rand_attribute_id,
                                  rv_string_value = (rand_revier_id + rand_revier_id) % 2 > 0 ? "Ja" : "Nein"
                              }
                            );
                            break;
                        case 4:
                            Script += RevierValuesInsert(
                              new RevierValuesRecord
                              {
                                  rv_r_id = rand_revier_id,
                                  rv_ra_id = rand_attribute_id,
                                  rv_int_value = rand_revier_id / 20 * 100
                              }
                            ) ;
                            break;
                        case 5:
                            Script += RevierValuesInsert(
                              new RevierValuesRecord
                              {
                                  rv_r_id = rand_revier_id,
                                  rv_ra_id = rand_attribute_id,
                                  rv_string_value = (rand_revier_id + rand_revier_id) % 2 > 0? "Ja" : "Nein"
                              }
                            ); ;
                            break;

                    }
                    
                  
                }
                
                i++;
            };
        }
    }
}

