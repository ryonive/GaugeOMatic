using System.Collections.Generic;
using static GaugeOMatic.GameData.ActionData.ActionRef.ReadyTypes;
using static GaugeOMatic.GameData.JobData;
using static GaugeOMatic.GameData.JobData.Job;
using static GaugeOMatic.GameData.JobData.Role;

namespace GaugeOMatic.GameData;

public partial class ActionData
{
    public static readonly Dictionary<uint, ActionRef> Actions = new()
    {
        #region Role

        { 7531, new(7531, Job.None, "Rampart",        90    ) { Role = Tank                  }},
        { 7533, new(7533, Job.None, "Provoke",        30    ) { Role = Tank                  }},
        { 7535, new(7535, Job.None, "Reprisal",       60    ) { Role = Tank                  }},
        { 7537, new(7537, Job.None, "Shirk",          120   ) { Role = Tank                  }},
        { 7538, new(7538, Job.None, "Interject",      30    ) { Role = Tank                  }},
        { 7540, new(7540, Job.None, "Low Blow",       25    ) { Role = Tank                  }},
        { 7541, new(7541, Job.None, "Second Wind",    120   ) { Role = Melee | Ranged        }},
        { 7542, new(7542, Job.None, "Bloodbath",      90    ) { Role = Melee                 }},
        { 7546, new(7546, Job.None, "True North",     45, 2 ) { Role = Melee                 }},
        { 7548, new(7548, Job.None, "Arm's Length",   120   ) { Role = Melee | Ranged | Tank }},
        { 7549, new(7549, Job.None, "Feint",          90    ) { Role = Melee                 }},
        { 7551, new(7551, Job.None, "Head Graze",     30    ) { Role = Ranged                }},
        { 7553, new(7553, Job.None, "Foot Graze",     30    ) { Role = Ranged                }},
        { 7554, new(7554, Job.None, "Leg Graze",      30    ) { Role = Ranged                }},
        { 7559, new(7559, Job.None, "Surecast",       120   ) { Role = Caster|Healer         }},
        { 7560, new(7560, Job.None, "Addle",          90    ) { Role = Caster                }},
        { 7561, new(7561, Job.None, "Swiftcast",      60    ) { Role = Caster|Healer         }},
        { 7562, new(7562, Job.None, "Lucid Dreaming", 60    ) { Role = Caster|Healer         }},
        { 7571, new(7571, Job.None, "Rescue",         120   ) { Role = Healer                }},
        { 7863, new(7863, Job.None, "Leg Sweep",      40    ) { Role = Melee                 }},

        #endregion

        #region Melee

        { 65,    new(65,    PGL, "Mantra",                    90    ) },
        { 69,    new(69,    MNK, "Perfect Balance",           40, 2 ) },
        { 7394,  new(4739,  MNK, "Riddle of Earth",           120   ) },
        { 7395,  new(7395,  MNK, "Riddle of Fire",            60    ) },
        { 7396,  new(7396,  MNK, "Brotherhood",               120   ) },
        { 25762, new(25762, MNK, "Thunderclap",               30, 3 ) },
        { 25766, new(25766, MNK, "Riddle of Wind",            90    ) },

        { 83,    new(83,    LNC, "Life Surge",                40, 2 ) },
        { 85,    new(85,    LNC, "Lance Charge",              60    ) },
        { 94,    new(94,    DRG, "Elusive Jump",              30    ) },
        { 96,    new(96,    DRG, "Dragonfire Dive",           120   ) },
        { 3555,  new(3555,  DRG, "Geirskogul",                30    ) { ReadyType = Ants }},
        { 3557,  new(3557,  DRG, "Battle Litany",             120   ) },
        { 16478, new(16478, DRG, "High Jump",                 30    ) { HasUpgrades = true }},
        { 16480, new(16480, DRG, "Stardiver",                 30    ) },
        { 25773, new(25773, DRG, "Wyrmwind Thrust",           10    ) { ReadyType = Ants }},
        { 36951, new(36951, DRG, "Winged Glide",              60    ) },

        { 2241,  new(2241,  ROG, "Shade Shift",               120   ) },
        { 2245,  new(2245,  ROG, "Hide",                      20    ) },
        { 2259,  new(2259,  NIN, "Mudra",                     20, 2 ) }, // using Ten to stand in for all three mudras
        { 2262,  new(2262,  NIN, "Shukuchi",                  60, 2 ) },
        { 2264,  new(2264,  NIN, "Kassatsu",                  60    ) },
        { 3566,  new(3566,  NIN, "Dream Within a Dream",      60    ) { HasUpgrades = true }},
        { 7403,  new(7403,  NIN, "Ten Chi Jin",               120   ) },
        { 16489, new(16489, NIN, "Meisui",                    120   ) { ReadyType = StatusEffect, ReadyStatus = 3848 }},
        { 16493, new(16493, NIN, "Bunshin",                   90    ) { ReadyType = Ants }},
        { 25774, new(25774, NIN, "Phantom Kamaitachi",        2.5f  ) { ReadyType = StatusEffect, ReadyStatus = 2723 }},
        { 2242,  new(2242,  NIN, "Gust Slash",                2.5f  ) { ReadyType = Ants }},
        { 36957, new(36957, NIN, "Dokumori",                  120   ) { HasUpgrades = true }},
        { 36958, new(36958, NIN, "Kunai's Bane",              60    ) { HasUpgrades = true, ReadyType = StatusEffect, ReadyStatus = 3848 }},

        { 7492,  new(7492,  SAM, "Hissatsu: Gyoten",          10    ) { ReadyType = Ants }},
        { 7493,  new(7493,  SAM, "Hissatsu: Yaten",           10    ) { ReadyType = Ants }},
        { 7496,  new(7496,  SAM, "Hissatsu: Guren",           120   ) { ReadyType = Ants }},
        { 7497,  new(7497,  SAM, "Meditate",                  60    ) },
        { 7499,  new(7499,  SAM, "Meikyo Shisui",             55, 2 ) },
        { 16481, new(16481, SAM, "Hissatsu: Senei",           120   ) { ReadyType = Ants }},
        { 16482, new(16482, SAM, "Ikishoten",                 120   ) },
        { 16483, new(16483, SAM, "Tsubame-gaeshi",            60, 2 ) { ReadyType = Ants }},
        { 16487, new(16487, SAM, "Shoha",                     15    ) { ReadyType = Ants }},
        { 36962, new(36962, SAM, "Tengetsu",                  15    ) { HasUpgrades = true }},

        { 24405, new(24405, RPR, "Arcane Circle",             120   ) },
        { 24404, new(24404, RPR, "Arcane Crest",              30    ) },
        { 24402, new(24402, RPR, "Hell's Egress",             20    ) },
        { 24401, new(24401, RPR, "Hell's Ingress",            20    ) },
        { 24403, new(24403, RPR, "Regress",                   10    ) { ReadyType = StatusEffect, ReadyStatus = 2595 }},
        { 24394, new(24394, RPR, "Enshroud",                  15    ) { ReadyType = Ants }},
        { 24393, new(24393, RPR, "Gluttony",                  60    ) { ReadyType = Ants }},
        { 24381, new(24381, RPR, "Soul Scythe",               30, 2 ) },
        { 24380, new(24380, RPR, "Soul Slice",                30, 2 ) },

        { 34620, new(34620, VPR, "Dreadwinder",               40, 2 ) },
        { 34623, new(34623, VPR, "Pit of Dread",              40, 2 ) },
        { 34634, new(34634, VPR, "Death Rattle",              1     ) { ReadyType = Ants }},
        { 34646, new(34646, VPR, "Slither",                   30, 3 ) },
        { 34647, new(34647, VPR, "Serpent's Ire",             120   ) },

        #endregion

        #region Ranged

        { 101,   new(101,   ARC, "Raging Strikes",            120   ) },
        { 107,   new(107,   ARC, "Barrage",                   120   ) },
        { 110,   new(110,   ARC, "Bloodletter",               15, 3 ) },
        { 112,   new(112,   ARC, "Repelling Shot",            30    ) },
        { 114,   new(114,   BRD, "Mage's Ballad",             120   ) },
        { 116,   new(116,   BRD, "Army's Paeon",              120   ) },
        { 117,   new(117,   BRD, "Rain of Death",             15, 3 ) },
        { 118,   new(118,   BRD, "Battle Voice",              120   ) },
        { 3558,  new(3558,  BRD, "Empyreal Arrow",            15    ) },
        { 3559,  new(3559,  BRD, "The Wanderer's Minuet",     120   ) },
        { 3561,  new(3561,  BRD, "The Warden's Paean",        45    ) },
        { 3562,  new(3562,  BRD, "Sidewinder",                60    ) },
        { 7405,  new(7405,  BRD, "Troubadour",                120   ) },
        { 7408,  new(7408,  BRD, "Nature's Minne",            120   ) },
        { 25785, new(25785, BRD, "Radiant Finale",            110   ) { ReadyType = Ants }},
        { 36975, new(36975, BRD, "Heartbreak Shot",           15, 3 ) },

        { 2874,  new(2874,  MCH, "Gauss Round",               30, 3 ) },
        { 2876,  new(2876,  MCH, "Reassemble",                55, 2 ) },
        { 2878,  new(2878,  MCH, "Wildfire",                  120   ) },
        { 2887,  new(2887,  MCH, "Dismantle",                 120   ) },
        { 2890,  new(2890,  MCH, "Ricochet",                  30, 3 ) },
        { 7414,  new(7414,  MCH, "Barrel Stabilizer",         120   ) },
        { 7418,  new(7418,  MCH, "Flamethrower",              60    ) },
        { 16498, new(16498, MCH, "Drill",                     20    ) },
        { 16499, new(16499, MCH, "Bioblaster",                20    ) },
        { 16500, new(16500, MCH, "Air Anchor",                40    ) { HasUpgrades = true }},
        { 16502, new(16502, MCH, "Overdrive",                 15    ) { HasUpgrades = true }},
        { 16889, new(16889, MCH, "Tactician",                 120   ) },
        { 17209, new(17209, MCH, "Hypercharge",               10    ) { ReadyType = Ants }},
        { 25788, new(25788, MCH, "Chain Saw",                 60    ) },
        { 36979, new(36979, MCH, "Double Check",              30, 3 ) },
        { 36980, new(36980, MCH, "Checkmate",                 30, 3 ) },

        { 15997, new(15997, DNC, "Standard Step",             30    ) },
        { 15998, new(15998, DNC, "Technical Step",            120   ) },
        { 16006, new(16006, DNC, "Closed Position",           30    ) },
        { 16010, new(16010, DNC, "En Avant",                  30, 3 ) },
        { 16011, new(16011, DNC, "Devilment",                 120   ) },
        { 16012, new(16012, DNC, "Shield Samba",              120   ) },
        { 16013, new(16013, DNC, "Flourish",                  60    ) },
        { 16014, new(16014, DNC, "Improvisation",             120   ) },
        { 16015, new(16015, DNC, "Curing Waltz",              60    ) },

        #endregion

        #region Caster

        { 155,   new(155,   THM, "Aetherial Manipulation",    10    ) },
        { 157,   new(157,   THM, "Manaward",                  120   ) },
        { 158,   new(158,   BLM, "Manafont",                  180   ) },
        { 3573,  new(3573,  BLM, "Ley Lines",                 120   ) },
        { 7421,  new(7421,  BLM, "Triplecast",                60, 2 ) },
        { 25796, new(25796, BLM, "Amplifier",                 120   ) { ReadyType = Ants }},
        { 36988, new(36988, BLM, "Retrace",                   40    ) },

        { 7427,  new(7427,  SMN, "Summon Bahamut",            60    ) { HasUpgrades = true }},
        { 7429,  new(7429,  SMN, "Enkindle Bahamut",          20    ) },
        { 16508, new(16508, ACN, "Energy Drain",              60    ) },
        { 16510, new(16510, SMN, "Energy Siphon",             60    ) },
        { 25799, new(25799, ACN, "Radiant Aegis",             60, 2 ) },
        { 25801, new(25801, SMN, "Searing Light",             120   ) },
        { 36997, new(36997, SMN, "Lux Solaris",               60    ) },

        { 7506,  new(7506,  RDM, "Corps-a-corps",             35, 2 ) },
        { 7515,  new(7515,  RDM, "Engagement / Displacement", 35, 2 ) },
        { 7517,  new(7517,  RDM, "Fleche",                    25    ) },
        { 7518,  new(7518,  RDM, "Acceleration",              55, 2 ) },
        { 7519,  new(7519,  RDM, "Contre Sixte",              45    ) },
        { 7520,  new(7520,  RDM, "Embolden",                  120   ) },
        { 7521,  new(7521,  RDM, "Manafication",              120   ) },
        { 25857, new(25857, RDM, "Magick Barrier",            120   ) },

        { 34676, new(34676, PCT, "Mog of the Ages",           30    ) },
        { 34684, new(34684, PCT, "Smudge",                    20    ) },
        { 34685, new(34685, PCT, "Tempera Coat",              120   ) },
        { 35347, new(35347, PCT, "Living Muse",               40, 3 ) },
        { 35348, new(35348, PCT, "Steel Muse",                60, 2 ) },
        { 35349, new(35349, PCT, "Scenic Muse",               120   ) },

        #endregion

        #region Tank

        { 17,    new(27,    GLA, "Sentinel",                  120   ) },
        { 20,    new(20,    GLA, "Fight or Flight",           60    ) },
        { 22,    new(22,    PLD, "Bulwark",                   90    ) },
        { 23,    new(23,    GLA, "Circle of Scorn",           30    ) },
        { 27,    new(27,    PLD, "Cover",                     120   ) },
        { 30,    new(30,    PLD, "Hallowed Ground",           420   ) },
        { 3538,  new(3538,  PLD, "Goring Blade",              60    ) },
        { 3540,  new(3540,  PLD, "Divine Veil",               90    ) },
        { 7382,  new(7382,  PLD, "Intervention",              10    ) },
        { 7383,  new(7383,  PLD, "Requiescat",                60    ) },
        { 7385,  new(7385,  PLD, "Passage of Arms",           120   ) },
        { 25747, new(25747, PLD, "Expiacion",                 30    ) { HasUpgrades = true }},
        { 16461, new(16461, PLD, "Intervene",                 30, 2 ) },
        { 36920, new(36920, PLD, "Guardian",                  120   ) },
        { 36921, new(36921, PLD, "Imperator",                 60    ) },

        { 40,    new(40,    MRD, "Thrill of Battle",          90    ) },
        { 43,    new(43,    MRD, "Holmgang",                  240   ) },
        { 44,    new(44,    MRD, "Vengeance",                 120   ) },
        { 52,    new(52,    WAR, "Infuriate",                 60, 2 ) },
        { 3552,  new(3552,  WAR, "Equilibrium",               60    ) },
        { 7386,  new(7386,  WAR, "Onslaught",                 30, 3 ) },
        { 7387,  new(7387,  WAR, "Upheaval",                  30    ) },
        { 7388,  new(7388,  WAR, "Shake It Off",              90    ) },
        { 7389,  new(7389,  WAR, "Inner Release",             60    ) { HasUpgrades = true }},
        { 16464, new(16464, WAR, "Nascent Flash",             25    ) },
        { 25751, new(25751, WAR, "Bloodwhetting",             25    ) { HasUpgrades = true }},
        { 25752, new(25752, WAR, "Orogeny",                   30    ) },
        { 36923, new(36923, WAR, "Damnation",                 120   ) },

        { 3625,  new(3625,  DRK, "Blood Weapon",              60    ) },
        { 3634,  new(3634,  DRK, "Dark Mind",                 60    ) },
        { 3636,  new(3636,  DRK, "Shadow Wall",               120   ) },
        { 3638,  new(3638,  DRK, "Living Dead",               300   ) },
        { 3639,  new(3639,  DRK, "Salted Earth",              90    ) },
        { 3641,  new(3641,  DRK, "Abyssal Drain",             60    ) },
        { 3643,  new(3643,  DRK, "Carve and Spit",            60    ) },
        { 7390,  new(7390,  DRK, "Delirium",                  60    ) },
        { 7393,  new(7393,  DRK, "The Blackest Night",        15    ) },
        { 16471, new(16471, DRK, "Dark Missionary",           90    ) },
        { 16472, new(16472, DRK, "Living Shadow",             120   ) },
        { 25754, new(25754, DRK, "Oblation",                  60, 2 ) },
        { 25757, new(25757, DRK, "Shadowbringer",             60, 2 ) },
        { 36926, new(36926, DRK, "Shadowstride",              30, 2 ) },
        { 36927, new(36927, DRK, "Shadowed Vigil",            120   ) },

        { 16138, new(16138, GNB, "No Mercy",               60       ) },
        { 16140, new(16140, GNB, "Camouflage",             90       ) },
        { 16146, new(16146, GNB, "Gnashing Fang",          30       ) },
        { 16148, new(16148, GNB, "Nebula",                 120      ) },
        { 16151, new(16151, GNB, "Aurora",                 60, 2    ) },
        { 16152, new(16152, GNB, "Superbolide",            360      ) },
        { 16153, new(16153, GNB, "Sonic Break",            60       ) },
        { 16159, new(16159, GNB, "Bow Shock",              60       ) },
        { 16160, new(16160, GNB, "Heart of Light",         90       ) },
        { 16164, new(16164, GNB, "Bloodfest",              120      ) },
        { 16165, new(16165, GNB, "Blasting Zone",          30       ) { HasUpgrades = true }},
        { 25758, new(25758, GNB, "Heart of Corundum",      25       ) { HasUpgrades = true }},
        { 25760, new(25760, GNB, "Double Down",            60       ) },
        { 36934, new(36934, GNB, "Trajectory",             30, 2    ) },
        { 36935, new(36935, GNB, "Great Nebula",           120      ) },

        #endregion

        #region Healer

        { 136,   new(136,   WHM, "Presence of Mind",       120      ) },
        { 140,   new(140,   WHM, "Benediction",            180      ) },
        { 3569,  new(3569,  WHM, "Asylum",                 90       ) },
        { 3570,  new(3570,  WHM, "Tetragrammaton",         60       ) },
        { 3571,  new(3571,  WHM, "Assize",                 40       ) },
        { 7430,  new(7430,  WHM, "Thin Air",               60, 2    ) },
        { 7432,  new(7432,  WHM, "Divine Benison",         30, 2    ) },
        { 7433,  new(7433,  WHM, "Plenary Indulgence",     60       ) },
        { 16536, new(16536, WHM, "Temperance",             120      ) },
        { 25861, new(25861, WHM, "Aquaveil",               60       ) },
        { 25862, new(25862, WHM, "Liturgy of the Bell",    180      ) },
        { 37008, new(37008, WHM, "Aetherial Shift",        60       ) },

        { 166,   new(166,   SCH, "Aetherflow",             60       ) },
        { 188,   new(188,   SCH, "Sacred Soil",            30       ) },
        { 3583,  new(3583,  SCH, "Indomitability",         30       ) },
        { 3585,  new(3585,  SCH, "Deployment Tactics",     120      ) },
        { 3586,  new(3586,  SCH, "Emergency Tactics",      15       ) },
        { 3587,  new(3587,  SCH, "Dissipation",            180      ) },
        { 7434,  new(7434,  SCH, "Excogitation",           45       ) },
        { 7436,  new(7436,  SCH, "Chain Stratagem",        120      ) },
        { 16537, new(16537, SCH, "Whispering Dawn",        60       ) },
        { 16538, new(16538, SCH, "Fey Illumination",       120      ) },
        { 16542, new(16542, SCH, "Recitation",             90       ) },
        { 16543, new(16543, SCH, "Fey Blessing",           60       ) },
        { 16545, new(16545, SCH, "Summon Seraph",          120      ) },
        { 25867, new(25867, SCH, "Protraction",            60       ) },
        { 25868, new(25868, SCH, "Expedient",              120      ) },
        { 37014, new(37014, SCH, "Seraphism",              180      ) },

        { 3606,  new(3606,  AST, "Lightspeed",             120      ) },
        { 3612,  new(3612,  AST, "Synastry",               120      ) },
        { 3613,  new(3613,  AST, "Collective Unconscious", 60       ) },
        { 3614,  new(3614,  AST, "Essential Dignity",      40, 2    ) },
        { 7439,  new(7439,  AST, "Earthly Star",           60       ) },
        { 16552, new(16552, AST, "Divination",             120      ) },
        { 16553, new(16553, AST, "Celestial Opposition",   60       ) },
        { 16556, new(16556, AST, "Celestial Intersection", 30, 2    ) },
        { 16557, new(16557, AST, "Horoscope",              60       ) },
        { 16559, new(16559, AST, "Neutral Sect",           120      ) },
        { 25873, new(25873, AST, "Exaltation",             60       ) },
        { 25874, new(25874, AST, "Macrocosmos",            180      ) },
        { 37017, new(37017, AST, "Astral/Umbral Draw",     60       ) },

        { 24318, new(24318, SGE, "Pneuma",                 120      ) },
        { 24317, new(24317, SGE, "Krasis",                 60       ) },
        { 24311, new(24311, SGE, "Panhaima",               120      ) },
        { 24310, new(24310, SGE, "Holos",                  120      ) },
        { 24309, new(24309, SGE, "Rhizomata",              90       ) },
        { 24305, new(24305, SGE, "Haima",                  120      ) },
        { 24303, new(24303, SGE, "Taurochole",             45       ) },
        { 24301, new(24301, SGE, "Pepsis",                 30       ) },
        { 24300, new(24300, SGE, "Zoe",                    120      ) },
        { 24299, new(24299, SGE, "Ixochole",               30       ) },
        { 24298, new(24298, SGE, "Kerachole",              30       ) },
        { 24295, new(24295, SGE, "Icarus",                 45       ) },
        { 24294, new(24294, SGE, "Soteria",                90       ) },
        { 24289, new(24289, SGE, "Phlegma",                40, 2    ) { HasUpgrades = true }},
        { 24288, new(24288, SGE, "Physis",                 60       ) { HasUpgrades = true }},
        { 37033, new(37033, SGE, "Psyche",                 60       ) },
        { 37035, new(37035, SGE, "Philosophia",            180      ) },

        #endregion
    };
}
