﻿using System;
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
            "Abacus",
            "Acid (vial)",
            "Alchemist's fire (flask)",
            "Alchemist's supplies",
            "Amulet",
            "Animal Feed (1 day)",
            "Antitoxin (vial)",
            "Arrow",
            "Backpack",
            "Bagpipes",
            "Ball bearings (bag of 1,000)",
            "Barding: Breastplate",
            "Barding: Chain mail",
            "Barding: Chain shirt",
            "Barding: Half plate",
            "Barding: Hide",
            "Barding: Leather",
            "Barding: Padded",
            "Barding: Plate",
            "Barding: Ring mail",
            "Barding: Scale mail",
            "Barding: Splint",
            "Barding: Studded Leather",
            "Barrel",
            "Basket",
            "Battleaxe",
            "Bedroll",
            "Bell",
            "Bit and bridle",
            "Blanket",
            "Block and tackle",
            "Blowgun needle",
            "Blowgun",
            "Book",
            "Bottle, glass",
            "Breastplate",
            "Brewer's supplies",
            "Bucket",
            "Burglar's Pack",
            "Calligrapher's supplies",
            "Caltrops",
            "Camel",
            "Candle",
            "Carpenter's tools",
            "Carriage",
            "Cart",
            "Cartographer's tools",
            "Case, crossbow bolt",
            "Case, map or scroll",
            "Chain (10 feet)",
            "Chain Mail",
            "Chain Shirt",
            "Chalk (1 piece)",
            "Chariot",
            "Chest",
            "Climber's Kit",
            "Clothes, common",
            "Clothes, costume",
            "Clothes, fine",
            "Clothes, traveler's",
            "Club",
            "Cobbler's tools",
            "Component pouch",
            "Cook's utensils",
            "Crossbow bolt",
            "Crossbow, hand",
            "Crossbow, heavy",
            "Crossbow, light",
            "Crowbar",
            "Crystal",
            "Dagger",
            "Dart",
            "Dice set",
            "Diplomat's Pack",
            "Disguise Kit",
            "Donkey",
            "Drum",
            "Dulcimer",
            "Dungeoneer's Pack",
            "Elephant",
            "Emblem",
            "Entertainer's Pack",
            "Explorer's Pack",
            "Fishing tackle",
            "Flail",
            "Flask or tankard",
            "Flute",
            "Forgery Kit",
            "Galley",
            "Glaive",
            "Glassblower's tools",
            "Grappling hook",
            "Greataxe",
            "Greatclub",
            "Greatsword",
            "Halberd",
            "Half Plate",
            "Hammer",
            "Hammer, sledge",
            "Handaxe",
            "Healer's Kit",
            "Herbalism Kit",
            "Hide",
            "Holy water (flask)",
            "Horn",
            "Horse, draft",
            "Horse, riding",
            "Hourglass",
            "Hunting trap",
            "Ink (1 ounce bottle)",
            "Ink pen",
            "Javelin",
            "Jeweler's tools",
            "Jug or pitcher",
            "Keelboat",
            "Ladder (10-foot)",
            "Lamp",
            "Lance",
            "Lantern, bullseye",
            "Lantern, hooded",
            "Leather",
            "Leatherworker's tools",
            "Light hammer",
            "Lock",
            "Longbow",
            "Longship",
            "Longsword",
            "Lute",
            "Lyre",
            "Mace",
            "Magnifying glass",
            "Manacles",
            "Mason's tools",
            "Mastiff",
            "Maul",
            "Mess Kit",
            "Mirror, steel",
            "Morningstar",
            "Mule",
            "Navigator's tools",
            "Net",
            "Oil (flask)",
            "Orb",
            "Padded",
            "Painter's supplies",
            "Pan flute",
            "Paper (one sheet)",
            "Parchment (one sheet)",
            "Perfume (vial)",
            "Pick, miner's",
            "Pike",
            "Piton",
            "Plate",
            "Playing card set",
            "Poison, basic (vial)",
            "Poisoner's Kit",
            "Pole (10-foot)",
            "Pony",
            "Pot, iron",
            "Potion of healing",
            "Potter's tools",
            "Pouch",
            "Priest's Pack",
            "Quarterstaff",
            "Quiver",
            "Ram, portable",
            "Rapier",
            "Rations (1 day)",
            "Reliquary",
            "Riding",
            "Ring Mail",
            "Robes",
            "Rod",
            "Rope, hempen (50 feet)",
            "Rope, silk (50 feet)",
            "Rowboat",
            "Sack",
            "Saddle, Exotic",
            "Saddle, Military",
            "Saddle, Pack",
            "Saddlebags",
            "Sailing ship",
            "Scale Mail",
            "Scale, merchant's",
            "Scholar's Pack",
            "Scimitar",
            "Sealing wax",
            "Shawm",
            "Shield",
            "Shortbow",
            "Shortsword",
            "Shovel",
            "Sickle",
            "Signal whistle",
            "Signet ring",
            "Sled",
            "Sling bullet",
            "Sling",
            "Smith's tools",
            "Soap",
            "Spear",
            "Spellbook",
            "Spike, iron",
            "Splint",
            "Sprig of mistletoe",
            "Spyglass",
            "Stabling (1 day)",
            "Staff",
            "Studded Leather",
            "Tent, two-person",
            "Thieves' tools",
            "Tinderbox",
            "Tinker's tools",
            "Torch",
            "Totem",
            "Trident",
            "Vial",
            "Viol",
            "Wagon",
            "Wand",
            "War pick",
            "Warhammer",
            "Warhorse",
            "Warship",
            "Waterskin",
            "Weaver's tools",
            "Whetstone",
            "Whip",
            "Woodcarver's tools",
            "Wooden staff",
            "Yew wand"
        };

        public static List<string> GetSearchResults(string queryString)
        {
            var normalizedQuery = queryString?.ToLower() ?? "";
            return Items.Where(f => f.ToLowerInvariant().Contains(normalizedQuery)).Take(5).ToList();
        }
    }
}
