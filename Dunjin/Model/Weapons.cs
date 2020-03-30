using System;
using SQLite;

namespace Dunjin.Model
{
    public class Weapons
    {
        [PrimaryKey, AutoIncrement]
        public string Id { get; set; }
        public string WeaponName { get; set; }
        public string WeaponDamage { get; set; }
        public string WeaponName2 { get; set; }
        public string WeaponDamage2 { get; set; }
        public string CharacterId { get; set; }
        public string UserId { get; set; }
        public string CampaignId { get; set; }
    }
}
