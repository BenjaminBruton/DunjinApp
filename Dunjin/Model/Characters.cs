using System;
using SQLite;

namespace Dunjin.Model
{
    public class Characters
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string CharName { get; set; }
        public string CharClass { get; set; }
        public string CharRace { get; set; }
        public string CharLevel { get; set; }
        public string CharXP { get; set; }
        public string CharStr { get; set; }
        public string CharDex { get; set; }
        public string CharCon { get; set; }
        public string CharInt { get; set; }
        public string CharWis { get; set; }
        public string CharCha { get; set; }       
        public string CharInit { get; set; }
        public string UserId { get; set; }
        public string CampaignId { get; set; }
    }
}
