using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace Dunjin.Persistence
{
    public class DataService
    {

        public static List<string> Items { get; } = new List<string>
        {
            "acid-vial",
            "alchemists-fire-flask",
            "bagpipes",
            "battleaxe",
            "blowgun",
            "club",
            "crossbow-hand",
            "crossbow-heavy",
            "crossbow-light",
            "crowbar",
            "dagger",
            "dart",
            "drum",
            "flail",
            "flute",
            "glaive",
            "greataxe",
            "greatclub",
            "greatsword",
            "halberd",
            "handaxe",
            "javelin",
            "lance",
            "light-hammer",
            "longbow",
            "longsword",
            "lute",
            "lyre",
            "mace",
            "maul",
            "morningstar",
            "net",
            "pan-flute",
            "pick-miners",
            "pike",
            "poison-basic-vial",
            "pole-10-foot",
            "quarterstaff",
            "ram-portable",
            "rapier",
            "rod",
            "scimitar",
            "shield",
            "shortbow",
            "shortsword",
            "shovel",
            "sickle",
            "sling",
            "spear",
            "staff",
            "trident",
            "wand",
            "war-pick",
            "warhammer",
            "whip",
            "wooden-staff"
        };

        public static List<string> GetSearchResults(string queryString)
        {
            var normalizedQuery = queryString?.ToLower() ?? "";
            return Items.Where(f => f.ToLowerInvariant().Contains(normalizedQuery)).Take(5).ToList();
        }



    }
}
