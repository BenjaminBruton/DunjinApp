using System;
using SQLite;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace Dunjin.Persistence
{
    public class DataHelper
    {
        [Table("Users")]
        public class Users
        {
            [PrimaryKey, AutoIncrement, Column("userid")]
            public int ID { get; set; }
            [Column("username")]
            public string Username { get; set; }
            [Column("password")]
            public string Password { get; set; }
            [Column("email")]
            public string Email { get; set; }
            [Column("signupdate")]
            public DateTime SignupDate { get; set; }
            [Column("phone")]
            public string Phone { get; set; }          
        }

        [Table("Characters")]
        public class Characters
        {
            [PrimaryKey, AutoIncrement, Column("characterid")]
            public int ID { get; set; }
            [Column("charName")]
            public string CharName { get; set; }
            [Column("charClass")]
            public string CharClass { get; set; }
            [Column("charRace")]
            public string CharRace { get; set; }
            [Column("charLevel")]
            public string CharLevel { get; set; }
            [Column("charxp")]
            public string CharXP { get; set; }
            [Column("charStr")]
            public string CharStr { get; set; }
            [Column("charDex")]
            public string CharDex { get; set; }
            [Column("charCon")]
            public string CharCon { get; set; }
            [Column("charInt")]
            public string CharInt { get; set; }
            [Column("charWis")]
            public string CharWis { get; set; }
            [Column("charCha")]
            public string CharCha { get; set; }
            [Column("charInit")]
            public string CharInit { get; set; }
        }

        [Table("Campaigns")]
        public class Campaigns
        {
            [PrimaryKey, AutoIncrement, Column("campaignid")]
            public int ID { get; set; }
            [Column("campaignname")]
            public string CampaignName { get; set; }
        }
    }
}
