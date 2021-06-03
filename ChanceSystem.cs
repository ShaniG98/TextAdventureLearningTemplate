using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventure
{
    class ChanceSystem
    {
        public static bool BetrayalChance(int modifier = 0)
        {
            Random rnd = new Random();
            int randomNumber = rnd.Next(1, 100);
            bool GotBetrayed;
            if (randomNumber - modifier <= 50)
            {
                GotBetrayed = true;
            }
            else
            {
                GotBetrayed = false;
            }
            return GotBetrayed;
        }

        public static bool DistractAttempt()
        {
            Random rnd = new Random();
            int randomNumber = rnd.Next(1, 100);
            bool IsSuccess;
            if (randomNumber <= 50)
            {
                IsSuccess = true;
            }
            else
            {
                IsSuccess = false;
            }
            return IsSuccess;
        }

        public static bool BribeAttempt()
        {
            Random rnd = new Random();
            int randomNumber = rnd.Next(1, 100);
            bool IsSuccess;
            if (randomNumber <= 35)
            {
                IsSuccess = true;
            }
            else
            {
                IsSuccess = false;
            }
            return IsSuccess;
        }

        public static bool BargainAttempt()
        {
            Random rnd = new Random();
            int randomNumber = rnd.Next(1, 100);
            bool IsSuccess;
            if (randomNumber <= 40)
            {
                IsSuccess = true;
            }
            else
            {
                IsSuccess = false;
            }
            return IsSuccess;
        }
        public static bool RunAttempt()
        {
            Random rnd = new Random();
            int randomNumber = rnd.Next(1, 100);
            bool IsSuccess;
            if (randomNumber <= 50)
            {
                IsSuccess = true;
            }
            else
            {
                IsSuccess = false;
            }
            return IsSuccess;
        }
    }
}
