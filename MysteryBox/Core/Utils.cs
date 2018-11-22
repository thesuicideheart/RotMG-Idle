using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MysteryBox.Core
{
    public class Utils
    {

        static int i = 0;
        static int val = 0;
        public static int Odds(int Min, int Max, int OddsMin)
        {
            if (i < OddsMin) { val = Min; i++; } else i++; // Min show up OddsMin times before every GO has the same probability of showing up 
            if (i >= OddsMin) { val = GenerateRandomNumber(Min, Max + 1); } // Add + 1 so max is included // same probability
            if (val == Max) { i = 0; } // if max reset and start again
            return val;
        }

        private static readonly RNGCryptoServiceProvider _generator = new RNGCryptoServiceProvider();

        public static int GenerateRandomNumber(int min, int max)
        {

            byte[] randomNumber = new byte[1];

            _generator.GetBytes(randomNumber);

            double asciiValueOfRandomCharacter = Convert.ToDouble(randomNumber[0]);

            // We are using Math.Max, and substracting 0.00000000001,
            // to ensure "multiplier" will always be between 0.0 and .99999999999
            // Otherwise, it's possible for it to be "1", which causes problems in our rounding.
            double multiplier = Math.Max(0, (asciiValueOfRandomCharacter / 255d) - 0.00000000001d);

            // We need to add one to the range, to allow for the rounding done with Math.Floor
            int range = max - min + 1;

            double randomValueInRange = Math.Floor(multiplier * range);

            return (int)(min + randomValueInRange);
        }
    }
}
