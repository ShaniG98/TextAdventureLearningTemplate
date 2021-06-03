using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventure
{
    class HailMary
    {
        public static bool IsSuccess()
        {
            Random rnd = new Random();
            int randomNumber = rnd.Next(1, 100);
            bool IsSuccess;
            if (randomNumber <= 5)
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
