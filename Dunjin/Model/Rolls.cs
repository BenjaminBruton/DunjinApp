using System;
using SQLite;

namespace Dunjin.Model
{
    public class Rolls
    {
        [PrimaryKey, AutoIncrement]
        public string Id { get; set; }
        public string CharacterID { get; set; }
        public string UserId { get; set; }
        public string CampaignId { get; set; }
    }
}
