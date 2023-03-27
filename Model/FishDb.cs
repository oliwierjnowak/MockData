using System.Collections;
using System.Reflection;

namespace MockData.Model
{
    public class FishDb
    {
        public readonly static string insertstatement = "Insert into ";
        #region tables
        public readonly string see_table = "s_see";
        public readonly string fishart_table = "fa_fischart";
        public readonly string fish_table = "f_fisch";
        public readonly string bundesland_table = "bl_bundesland";
        public readonly string ausuebungsberechtigte_table = "ab_ausuebungsberechtigte";
        public readonly string aufsichtsorgane_table = "ao_aufsichtsorgane";
        public readonly string revier_table = "r_revier";
        public readonly string users_table = "u_users";
        public readonly string bewertung_table = "b_bewertung";
        public readonly string rating_table = "r_rating";
        public readonly string revier_values_table = "rv_revier_values";
        public readonly string revier_attributes_table = "ra_revier_attributes";
        public readonly string verkauf_table = "v_verkauf";
        public readonly string karte_table = "k_karte";
        #endregion

        #region records
        public record AufsichtsOrganeRecord
        {
            public int ao_u_id { get; set; }
            public int ao_r_na { get; set; }

        }
        public string AufsichtsOrganeInsert(AufsichtsOrganeRecord value)
        {
            return insertstatement + aufsichtsorgane_table+
                $"( {value.GetType().GetProperties()[0].Name}, {value.GetType().GetProperties()[1].Name}) " +
                $"VALUES ({value.ao_u_id} , {value.ao_r_na}); \n";
        }

        public record FischRecord
        {
            public int f_id { get; set; }
            public string? f_na { get; set; }

        }
        public string FischInsert(FischRecord value)
        {
            return insertstatement+ fish_table +  
                $"( {value.GetType().GetProperties()[0].Name}, {value.GetType().GetProperties()[1].Name}) " +
                $"VALUES ({value.f_id} , '{value.f_na}'); \n";
        }
        public record SeeRecord
        {
            public int s_id { get; set; }
            public int s_bl_id { get; set; }
            public string? s_name { get; set; }
        }
        public string SeeInsert(SeeRecord value)
        {
            return insertstatement + see_table +
                $"( {value.GetType().GetProperties()[0].Name}, {value.GetType().GetProperties()[1].Name}," +
                $"{value.GetType().GetProperties()[2].Name}) " +
                $"VALUES ({value.s_id} , {value.s_bl_id}, '{value.s_name}'); \n";
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
        public record BundeslandRecord
        {
            public int bl_id { get; set; }
            public string? bl_name { get; set; }
        }
        public string BundeslandInsert(BundeslandRecord value)
        {
            return insertstatement + bundesland_table+
                $"( {value.GetType().GetProperties()[0].Name},{value.GetType().GetProperties()[1].Name}) VALUES ({value.bl_id} , '{value.bl_name}'); \n";
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
                $"( {value.GetType().GetProperties()[0].Name}, {value.GetType().GetProperties()[1].Name},{value.GetType().GetProperties()[2].Name}) VALUES ({value.ab_id} , '{value.ab_name}', '{value.ab_datum}'); \n";
        }
        public record RevierRecord
        {
            public int r_id { get; set; }
            public int r_ab_id { get; set; }
            public int r_ersteller { get; set; }
            public int r_s_id { get; set; }
            public string? r_name { get; set; }
            public string? r_adresse { get; set; }
        }
        public string RevierInsert(RevierRecord value)
        {
            return insertstatement + revier_table +
                $"( {value.GetType().GetProperties()[0].Name}, {value.GetType().GetProperties()[1].Name}, " +
                $"{value.GetType().GetProperties()[2].Name}, {value.GetType().GetProperties()[3].Name}, " +
                $"{value.GetType().GetProperties()[4].Name}, {value.GetType().GetProperties()[5].Name}) "+
                 $"VALUES ({value.r_id} , {value.r_ab_id}, {value.r_ersteller},{value.r_s_id}, '{value.r_name}', '{value.r_adresse}'); \n";
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
            return insertstatement + revier_values_table +
                $"( {value.GetType().GetProperties()[0].Name}," +
                $"{value.GetType().GetProperties()[1].Name}," +
                $"{value.GetType().GetProperties()[2].Name}," +
                $"{value.GetType().GetProperties()[3].Name}," +
                $"{value.GetType().GetProperties()[4].Name}) " +
                $"VALUES ({value.rv_r_id} , {value.rv_ra_id}, '{value.rv_datetime_value}','{value.rv_string_value}', {value.rv_int_value});\n";
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
            public bool b_aktiv{ get; set; }
            public DateTime? b_datum{ get; set; }
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
                $" VALUES ({value.b_id}, {value.b_u_id},{value.b_r_id},{value.b_rating_id}, '{value.b_kommentar}',{value.b_aktiv}, '{value.b_datum}');\n";
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
        }
        public string KarteInsert(KarteRecord value)
        {
            return insertstatement + karte_table+
                $"( {value.GetType().GetProperties()[0].Name}," +
                $"{value.GetType().GetProperties()[1].Name}," +
                $"{value.GetType().GetProperties()[2].Name}," +
                $"{value.GetType().GetProperties()[3].Name}) " +
                $"VALUES ({value.k_id} , {value.k_r_id},'{value.k_von}', '{value.k_bis}');\n";
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
                $"VALUES ({value.v_id} , {value.v_k_id},{value.v_u_id}, '{value.v_datum}');\n";
        }
        #endregion

        public Reader.Reader reader;
        ArrayList arrayList; 

        public string Script { get; set; }

        public FishDb()
        {
            Script = "";
            //independent tables
            reader = new Reader.Reader();
            arrayList = reader.readRevier();
           
            
            GenerateFish();
            GenerateBundesland();
            GenerateAusuebungsberechtigte();
            GenerateRevierAttributes();
            GenerateRating();
            GenerateUsers();
            GenerateReviers();
            GenerateAufsichtsorgane();
            GenerateBewertung();
            GenerateKarten();
            GenerateRevierValues();
            
            //arraylist with real revier name and id
            foreach (var revier in arrayList)
            {
                Script += revier;
            }
        }
        //independent
        // Fisch
        // Bundesland
        // ausuebungsberechtigte
        // Revier attributes
        // Rating
        // users

        public void GenerateFish()
        {
            var a = FischInsert(new FischRecord
            {
                f_id = 1,
                f_na = "Forelle"
            });
            Script += a;
        }

        public void GenerateBundesland()
        {
            var a = BundeslandInsert(
                new BundeslandRecord { 
                    bl_id = 1 ,
                    bl_name="Voralberg"
                }
                ) ;
            Script += a;
        }

        public void GenerateAusuebungsberechtigte()
        {
            var a = AusuebungsberechtigteInsert(
                new AusuebungsberechtigteRecord
                {
                    ab_id = 1,
                    ab_datum = DateOnly.Parse("2022-01-14"),
                    ab_name = "VIP Fishing"
                }
                ) ;
            Script += a;
        } 
        public void GenerateRevierAttributes()
        {
            var a = RevierAttributesInsert(
                new RevierAttributesRecord
                {
                    ra_id = 1 ,
                    ra_name = "Tiefe"
                }
                );
            Script += a;
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
            var a = UsersInsert(
                new UsersRecord
                {
                    u_id = 1,
                    u_name = "Oliwier Nowak",
                    u_telnr = "+43 999999999",
                    u_email = "now20328@spengergasse.at"
                }
                ) ;
            Script += a;
        }


        //less independent
        //revier
        //aufsichtsorgane
        //bewertung
        //karte
        //verkauf
        //revierAttributes
        public void GenerateReviers()
        {
            var a = RevierInsert(
                new RevierRecord {
                    r_id = 1,
                    r_ab_id = 1,
                    r_s_id = 1,
                    r_ersteller = 1,
                    r_adresse = "1010 Wienn, spengergasse",
                    r_name = "Fish and go"
                }
                );
                     Script += a;
        }
        public void GenerateAufsichtsorgane()
        {
            var a = AufsichtsOrganeInsert(
                new AufsichtsOrganeRecord
                {
                    ao_r_na = 1,
                    ao_u_id = 1
                }
                );
            Script += a;
        }
        public void GenerateBewertung()
        {
            var a = BewertungInsert(
                new BewertungRecord
                {
                    b_id = 1,
                    b_u_id = 1,
                    b_r_id = 1,
                    b_rating_id = 5,
                    b_aktiv = true,
                    b_datum = DateTime.Now,
                    b_kommentar = "super fische da"
                }
                );
            Script += a;
        }
        public void GenerateKarten()
        {
            var a = KarteInsert(
                new KarteRecord
                {
                    k_id = 1,
                    k_r_id = 1,
                    k_bis = DateTime.Now.AddDays(10),
                    k_von = DateTime.Now
                }
                );
            Script += a;
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

        public void GenerateRevierValues()
        {
            var a = RevierValuesInsert(
                new RevierValuesRecord
                {
                    rv_r_id=1,
                    rv_ra_id=1,
                    rv_int_value=100
                }
                );
            Script += a;
        }
    }
}

