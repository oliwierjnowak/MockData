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
        public record FischRecord
        {
            public int f_id { get; set; }
            public string? f_na { get; set; }

        }
        public string FischInsert(FischRecord value)
        {
            return insertstatement+ fish_table +  
                @$"( {value.GetType().GetProperties()[0].Name}, 
                    {value.GetType().GetProperties()[1].Name}) 
                    VALUES ({value.f_id} , '{value.f_na}');";
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
                @$"( {value.GetType().GetProperties()[0].Name}, 
                    {value.GetType().GetProperties()[1].Name}, 
                    {value.GetType().GetProperties()[2].Name}) 
                    VALUES ({value.s_id} , {value.s_bl_id}, '{value.s_name}');";
        }
        public record FishArtRecord
        {
            public int fa_s_id { get; set; }
            public int fa_f_id { get; set; }
           
        }
        public string FischArtInsert(FishArtRecord value)
        {
            return insertstatement + fishart_table +
                @$"( {value.GetType().GetProperties()[0].Name}, 
                    {value.GetType().GetProperties()[1].Name}) 
                    VALUES ({value.fa_s_id} , {value.fa_f_id});";
        }
        public record BundeslandRecord
        {
            public int bl_id { get; set; }
            public string? bl_name { get; set; }
        }
        public string BundeslandInsert(BundeslandRecord value)
        {
            return insertstatement + bundesland_table+
                @$"( {value.GetType().GetProperties()[0].Name}, 
                    {value.GetType().GetProperties()[1].Name}) 
                    VALUES ({value.bl_id} , '{value.bl_name}');";
        }
        public record AusuebungsberechtigteRecord
        {
            public int ab_id { get; set; }
            public string? ab_name { get; set; }
            public DateTime ab_datum { get; set; }
        }
        public string AusuebungsberechtigteInsert(AusuebungsberechtigteRecord value)
        {
            return insertstatement + ausuebungsberechtigte_table +
                @$"( {value.GetType().GetProperties()[0].Name}, 
                    {value.GetType().GetProperties()[1].Name},
                    {value.GetType().GetProperties()[2].Name}) 
                    VALUES ({value.ab_id} , '{value.ab_name}', '{value.ab_datum}');";
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
                @$"( {value.GetType().GetProperties()[0].Name}, 
                    {value.GetType().GetProperties()[1].Name}, 
                    {value.GetType().GetProperties()[2].Name}, 
                    {value.GetType().GetProperties()[3].Name}, 
                    {value.GetType().GetProperties()[4].Name}, 
                    {value.GetType().GetProperties()[5].Name}) 
                    VALUES ({value.r_id} , {value.r_ab_id}, {value.r_ersteller},
                            {value.r_s_id}, '{value.r_name}', '{value.r_adresse}');";
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
                @$"( {value.GetType().GetProperties()[0].Name}, 
                    {value.GetType().GetProperties()[1].Name},
                    {value.GetType().GetProperties()[2].Name},
                    {value.GetType().GetProperties()[3].Name},
                    {value.GetType().GetProperties()[3].Name}) 
                    VALUES ({value.rv_r_id} , {value.rv_ra_id}, '{value.rv_datetime_value}',
                            '{value.rv_string_value}', {value.rv_int_value});";
        }
        public record RevierAttributesRecord
        {
            public int ra_id { get; set; }
            public string? ra_name { get; set; }
        }
        public string RevierAttributesInsert(RevierAttributesRecord value)
        {
            return insertstatement + revier_attributes_table +
                @$"( {value.GetType().GetProperties()[0].Name}, 
                    {value.GetType().GetProperties()[1].Name}) 
                    VALUES ({value.ra_id} , '{value.ra_name}');";
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
                @$"( {value.GetType().GetProperties()[0].Name}, 
                    {value.GetType().GetProperties()[1].Name}, 
                    {value.GetType().GetProperties()[2].Name}, 
                    {value.GetType().GetProperties()[3].Name}) 
                    VALUES ({value.u_id} , '{value.u_name}','{value.u_telnr}','{value.u_email}');";
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
                @$"( {value.GetType().GetProperties()[0].Name}, 
                    {value.GetType().GetProperties()[1].Name}, 
                    {value.GetType().GetProperties()[2].Name}, 
                    {value.GetType().GetProperties()[3].Name},
                    {value.GetType().GetProperties()[4].Name},
                    {value.GetType().GetProperties()[5].Name},
                    {value.GetType().GetProperties()[6].Name}) 
                    VALUES ({value.b_id} , {value.b_u_id},{value.b_r_id},{value.b_rating_id}
                            '{value.b_kommentar}',{value.b_aktiv}, '{value.b_datum}');";
        }

        public record RatingRecord
        {
            public int r_id { get; set; }
            public int r_value { get; set; }
        }
        public string RatingInsert(RatingRecord value)
        {
            return insertstatement + bundesland_table +
                @$"( {value.GetType().GetProperties()[0].Name}, 
                    {value.GetType().GetProperties()[1].Name}) 
                    VALUES ({value.r_id} , '{value.r_value}');";
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
                @$"( {value.GetType().GetProperties()[0].Name}, 
                    {value.GetType().GetProperties()[1].Name}, 
                    {value.GetType().GetProperties()[2].Name}, 
                    {value.GetType().GetProperties()[3].Name}) 
                    VALUES ({value.k_id} , {value.k_r_id},
                            '{value.k_von}', '{value.k_bis}');";
        }
        public record VerkaufRecord
        {
            public int v_id { get; set; }
            public int v_k_id { get; set; }
            public int v_u_von { get; set; }
            public DateTime v_datum { get; set; }
        }
        public string VerkaufInsert(VerkaufRecord value)
        {
            return insertstatement + verkauf_table+
                @$"( {value.GetType().GetProperties()[0].Name}, 
                    {value.GetType().GetProperties()[1].Name}, 
                    {value.GetType().GetProperties()[2].Name}, 
                    {value.GetType().GetProperties()[3].Name}) 
                    VALUES ({value.v_id} , {value.v_k_id},
                            {value.v_u_von}, '{value.v_datum}');";
        }
        #endregion

        public FishDb()
        {
            
        }

 
    }
}

