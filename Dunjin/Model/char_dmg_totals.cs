using System;
using SQLite;

namespace Dunjin.Model
{
    public class char_dmg_totals
    {
        [PrimaryKey, AutoIncrement]
        public string Id { get; set; }
        public string CharName { get; set; }
        public int RollNum { get; set; }
        public string CampaignId { get; set; }
    }
}
