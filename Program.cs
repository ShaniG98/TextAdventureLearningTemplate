using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMPLib;
//Shani Gohar - Text Adventure Template
// Credit for sound : zapsplat.com
// CREDIT for ascii text and art: https://patorjk.com/ & textart.sh 
// TO DO & Future improvement ideas:
// 1. Finish Route 4
// 2. Rework print function
// 3. Formatting
// 4. Finish refactoring, tidying up and commenting code
// 5. Add more chances of surviving Guard encounters
// 6. Add a minigame
// 7. Puzzle? - Code to get into infirmary?
namespace TextAdventure
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Prison Escape: Text Adventure";
            WindowsMediaPlayer wplayer = new WindowsMediaPlayer
            {
                URL = "textAdventureBG19mins.mp3"
            };
            wplayer.controls.play();
            GameTitle();
        }

        public static void GameTitle()
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Console.SetWindowPosition(0, 0);
            VisualController.ClearScreen();
            VisualController.SetColour();
            Console.WriteLine(@"
 _______  _______ _________ _______  _______  _          _______  _______  _______  _______  _______  _______ 
(  ____ )(  ____ )\__   __/(  ____ \(  ___  )( (    /|  (  ____ \(  ____ \(  ____ \(  ___  )(  ____ )(  ____ \
| (    )|| (    )|   ) (   | (    \/| (   ) ||  \  ( |  | (    \/| (    \/| (    \/| (   ) || (    )|| (    \/
| (____)|| (____)|   | |   | (_____ | |   | ||   \ | |  | (__    | (_____ | |      | (___) || (____)|| (__    
|  _____)|     __)   | |   (_____  )| |   | || (\ \) |  |  __)   (_____  )| |      |  ___  ||  _____)|  __)   
| (      | (\ (      | |         ) || |   | || | \   |  | (            ) || |      | (   ) || (      | (      
| )      | ) \ \_____) (___/\____) || (___) || )  \  |  | (____/\/\____) || (____/\| )   ( || )      | (____/\
|/       |/   \__/\_______/\_______)(_______)|/    )_)  (_______/\_______)(_______/|/     \||/       (_______/
                                                                                                              
");
            Console.WriteLine("Welcome to Prison Escape!" + "\n" +
                "Will you manage to break out? Will you make things worse?" + "\n" + "\n" +
                "Only time will tell!" + "\n" + "Press any key when you are ready to " +
                "begin your adventure");
            Console.ReadKey();
            VisualController.ClearScreen();
            Console.WriteLine("What is your name?");
            string name = Console.ReadLine().ToLower();
            if (name == "shani")
            {
                Console.WriteLine(@"
 _______  _______  _______  ______     _                 _______  _          _______           _______  _       _________
(  ____ \(  ___  )(  ___  )(  __  \   ( \      |\     /|(  ____ \| \    /\  (  ____ \|\     /|(  ___  )( (    /|\__   __/
| (    \/| (   ) || (   ) || (  \  )  | (      | )   ( || (    \/|  \  / /  | (    \/| )   ( || (   ) ||  \  ( |   ) (   
| |      | |   | || |   | || |   ) |  | |      | |   | || |      |  (_/ /   | (_____ | (___) || (___) ||   \ | |   | |   
| | ____ | |   | || |   | || |   | |  | |      | |   | || |      |   _ (    (_____  )|  ___  ||  ___  || (\ \) |   | |   
| | \_  )| |   | || |   | || |   ) |  | |      | |   | || |      |  ( \ \         ) || (   ) || (   ) || | \   |   | |   
| (___) || (___) || (___) || (__/  )  | (____/\| (___) || (____/\|  /  \ \  /\____) || )   ( || )   ( || )  \  |___) (___
(_______)(_______)(_______)(______/   (_______/(_______)(_______/|_/    \/  \_______)|/     \||/     \||/    )_)\_______/
                                                                                                                         
");
            }
            else
            {
                Console.WriteLine("It doesn't matter who you were, here you're just:");
                Console.WriteLine(@"
 _______  _______ _________ _______  _______  _        _______  _______    _______     ___    _______   _____   _______  ______  
(  ____ )(  ____ )\__   __/(  ____ \(  ___  )( (    /|(  ____ \(  ____ )  (  __   )   /   )  (  ____ \ / ___ \ / ___   )/ ___  \ 
| (    )|| (    )|   ) (   | (    \/| (   ) ||  \  ( || (    \/| (    )|  | (  )  |  / /) |  | (    \/( (___) )\/   )  |\/   \  \
| (____)|| (____)|   | |   | (_____ | |   | ||   \ | || (__    | (____)|  | | /   | / (_) (_ | (____   \     /     /   )   ___) /
|  _____)|     __)   | |   (_____  )| |   | || (\ \) ||  __)   |     __)  | (/ /) |(____   _)(_____ \  / ___ \   _/   /   (___ ( 
| (      | (\ (      | |         ) || |   | || | \   || (      | (\ (     |   / | |     ) (        ) )( (   ) ) /   _/        ) \
| )      | ) \ \_____) (___/\____) || (___) || )  \  || (____/\| ) \ \__  |  (__) |     | |  /\____) )( (___) )(   (__/\/\___/  /
|/       |/   \__/\_______/\_______)(_______)|/    )_)(_______/|/   \__/  (_______)     (_)  \______/  \_____/ \_______/\______/ 
                                                                                                                                 
 _______  _______  _______  ______     _                 _______  _        _                                                     
(  ____ \(  ___  )(  ___  )(  __  \   ( \      |\     /|(  ____ \| \    /\( )                                                    
| (    \/| (   ) || (   ) || (  \  )  | (      | )   ( || (    \/|  \  / /| |                                                    
| |      | |   | || |   | || |   ) |  | |      | |   | || |      |  (_/ / | |                                                    
| | ____ | |   | || |   | || |   | |  | |      | |   | || |      |   _ (  | |                                                    
| | \_  )| |   | || |   | || |   ) |  | |      | |   | || |      |  ( \ \ (_)                                                    
| (___) || (___) || (___) || (__/  )  | (____/\| (___) || (____/\|  /  \ \ _                                                     
(_______)(_______)(_______)(______/   (_______/(_______)(_______/|_/    \/(_)                                                    
                                                                                                                                 
");
            }
            VisualController.Continue();
            FirstAct();
        }
        public static void CompanionChoice(string Etime, bool IsAlone)
        {
            Console.WriteLine("Felix isn't his usual chatty self." + "\n" +
                "Are you going to escape alone or with Felix?" +  "\n");
            VisualController.SetDecisionColour();
            Console.WriteLine("1. Alone." + "\n" + "2. With Felix." + "\n");
            Console.Write("Choice: ");
            string choice = Console.ReadLine().ToLower();
            VisualController.SetColour();
            if ((choice == "1") || (choice == "alone"))
            {
                IsAlone = true;
                Console.WriteLine("\n" + "You think it's best to go solo!" +
                    "\n" + "It's almost " + Etime);
                VisualController.Continue();
                SecondAct(Etime, IsAlone);
            }
            else if ((choice == "2") || (choice == "with felix") || (choice == "felix"))
            {
                IsAlone = false;
                Console.WriteLine("\n"+"You trust Felix! Two heads are better than one." + "\n"
                    + "As the guard leaves you turn to Felix, " + "thinking carefully, " +
                    "before you reveal your plan to leave during " + Etime +".");
                if (ChanceSystem.BetrayalChance(10) == true)
                {
                    VisualController.Continue();
                    VisualController.SetLossColour();
                    Console.WriteLine("Perhaps you should've thought this through." +
                        "\n" + "Felix sells you out to the guards for some " +
                        "burgers, fries and a shake.");
                    VisualController.Continue();
                    Program.GameOver();

                }
                else
                {
                    Console.WriteLine("\n" + "Felix is surprised that someone is even thinking of breaking out of this joint, " +
                        "as it's the easiest time he has ever done." + "\n" +
                        "But he's willing to tag along and assist in any way he can.");
                    VisualController.Continue();
                    SecondAct(Etime, IsAlone);
                }
            }
            else
            {
                Console.WriteLine("Unknown choice, try again");
                VisualController.Continue();
                CompanionChoice(Etime, IsAlone);
            }
        }
        public static void FirstAct()
        {
            string choice;
            bool IsAlone = true;

            VisualController.ClearScreen();
            VisualController.SetColour();
        

            Console.WriteLine(@"▓▓▓▓▓▓▓▓▓▓████████▓▓▓▓▒▒▒▒▒▒▓▓▒▒▓▓▓▓▓▓▓▓▒▒▒▒▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓▒▒▒▒▒▒▓▓░░░░▒▒░░░░░░▓▓░░░░░░▒▒░░░░░░▓▓░░▒▒▒▒▓▓▒▒▒▒▒▒▓▓▒▒▒▒▒▒▓▓▓▓████▓▓██▓▓▒▒▓▓██
▓▓▓▓▓▓▓▓▓▓▓▓▓▓██████▓▓▓▓▒▒▒▒▓▓▒▒▓▓▓▓▓▓▓▓▒▒▒▒▓▓▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░▒▒▒▒▓▓▒▒▒▒▒▒▓▓▒▒▒▒▓▓▓▓████▓▓▓▓▓▓▓▓▒▒▓▓▓▓
▓▓▓▓▓▓▓▓▓▓▓▓▓▓██████▓▓▓▓▓▓▒▒▓▓▒▒▓▓▓▓▓▓▓▓▒▒▒▒▓▓▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▓▓▒▒▒▒▒▒▓▓▒▒▓▓▓▓▓▓████▓▓▓▓██▓▓▒▒▓▓▓▓
▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓██▓▓██▓▓▓▓▒▒▒▒▓▓▓▓▓▓▓▓▒▒▒▒▓▓▒▒▒▒▒▒▓▓▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒██▒▒▒▒▓▓▓▓▒▒▒▒▒▒▓▓▒▒▓▓▒▒▓▓██████▓▓▓▓▓▓▓▓▓▓██▓▓▒▒▓▓██
▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓████▓▓▓▓▒▒▓▓▓▓▓▓▓▓▒▒▒▒▓▓▒▒▒▒▒▒▓▓▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▓▓▒▒▒▒▒▒▓▓▒▒▒▒▓▓▓▓████▓▓▓▓▓▓██▒▒▓▓██▓▓▒▒▓▓██
▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓██████▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▓▓▒▒▒▒▒▒▓▓▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▓▓▒▒▒▒▒▒▓▓▒▒▓▓██▓▓██▓▓▓▓▓▓▓▓▓▓▓▓▓▓██▓▓▒▒▓▓██
▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓██▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▓▓▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓
▓▓▓▓▓▓▓▓▓▓▓▓██▓▓▓▓▓▓▓▓▓▓▓▓██▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓██▓▓▓▓▓▓▓▓▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▓▓▒▒▒▒▓▓██▓▓▓▓██████▓▓▓▓██▓▓██▓▓██████▒▒██▓▓
██▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▓▓▒▒▓▓▓▓██▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▓▓▒▒▒▒▒▒▓▓▒▒▓▓██▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓██▓▓▒▒▓▓▓▓
▓▓██▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▓▓▒▒▓▓▓▓██▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▓▓▒▒▒▒▒▒▓▓▒▒▓▓██▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓██▓▓▒▒▓▓▓▓
▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▓▓▒▒▓▓▓▓▓▓▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▓▓▒▒▒▒▒▒▓▓▓▓▓▓██▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓██▓▓▓▓▓▓██
▓▓▓▓▓▓▓▓████▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▓▓▒▒▓▓▓▓████▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▓▓▒▒▒▒▒▒▓▓▓▓▓▓██▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓██▓▓▒▒▓▓▓▓
▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓██▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▓▓▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▓▓▒▒▒▒▓▓▒▒▓▓▓▓▒▒▒▒▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▓▓▓▓▓▓██▓▓▓▓▓▓▓▓▓▓▓▓██▓▓▓▓██▓▓▒▒▓▓▓▓
▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▓▓▒▒▓▓▓▓▓▓▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒██▒▒▓▓▓▓██▒▒▒▒▒▒▓▓▓▓▓▓██▓▓▓▓██▓▓▓▓▓▓██▓▓▓▓██▓▓▒▒▓▓██
▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▓▓▒▒▓▓▓▓▓▓▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▓▓▒▒▒▒▒▒▓▓▓▓▓▓██▓▓▓▓██▓▓▓▓▓▓██▓▓▓▓██▓▓▓▓▓▓▓▓
▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▓▓▒▒▓▓▓▓▓▓▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▓▓▒▒▒▒▒▒▓▓▓▓▓▓██▓▓▓▓██▓▓▓▓▓▓▓▓▓▓▓▓██▓▓▓▓▓▓▓▓
▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▓▓▒▒▓▓▓▓▓▓▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▓▓▒▒▒▒▓▓▓▓▓▓▓▓██▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓██▓▓▓▓▓▓▒▒
▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▓▓▒▒▓▓▓▓▓▓▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▓▓▒▒▓▓▓▓▓▓▓▓▓▓██▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓████▓▓▓▓▓▓
▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▓▓▒▒▓▓▓▓▓▓▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▓▓▒▒▓▓▓▓▓▓▓▓▓▓██▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓██▓▓▓▓▓▓▓▓▒▒
▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▓▓▒▒▓▓▓▓▓▓▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▓▓▒▒▓▓▓▓▓▓▓▓▓▓██▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓██▓▓▓▓▓▓▓▓
▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓
▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓██▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▓▓▓▓▓▓▒▒▒▒▒▒▓▓▓▓▓▓▓▓██▓▓▓▓██▓▓▓▓▓▓▓▓████▓▓▓▓██▓▓▓▓██▓▓▓▓▓▓██▓▓▓▓▓▓██▓▓▓▓████▓▓██▓▓▓▓▓▓▓▓▓▓██████▓▓██▓▓
▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▓▓▓▓▓▓▓▓▓▓▒▒▓▓▓▓▒▒▒▒▓▓▒▒▒▒██▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓██▓▓▓▓██▓▓▓▓▓▓▓▓▓▓▓▓████▓▓▓▓▓▓
▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▓▓▓▓▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▓▓▓▓▓▓▓▓▒▒▓▓██▓▓▓▓▓▓▓▓▓▓▓▓██▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓████▓▓▓▓▓▓
▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▓▓▓▓▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▓▓▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓██▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓████▓▓▓▓▓▓
▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▓▓▓▓▓▓▒▒▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓██▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓████▓▓▓▓▓▓
▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▓▓██▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓██▓▓▓▓██▓▓▓▓▓▓██▓▓▓▓████▓▓▓▓▓▓
▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▓▓▒▒██▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓████▓▓▓▓▓▓
▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▓▓▒▒▓▓▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓████▓▓▓▓▓▓
▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▓▓▓▓▓▓▓▓▓▓▓▓██▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▓▓▒▒▓▓▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓██▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓██▓▓▓▓▓▓
▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓██▓▓▓▓▓▓██▓▓▓▓██▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓██▓▓██▓▓▓▓▓▓
▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▓▓▒▒▒▒██▒▒▒▒▓▓▒▒▒▒▓▓▓▓▒▒██▓▓██▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓██▓▓██▓▓▓▓▓▓▓▓██▓▓▓▓▓▓▓▓▓▓▓▓▓▓
▓▓▓▓▓▓▓▓▓▓▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▓▓▒▒▓▓▓▓██▓▓▓▓▓▓▓▓██▓▓▓▓▓▓▓▓▓▓▓▓██▓▓▓▓▓▓▓▓▓▓▓▓██▓▓██████▓▓▓▓▓▓
▓▓▓▓▓▓▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓██▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▓▓▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓██▓▓▓▓▓▓▓▓▓▓▓▓██▓▓▓▓▓▓▓▓▓▓▓▓██▓▓██▓▓██▓▓██▓▓
▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓██▓▓▒▒▓▓▓▓▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▓▓▒▒██▓▓██▓▓▓▓██▓▓██▓▓▓▓▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓
▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓██▓▓▒▒▓▓▓▓▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▓▓▒▒██▓▓██▓▓▓▓██▓▓██▓▓▓▓▓▓██▓▓▓▓▓▓██▓▓██▓▓██▓▓██▓▓██▓▓██▓▓██▓▓
▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓██▓▓▓▓▓▓██▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓██████▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓██▓▓▓▓▓▓▓▓▓▓██▓▓▓▓▓▓██▓▓▓▓▓▓██▓▓▓▓▓▓██▓▓██▓▓▓▓▓▓██████▓▓██▓▓▓▓▓▓
▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▓▓▓▓▓▓▓▓▓▓██▒▒▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▒▒▒▒██▓▓▒▒▓▓▒▒▓▓▓▓▒▒▒▒▒▒▒▒▒▒▓▓▓▓▒▒██▒▒▓▓██▓▓▓▓▓▓██▓▓▓▓▓▓▓▓▓▓▓▓██▓▓▓▓▓▓▓▓▓▓▓▓████▓▓▓▓██▓▓▓▓▓▓
██▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▓▓▒▒▒▒▒▒▓▓▒▒▒▒▓▓▒▒░░░░░░▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▓▓▓▓▒▒▓▓▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓██████▓▓▓▓▓▓▓▓▓▓████▓▓██▓▓▓▓▓▓
▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▓▓▓▓▒▒▒▒▒▒██▒▒▒▒▒▒▒▒░░░░▒▒░░░░░░░░██▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓██▓▓▓▓▓▓██▓▓▓▓▓▓██▓▓▓▓██▓▓██▓▓▓▓▓▓▓▓▓▓██▓▓▓▓██▓▓██▓▓
▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░░░░░██░░░░▒▒▒▒░░░░▓▓░░░░  ░░██▓▓▓▓▓▓▒▒▓▓▓▓▓▓▓▓██▓▓▓▓██▓▓▓▓██▓▓▓▓██▓▓▓▓▓▓██▓▓▓▓▓▓▓▓▓▓▓▓██▓▓████▓▓██▓▓▓▓▓▓▓▓▓▓██▓▓██▓▓
▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▓▓░░░░░░██░░▒▒▒▒▒▒░░░░▒▒░░░░  ░░██▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▓▓▓▓▒▒▓▓▓▓▓▓██▓▓▓▓██▓▓▓▓▓▓██▓▓▓▓▓▓██▓▓▓▓████████▓▓██▓▓████▓▓▓▓██████▓▓
▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒░░░░▓▓░░░░░░██▒▒░░░░▒▒░░░░▒▒░░░░░░██▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓██▓▓▓▓▓▓██▓▓▓▓▓▓▓▓▓▓▓▓████▓▓████▓▓▓▓██████▓▓▓▓██▓▓▓▓
▓▓▓▓▓▓▓▓▓▓▓▓▒▒▓▓      ▒▒      ██    ░░▒▒        ░░░░██▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓██▓▓▓▓████▓▓▓▓▓▓██▓▓▓▓▓▓▓▓████▓▓▓▓▓▓████▓▓██████▓▓▓▓
▓▓▓▓▓▓▓▓▓▓▓▓░░▓▓      ▒▒      ██      ▒▒          ▒▒██▓▓▓▓▓▓▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓▓▓▓▓████▒▒▒▒▒▒▓▓▒▒▒▒▓▓▓▓▓▓██▓▓▓▓▓▓████▓▓▓▓██████▓▓
▓▓▓▓▓▓▓▓▓▓▓▓▒▒██▒▒▒▒▒▒▓▓▒▒▒▒▒▒▓▓▒▒▒▒░░▓▓▒▒░░▒▒░░  ▓▓▓▓▓▓██▒▒▓▓▒▒▒▒██▒▒▒▒██▒▒▒▒▓▓▒▒▒▒██▒▒▒▒██▒▒▒▒████▒▒▒▒▓▓██▓▓▓▓▓▓██▓▓▓▓▓▓▓▓▓▓████▓▓▓▓██████▒▒
▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▓▓▓▓▓▓▓▓▓▓▒▒▓▓▓▓▓▓▓▓██▓▓██▓▓▓▓▒▒▒▒▒▒▓▓▒▒░░▓▓░░░░██░░░░██░░░░▓▓░░░░██░░░░██▒▒▒▒▓▓▓▓▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓████▓▓▓▓████▓▓▓▓
▓▓▓▓▓▓▓▓▓▓▓▓██▓▓▓▓██▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓██▓▓▓▓▓▓░░░░▓▓░░░░▒▒░░░░▓▓░░  ▓▓    ██░░░░██░░░░██░░░░██▓▓▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒
▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓██░░░░▒▒░░  ▓▓░░  ▓▓    ▓▓    ██░░░░██░░░░▓▓▓▓▓▓▓▓▓▓██████▓▓██▓▓▓▓▓▓████▓▓████▓▓██████▓▓
▓▓▓▓▓▓██▓▓▓▓████████████▓▓▓▓▓▓██▓▓▓▓▓▓██▓▓▓▓▓▓██▓▓▓▓▓▓▓▓░░  ░░░░  ▓▓    ▓▓    ▓▓    ██░░░░██░░░░▓▓▓▓▒▒▒▒▒▒██▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓██▓▓██▓▓██████▓▓
");
            Console.WriteLine("You're fast asleep in your cell." + "\n" +
                "Between your cellmate Felix's snoring, the raging storm outside and the worn nature of the " +
                "mattress, it's a miracle you achieved such a feat... " + "\n" + "\n" +
                "Though it might be a curse." + "\n" + "You find yourself having nightmares of dying old, alone " +
                "and still in prison. The thought of never holding your daughter again terrifies you." + "\n" +
                "You hate that despite staying on the straight and narrow you still wound up here." + "\n" + "\n" +
                "You didn't kill that man. Why does no one believe your innocence?!?!" + "\n" +
                "The image of your grown daughter at your grave is the final straw, you shout out and awake..." + "\n" +
                "\n" + "This is it. Time is up. It's the day you planned on escaping." + "\n" + "It's not long now " +
                "until the morning roll call." + "\n" + "When do you want to try escaping?"
                + "\n" + "\n");
            
            VisualController.SetDecisionColour();
            Console.WriteLine("1. Right now." + "\n" + "2. During leisure time." + "\n" + "3. Tonight!"  + "\n");
            Console.Write("Choice: ");
            //Console.ReadKey();
            choice = Console.ReadLine().ToLower();
            VisualController.ClearScreen();
            VisualController.SetColour();
            string Etime;
            switch (choice)
            {
                case "1":
                case "right now":
                case "now":
                    {
                        if (HailMary.IsSuccess() == true)
                        {
                            Console.WriteLine("You decide you can't wait any longer. It must be your lucky day. A riot breaks out. " +
                                "\n" + "As the prison burns you manage to slip away.");
                            VisualController.Continue();
                            WinScreen();
                        }
                        else
                        {
                            Console.WriteLine("You exit your cell and start making your way down the corridor" + "\n" +
                            "You turn the corner and a guard escorts you back to your cell for roll call.");
                            VisualController.Continue();
                            GameOver();
                        }
                        break;

                    }
                case "2":
                case "leisure":
                case "during leisure time":
                    {
                        Etime = "leisure time";
                        Console.WriteLine("You decide it would be best to escape during leisure time." + "\n" +
                        "As the guards commence roll call, you're standing outside your cell with Felix.");
                        VisualController.Continue();
                        CompanionChoice(Etime, IsAlone);
                        break;
                    }
                case "3":
                case "tonight":
                    {
                        Etime = "the evening";
                        Console.WriteLine("You decide it would be best to escape during the night." + "\n" +
                        "As the guards commence roll call, you're standing outside your cell with Felix.");
                        VisualController.Continue();
                        CompanionChoice(Etime, IsAlone);
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Unrecognised choice.");
                        VisualController.Continue();
                        FirstAct();
                        break;
                    }
            }

        }
        public static void SecondAct(string Etime, bool IsAlone)
        {
            string choice;
            bool HasMoney = true;
            VisualController.ClearScreen();
            VisualController.SetColour();
            Console.WriteLine("Not long now... spend this time wisely." +
                " Do you wish to rest up or prepare for escaping?" + "\n");
            VisualController.SetDecisionColour();

            Console.WriteLine("1. Rest" + "\n" + "2. Prepare" + "\n");
            Console.Write("Choice: ");
            choice = Console.ReadLine().ToLower();
            switch (choice) {
                case "1":
                case "rest":
                    {
                        VisualController.SetLossColour();
                        Console.WriteLine( "\n" + "On your way back to the cell you get introduced to Pope's shiv."
                            + "\n" + "you try to apply pressure but it's too late," +
                            "\n" + "you've already lost too much blood---");
                        VisualController.Continue();
                        GameOver();
                        break;
                    }
                case "2":
                case "prep":
                case "prepare":
                    {
                        VisualController.SetColour();
                        Console.WriteLine("\n" + "You've chosen to prepare, you value readiness and planning");
                        VisualController.Continue();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Unrecognised choice.");
                        VisualController.Continue();
                        SecondAct(Etime, IsAlone);
                        break;
                    }

            }

            EncounterHandler.EncounterCheck(HasMoney, IsAlone);
            FinalAct(Etime, HasMoney, IsAlone);
        }
        public static void FinalAct(string Etime, bool HasMoney, bool IsAlone)
        {
            string choice;
            VisualController.ClearScreen();
            VisualController.SetColour();
            Console.WriteLine("It's finally " + Etime +
                "\n" + "You have two potential routes of escape." + "\n");
            VisualController.SetDecisionColour();
            if (Etime == "leisure time")
            {
                Console.WriteLine("1. SCOFIELD SPECIAL --- Through the infirmary " +
                    "and over the wall!" + "\n" + "2. TUNNEL - under the library." + "\n");
                Console.Write("Choice: ");
                choice = Console.ReadLine().ToLower();
                if ((choice == "1") || (choice == "scofield special") || (choice == "over the wall"))
                {
                    if (IsAlone == false && ChanceSystem.BetrayalChance(15) == true)
                    {
                        VisualController.SetLossColour();
                        Console.WriteLine("\n" + "You shouldn't have trusted Felix." +
                            "\n" + "The second Felix knows the route he decides to turn on you and go alone." +
                            "\n" + "He clocks you in the back of the head, knocking you unconscious.");
                        VisualController.Continue();
                        Program.GameOver();

                    }
                    else
                    {
                        RouteHandler.LeisureRoute1();
                    }
                }
                else if((choice == "2") || (choice == "tunnel") || (choice == "under the library"))
                {
                    if (IsAlone == false && ChanceSystem.BetrayalChance(12) == true)
                    {
                        VisualController.SetLossColour();
                        Console.WriteLine("\n" + "You shouldn't have trusted Felix." +
                            "\n" + "The second Felix knows the route he decides to turn on you and go alone." +
                            "\n" + "He clocks you in the back of the head, knocking you unconscious.");
                        VisualController.Continue();
                        Program.GameOver();

                    }
                    else
                    {
                        RouteHandler.LeisureRoute2();
                    }
                }
                else
                {
                    Console.WriteLine("Unknown choice, try again");
                    VisualController.Continue();
                    FinalAct(Etime, HasMoney, IsAlone);

                }

            }
            else if (Etime == "the evening")
            {
                VisualController.SetDecisionColour();
                Console.WriteLine("1. SCOFIELD SPECIAL --- Through the infirmary " +
                    "and over the wall!" + "\n" + "2. PYSCH WARD " + "\n");
                Console.Write("Choice: ");
                choice = Console.ReadLine().ToLower();
                if ((choice == "1") || (choice == "scofield special") || (choice == "over the wall"))
                {
                    if (IsAlone == false && ChanceSystem.BetrayalChance(15) == true)
                    {
                        VisualController.SetLossColour();
                        Console.WriteLine("\n" + "You shouldn't have trusted Felix." +
                            "\n" + "The second Felix knows the route he decides to turn on you and go alone." +
                            "\n" + "He clocks you in the back of the head, knocking you unconscious");
                        VisualController.Continue();
                        Program.GameOver();

                    }
                    else
                    {
                        RouteHandler.EveningRoute1();
                    }
                }
                else if ((choice == "2") || (choice == "pych") || (choice == "pysch ward"))
                {
                    if (IsAlone == false && ChanceSystem.BetrayalChance(12) == true)
                    {
                        VisualController.SetLossColour();
                        Console.WriteLine("\n" + "You shouldn't have trusted Felix." +
                            "\n" + "The second Felix knows the route he decides to turn on you and go alone." +
                            "\n" + "He clocks you in the back of the head, knocking you unconscious");
                        VisualController.Continue();
                        Program.GameOver();

                    }
                    else
                    {
                        RouteHandler.EveningRoute2();
                    }
                }
                else
                {
                    Console.WriteLine("Unknown choice, try again");
                    VisualController.Continue();
                    FinalAct(Etime, HasMoney, IsAlone);

                }
            }
            VisualController.Continue();
        }

        public static void GameOver()
        {
            VisualController.ClearScreen();
            FileHandler.AddAttempt();
            WindowsMediaPlayer wplayer = new WindowsMediaPlayer
            {
                URL = "gameOver.mp3"
            };
            wplayer.controls.play();
            VisualController.SetLossColour();
            Console.WriteLine("All that scheming amounted to nothing after all."
                + "\n" + "You were unable to escape prison.");
            Console.WriteLine(@"
    _____      ____       __    __      _____       ____    __    __    _____   ______    
   / ___ \    (    )      \ \  / /     / ___/      / __ \   ) )  ( (   / ___/  (   __ \   
  / /   \_)   / /\ \      () \/ ()    ( (__       ( (  ) ) ( (    ) ) ( (__     ) (__) )  
 ( (  ____   ( (__) )     / _  _ \     ) __)      ( (  ) )  \ \  / /   ) __)   (    __/   
 ( ( (__  )   )    (     / / \/ \ \   ( (         ( (  ) )   \ \/ /   ( (       ) \ \  _  
  \ \__/ /   /  /\  \   /_/      \_\   \ \___     ( (__) )    \  /     \ \___  ( ( \ \_)) 
   \____/   /__(  )__\ (/          \)   \____\     \____/      \/       \____\  )_) \__/  
                                                                                          
");
            VisualController.Continue();
            GameTitle();
            //Console.ReadLine();
        }

        public static void WinScreen()
        {
            VisualController.ClearScreen();
            FileHandler.AddAttempt();
            WindowsMediaPlayer wplayer = new WindowsMediaPlayer
            {
                URL = "win.mp3"
            };
            wplayer.controls.play();
            VisualController.SetWinColour();
            Console.WriteLine(@"
 ________  ________  ________   ________  ________  ________  _________  ___  ___  ___       ________  _________  ___  ________  ________   ________      
|\   ____\|\   __  \|\   ___  \|\   ____\|\   __  \|\   __  \|\___   ___\\  \|\  \|\  \     |\   __  \|\___   ___\\  \|\   __  \|\   ___  \|\   ____\     
\ \  \___|\ \  \|\  \ \  \\ \  \ \  \___|\ \  \|\  \ \  \|\  \|___ \  \_\ \  \\\  \ \  \    \ \  \|\  \|___ \  \_\ \  \ \  \|\  \ \  \\ \  \ \  \___|_    
 \ \  \    \ \  \\\  \ \  \\ \  \ \  \  __\ \   _  _\ \   __  \   \ \  \ \ \  \\\  \ \  \    \ \   __  \   \ \  \ \ \  \ \  \\\  \ \  \\ \  \ \_____  \   
  \ \  \____\ \  \\\  \ \  \\ \  \ \  \|\  \ \  \\  \\ \  \ \  \   \ \  \ \ \  \\\  \ \  \____\ \  \ \  \   \ \  \ \ \  \ \  \\\  \ \  \\ \  \|____|\  \  
   \ \_______\ \_______\ \__\\ \__\ \_______\ \__\\ _\\ \__\ \__\   \ \__\ \ \_______\ \_______\ \__\ \__\   \ \__\ \ \__\ \_______\ \__\\ \__\____\_\  \ 
    \|_______|\|_______|\|__| \|__|\|_______|\|__|\|__|\|__|\|__|    \|__|  \|_______|\|_______|\|__|\|__|    \|__|  \|__|\|_______|\|__| \|__|\_________\
                                                                                                                                              \|_________|
                                                                                                                                                          
                                                                                                                                                          
");
            Console.WriteLine("YOU DID IT! YOU'LL BE WITH YOUR DAUGHTER SOON... Stay out of trouble.");
            FileHandler.GetAttempts();
            VisualController.Continue();
            GameTitle();
        }
    }
    }