﻿using System;
using SQLite;

namespace Dunjin.Model
{
    public class Characters
    {
        [PrimaryKey, AutoIncrement]
        public string Id { get; set; }
        public string CharName { get; set; }
        public string CharClass { get; set; }
        public string CharRace { get; set; }
        public int CharLevel { get; set; }
        public int CharXP { get; set; }
        public int CharStr { get; set; }
        public int CharDex { get; set; }
        public int CharCon { get; set; }
        public int CharInt { get; set; }
        public int CharWis { get; set; }
        public int CharCha { get; set; }       
        public int CharInit { get; set; }
        public int CharRoll { get; set; }
        public string UserId { get; set; }
        public string CampaignId { get; set; }
    }
}
