using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MysteryBox.Core
{
    public class Character
    {

        //Constants
        public const int MaxLevel = 20;

        public int Level;
        public int Exp;
        public int ExpRemaining;
        public Class Class;

        public Stats Stats;

        public string Name;

        public Weapon weapon;
        public Armor armor;

        public Character ( string name , Class cl)
        {
            Name = name;
            Class = cl;
            Level = 1;
            Exp = 0;
            Stats = new Stats( );
            Stats.LoadInitialStats( cl );
        }
        
        public bool HandleLevelUp ( )
        {
            if ( Exp >= ExpRemaining )
            {
                Exp = 0;
                ExpRemaining = ( int ) ( Level * 137.5f );
            }
            return true;
        }

        public void LevelUp ( )
        {
            Level++;
            Stats.LevelUp( Class );
            Level = 0;
        }

    }

    public class Stats
    {
        public int MaxHP;
        public int MaxMP;
        public int MaxDef;
        public int MaxDex;
        public int MaxAtk;
        public int MaxSpd;
        public int Maxvit;
        public int MaxWis;

        public int HP;
        public int MP;
        public int Def;
        public int Dex;
        public int Atk;
        public int Spd;
        public int Vit;
        public int Wis;

        public void LevelUp ( Class cl )
        {
            switch ( cl )
            {
                #region rogue
                case Class.Rogue:
                    HP += Utils.GenerateRandomNumber( 20, 30 );
                    MP += Utils.GenerateRandomNumber( 2, 8 );
                    Atk += Utils.GenerateRandomNumber( 0, 2 );
                    Spd += Utils.GenerateRandomNumber( 1, 2 );
                    Dex += Utils.GenerateRandomNumber( 1, 2 );
                    Vit += Utils.GenerateRandomNumber( 0, 1 );
                    Wis += Utils.GenerateRandomNumber( 0, 2 );
                    break;

                #endregion

                #region archer
                case Class.Archer:
                    HP += Utils.GenerateRandomNumber( 20, 30 );
                    MP += Utils.GenerateRandomNumber( 5, 15 );
                    Atk += Utils.GenerateRandomNumber( 1, 2 );
                    Spd += Utils.GenerateRandomNumber( 0, 2 );
                    Dex += Utils.GenerateRandomNumber( 1, 2 );
                    Vit += Utils.GenerateRandomNumber( 0, 1 );
                    Wis += Utils.GenerateRandomNumber( 0, 2 );
                    break;

                #endregion

                #region wizard
                case Class.Wizard:
                    HP += Utils.GenerateRandomNumber( 20, 30 );
                    MP += Utils.GenerateRandomNumber( 2, 8 );
                    Atk += Utils.GenerateRandomNumber( 1, 2 );
                    Spd += Utils.GenerateRandomNumber( 0, 2 );
                    Dex += Utils.GenerateRandomNumber( 0, 2 );
                    Vit += Utils.GenerateRandomNumber( 0, 1 );
                    Wis += Utils.GenerateRandomNumber( 0, 2 );
                    break;

                #endregion

                #region priest
                case Class.Priest:
                    HP += Utils.GenerateRandomNumber( 20, 30 );
                    MP += Utils.GenerateRandomNumber( 5, 15 );
                    Atk += Utils.GenerateRandomNumber( 0, 2 );
                    Spd += Utils.GenerateRandomNumber( 1, 2 );
                    Dex += Utils.GenerateRandomNumber( 0, 2 );
                    Vit += Utils.GenerateRandomNumber( 0, 1 );
                    Wis += Utils.GenerateRandomNumber( 1, 2 );
                    break;
                #endregion

                #region Warrior
                case Class.Warrior:
                    HP += Utils.GenerateRandomNumber( 20, 30 );
                    MP += Utils.GenerateRandomNumber( 2, 8 );
                    Atk += Utils.GenerateRandomNumber( 1, 2 );
                    Spd += Utils.GenerateRandomNumber( 1, 2 );
                    Dex += Utils.GenerateRandomNumber( 0, 2 );
                    Vit += Utils.GenerateRandomNumber( 1, 1 );
                    Wis += Utils.GenerateRandomNumber( 0, 2 );
                    break;
                #endregion

                #region Knight
                case Class.Knight:
                    HP += Utils.GenerateRandomNumber( 20, 30 );
                    MP += Utils.GenerateRandomNumber( 2, 8 );
                    Atk += Utils.GenerateRandomNumber( 1, 2 );
                    Spd += Utils.GenerateRandomNumber( 0, 2 );
                    Dex += Utils.GenerateRandomNumber( 0, 2 );
                    Vit += Utils.GenerateRandomNumber( 1, 1 );
                    Wis += Utils.GenerateRandomNumber( 0, 2 );
                    break;
                #endregion

                #region Paladin
                case Class.Paladin:
                    HP += Utils.GenerateRandomNumber( 20, 30 );
                    MP += Utils.GenerateRandomNumber( 2, 18 );
                    Atk += Utils.GenerateRandomNumber( 1, 2 );
                    Spd += Utils.GenerateRandomNumber( 0, 2 );
                    Dex += Utils.GenerateRandomNumber( 0, 2 );
                    Vit += Utils.GenerateRandomNumber( 0, 1 );
                    Wis += Utils.GenerateRandomNumber( 1, 2 );
                    break;
                #endregion

                #region Assassin
                case Class.Assassin:
                    HP += Utils.GenerateRandomNumber( 20, 30 );
                    MP += Utils.GenerateRandomNumber( 2, 8 );
                    Atk += Utils.GenerateRandomNumber( 0, 2 );
                    Spd += Utils.GenerateRandomNumber( 1, 2 );
                    Dex += Utils.GenerateRandomNumber( 1, 2 );
                    Vit += Utils.GenerateRandomNumber( 0, 1 );
                    Wis += Utils.GenerateRandomNumber( 1, 2 );
                    break;
                #endregion

                #region Necromancer
                case Class.Necromancer:
                    HP += Utils.GenerateRandomNumber( 20, 30 );
                    MP += Utils.GenerateRandomNumber( 5, 15 );
                    Atk += Utils.GenerateRandomNumber( 1, 2 );
                    Spd += Utils.GenerateRandomNumber( 0, 2 );
                    Dex += Utils.GenerateRandomNumber( 1, 2 );
                    Vit += Utils.GenerateRandomNumber( 0, 1 );
                    Wis += Utils.GenerateRandomNumber( 1, 2 );
                    break;
                #endregion

                #region Huntress
                case Class.Huntress:
                    HP += Utils.GenerateRandomNumber( 20, 30 );
                    MP += Utils.GenerateRandomNumber( 2, 8 );
                    Atk += Utils.GenerateRandomNumber( 1, 2 );
                    Spd += Utils.GenerateRandomNumber( 0, 2 );
                    Dex += Utils.GenerateRandomNumber( 0, 2 );
                    Vit += Utils.GenerateRandomNumber( 0, 1 );
                    Wis += Utils.GenerateRandomNumber( 0, 2 );
                    break;
                #endregion

                #region Mystic
                case Class.Mystic:
                    HP += Utils.GenerateRandomNumber( 20, 30 );
                    MP += Utils.GenerateRandomNumber( 5, 15 );
                    Atk += Utils.GenerateRandomNumber( 1, 2 );
                    Spd += Utils.GenerateRandomNumber( 0, 2 );
                    Dex += Utils.GenerateRandomNumber( 0, 2 );
                    Vit += Utils.GenerateRandomNumber( 0, 1 );
                    Wis += Utils.GenerateRandomNumber( 1, 2 );
                    break;
                #endregion

                #region Trickster
                case Class.Trickster:
                    HP += Utils.GenerateRandomNumber( 20, 30 );
                    MP += Utils.GenerateRandomNumber( 2, 8 );
                    Atk += Utils.GenerateRandomNumber( 1, 2 );
                    Spd += Utils.GenerateRandomNumber( 1, 2 );
                    Dex += Utils.GenerateRandomNumber( 1, 2 );
                    Vit += Utils.GenerateRandomNumber( 0, 1 );
                    Wis += Utils.GenerateRandomNumber( 0, 2 );
                    break;
                #endregion

                #region Sorcerer
                case Class.Sorcerer:
                    HP += Utils.GenerateRandomNumber( 20, 30 );
                    MP += Utils.GenerateRandomNumber( 5, 15 );
                    Atk += Utils.GenerateRandomNumber( 1, 2 );
                    Spd += Utils.GenerateRandomNumber( 1, 2 );
                    Dex += Utils.GenerateRandomNumber( 0, 2 );
                    Vit += Utils.GenerateRandomNumber( 1, 2 );
                    Wis += Utils.GenerateRandomNumber( 1, 2 );
                    break;
                #endregion

                #region Ninja
                case Class.Ninja:
                    HP += Utils.GenerateRandomNumber( 20, 30 );
                    MP += Utils.GenerateRandomNumber( 2, 8 );
                    Atk += Utils.GenerateRandomNumber( 1, 2 );
                    Spd += Utils.GenerateRandomNumber( 0, 2 );
                    Dex += Utils.GenerateRandomNumber( 1, 2 );
                    Vit += Utils.GenerateRandomNumber( 0, 1 );
                    Wis += Utils.GenerateRandomNumber( 1, 2 );
                    break;
                #endregion

                #region Samurai
                case Class.Samurai:
                    HP += Utils.GenerateRandomNumber( 20, 30 );
                    MP += Utils.GenerateRandomNumber( 2, 8 );
                    Atk += Utils.GenerateRandomNumber( 1, 2 );
                    Spd += Utils.GenerateRandomNumber( 0, 2 );
                    Dex += Utils.GenerateRandomNumber( 0, 2 );
                    Vit += Utils.GenerateRandomNumber( 0, 1 );
                    Wis += Utils.GenerateRandomNumber( 1, 2 );
                    break;
                #endregion

                default:
                    break;
            }
        }

        public void LoadInitialStats(Class cl )
        {
            switch ( cl )
            {

                //TODO: Assignt all stats with the official start stats from realmeye

                #region rogue
                case Class.Rogue:
                    MaxHP = 720;
                    MaxMP = 252;
                    MaxAtk = 50;
                    MaxDef = 25;
                    MaxSpd = 75;
                    MaxDex = 75;
                    Maxvit = 40;
                    MaxWis = 50;

                    HP = 150;
                    MP = 100;
                    Def = 0;
                    Atk = 10;
                    Spd = 15;
                    Dex = 15;
                    Vit = 15;
                    Wis = 10;

                    break;

                #endregion

                #region archer
                case Class.Archer:
                    MaxHP = 700;
                    MaxMP = 252;
                    MaxAtk = 75;
                    MaxDef = 25;
                    MaxSpd = 50;
                    MaxDex = 50;
                    Maxvit = 40;
                    MaxWis = 50;

                    HP = 130;
                    MP = 100;
                    Def = 0;
                    Atk = 10;
                    Spd = 12;
                    Dex = 12;
                    Vit = 12;
                    Wis = 10;

                    break;

                #endregion

                #region wizard
                case Class.Wizard:
                    MaxHP = 670;
                    MaxMP = 385;
                    MaxAtk = 75;
                    MaxDef = 25;
                    MaxSpd = 50;
                    MaxDex = 75;
                    Maxvit = 40;
                    MaxWis = 60;

                    HP = 150;
                    MP = 100;
                    Def = 0;
                    Atk = 10;
                    Spd = 15;
                    Dex = 15;
                    Vit = 15;
                    Wis = 10;

                    break;

                #endregion

                #region priest
                case Class.Priest:
                    MaxHP = 670;
                    MaxMP = 385;
                    MaxAtk = 50;
                    MaxDef = 25;
                    MaxSpd = 55;
                    MaxDex = 55;
                    Maxvit = 40;
                    MaxWis = 75;

                    HP = 150;
                    MP = 100;
                    Def = 0;
                    Atk = 10;
                    Spd = 15;
                    Dex = 15;
                    Vit = 15;
                    Wis = 10;

                    break;

                #endregion

                #region warrior
                case Class.Warrior:
                    MaxHP = 770;
                    MaxMP = 252;
                    MaxAtk = 75;
                    MaxDef = 25;
                    MaxSpd = 50;
                    MaxDex = 50;
                    Maxvit = 75;
                    MaxWis = 50;

                    HP = 150;
                    MP = 100;
                    Def = 0;
                    Atk = 10;
                    Spd = 15;
                    Dex = 15;
                    Vit = 15;
                    Wis = 10;

                    break;

                #endregion

                #region knight
                case Class.Knight:
                    MaxHP = 770;
                    MaxMP = 252;
                    MaxAtk = 50;
                    MaxDef = 40;
                    MaxSpd = 50;
                    MaxDex = 50;
                    Maxvit = 75;
                    MaxWis = 50;

                    HP = 150;
                    MP = 100;
                    Def = 0;
                    Atk = 10;
                    Spd = 15;
                    Dex = 15;
                    Vit = 15;
                    Wis = 10;

                    break;
                #endregion

                #region paladin
                case Class.Paladin:
                    MaxHP = 770;
                    MaxMP = 252;
                    MaxAtk = 50;
                    MaxDef = 30;
                    MaxSpd = 55;
                    MaxDex = 50;
                    Maxvit = 40;
                    MaxWis = 75;

                    HP = 150;
                    MP = 100;
                    Def = 0;
                    Atk = 10;
                    Spd = 15;
                    Dex = 15;
                    Vit = 15;
                    Wis = 10;

                    break;
                #endregion

                #region assassin
                case Class.Assassin:
                    MaxHP = 720;
                    MaxMP = 252;
                    MaxAtk = 60;
                    MaxDef = 25;
                    MaxSpd = 75;
                    MaxDex = 75;
                    Maxvit = 40;
                    MaxWis = 60;

                    HP = 150;
                    MP = 100;
                    Def = 0;
                    Atk = 10;
                    Spd = 15;
                    Dex = 15;
                    Vit = 15;
                    Wis = 10;

                    break;

                #endregion

                #region necromancer
                case Class.Necromancer:
                    MaxHP = 670;
                    MaxMP = 385;
                    MaxAtk = 75;
                    MaxDef = 25;
                    MaxSpd = 50;
                    MaxDex = 60;
                    Maxvit = 30;
                    MaxWis = 75;

                    HP = 150;
                    MP = 100;
                    Def = 0;
                    Atk = 10;
                    Spd = 15;
                    Dex = 15;
                    Vit = 15;
                    Wis = 10;

                    break;

                #endregion

                #region huntress
                case Class.Huntress:
                    MaxHP = 700;
                    MaxMP = 252;
                    MaxAtk = 75;
                    MaxDef = 25;
                    MaxSpd = 50;
                    MaxDex = 50;
                    Maxvit = 40;
                    MaxWis = 50;

                    HP = 150;
                    MP = 100;
                    Def = 0;
                    Atk = 10;
                    Spd = 15;
                    Dex = 15;
                    Vit = 15;
                    Wis = 10;

                    break;

                #endregion

                #region mystic
                case Class.Mystic:
                    MaxHP = 670;
                    MaxMP = 385;
                    MaxAtk = 60;
                    MaxDef = 25;
                    MaxSpd = 60;
                    MaxDex = 55;
                    Maxvit = 40;
                    MaxWis = 75;

                    HP = 150;
                    MP = 100;
                    Def = 0;
                    Atk = 10;
                    Spd = 15;
                    Dex = 15;
                    Vit = 15;
                    Wis = 10;

                    break;

                #endregion

                #region trickster
                case Class.Trickster:
                    MaxHP = 720;
                    MaxMP = 252;
                    MaxAtk = 65;
                    MaxDef = 25;
                    MaxSpd = 75;
                    MaxDex = 75;
                    Maxvit = 40;
                    MaxWis = 60;

                    HP = 150;
                    MP = 100;
                    Def = 0;
                    Atk = 10;
                    Spd = 15;
                    Dex = 15;
                    Vit = 15;
                    Wis = 10;

                    break;

                #endregion

                #region sorcerer
                case Class.Sorcerer:
                    MaxHP = 670;
                    MaxMP = 385;
                    MaxAtk = 40;
                    MaxDef = 25;
                    MaxSpd = 60;
                    MaxDex = 60;
                    Maxvit = 75;
                    MaxWis = 60;

                    HP = 150;
                    MP = 100;
                    Def = 0;
                    Atk = 10;
                    Spd = 15;
                    Dex = 15;
                    Vit = 15;
                    Wis = 10;

                    break;

                #endregion

                #region ninja(fuck you flux)
                case Class.Ninja:
                    MaxHP = 720;
                    MaxMP = 252;
                    MaxAtk = 70;
                    MaxDef = 25;
                    MaxSpd = 60;
                    MaxDex = 70;
                    Maxvit = 40;
                    MaxWis = 70;

                    HP = 150;
                    MP = 100;
                    Def = 0;
                    Atk = 10;
                    Spd = 15;
                    Dex = 15;
                    Vit = 15;
                    Wis = 10;

                    break;

                #endregion

                #region MyRegion samurai
                case Class.Samurai:
                    MaxHP = 720;
                    MaxMP = 252;
                    MaxAtk = 75;
                    MaxDef = 25;
                    MaxSpd = 50;
                    MaxDex = 50;
                    Maxvit = 40;
                    MaxWis = 60;

                    HP = 150;
                    MP = 100;
                    Def = 0;
                    Atk = 10;
                    Spd = 15;
                    Dex = 15;
                    Vit = 15;
                    Wis = 10;

                    break;

                #endregion

                default:
                    break;
            }
        }

    }

    public enum Class
    {
        Rogue,
        Archer,
        Wizard,
        Priest,
        Warrior,
        Knight,
        Paladin,
        Assassin,
        Necromancer,
        Huntress,
        Mystic,
        Trickster,
        Sorcerer,
        Ninja,
        Samurai

    }
}
