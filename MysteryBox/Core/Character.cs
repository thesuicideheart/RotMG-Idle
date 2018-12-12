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

        public string name;



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
