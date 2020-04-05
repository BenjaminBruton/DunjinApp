using System;
using SQLite;

namespace Dunjin.Model
{
    public class Rolls
    {
        [PrimaryKey, AutoIncrement]
        public string Id { get; set; }
        public int RollNum { get; set; }
        public string CharacterId { get; set; }
        public string UserId { get; set; }
        public string CampaignId { get; set; }
        public string RollType { get; set; }
        public string CritHit { get; set; }
        public DateTime DateTime { get; set; }
    }
}
