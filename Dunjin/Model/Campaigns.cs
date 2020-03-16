using System;
using SQLite;

namespace Dunjin.Model
{
    public class Campaigns
    {
        [PrimaryKey, AutoIncrement]
        public string Id { get; set; }       
        public string CampaignName { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string UserId { get; set; }
    }
}
