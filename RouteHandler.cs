using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WMPLib;

namespace TextAdventure
{
    class RouteHandler
    {
        public static void LeisureRoute1()
        {
            VisualController.SetLossColour();
            WindowsMediaPlayer wplayer = new WindowsMediaPlayer
            {
                URL = "breakWindow.mp3"
            };
            wplayer.controls.play();
            Console.WriteLine("\n" + "You get to the infirmary, when the medical stuff and guards aren't looking" +
                " you smash the window." + "\n" + "The noise alerts everyone." +
                "\n" + "You try to get out to the ledge when a hand seizes your ankle.");
            VisualController.Continue();
            Program.GameOver();
        }
        public static void LeisureRoute2()
        {
            VisualController.SetColour();
            VisualController.ClearScreen();
            Console.WriteLine("You get to the library, the noise of the record player" +
                "\n" + "should give you enough to time to dig under the wall and past the fence." +
                "\n" + "\n" + "You make it past the fence and dig up, coming out in the watch tower's blindspot."
                +"\n" + "Something's WRONG!");

            WindowsMediaPlayer wplayer = new WindowsMediaPlayer
            {
                URL = "siren.mp3"
            };
            wplayer.controls.play();
            
            VisualController.Continue();
            VisualController.SetDecisionColour();
            Console.WriteLine("The getaway van hasn't arrived. What do you do?" + "\n");
           Console.WriteLine("1. Wait for van" +
                    "\n" + "2. Travel on foot - Start running" + "\n");
            Console.Write("Choice: ");
            string choice = Console.ReadLine().ToLower();
            if ((choice == "1") || (choice == "wait") || (choice == "wait for van"))
            {
                VisualController.SetLossColour();

                Console.WriteLine("You duck down and hide out of  view, hoping the hole isn't noticed before the van arrives" +
                    "\n" + "The alarms start blaring. The van doesn't show." +
                    "\n" + "You're surrounded by guards with their guns drawn.");
                VisualController.Continue();
                Program.GameOver();

            }
            else if ((choice == "2") || (choice == "travel on foot") || (choice == "run"))
            {
                VisualController.SetWinColour();
                Console.WriteLine("You run through the woods, the hole is discovered," +
                    " but you manage to sneak aboard a train to freedom.");
                VisualController.Continue();
                Program.WinScreen();
            }
        }
        public static void EveningRoute1()
        {
            VisualController.SetColour();
            WindowsMediaPlayer wplayer = new WindowsMediaPlayer
            {
                URL = "breakWindow.mp3"
            };
            wplayer.controls.play();
            Console.WriteLine("\n" + "You get to the infirmary, the staff have gone home for the night" +
                "\n" + "You manage to break the window without any patrolling guards noticing."
                + "\n" +"\n" + "You make it past the fence and over the wall, " +
          "coming down the other end" + " in the watchtower's blindspot."
                + "\n" + "Something's WRONG!");
            VisualController.Continue();
            
            wplayer.URL = "siren.mp3";
            wplayer.controls.play();
            Console.WriteLine("The getaway van hasn't arrived. What do you do?" + "\n");
            VisualController.SetDecisionColour();
            Console.WriteLine("1. Wait for van." +
                     "\n" + "2. Travel on foot - Start running." + "\n" );
            Console.Write("Choice: ");
            string choice = Console.ReadLine().ToLower();
            if ((choice == "1") || (choice == "wait") || (choice == "wait for van"))
            {
                VisualController.Continue();
                VisualController.SetWinColour();
                Console.WriteLine("You duck down and hide out of view, hoping you aren't noticed before the van arrives" +
                    "\n" + "The alarms start blaring. The guards are closing in on you." +
                    "\n" + "\n"+ "The speeding SUV in the distance is a sweet sight indeed. The driver diverts..." +
                    "\n" + "moving into a more covered position, " +
                    "but staying close enough for you to sneak across and get in");
                VisualController.Continue();
                Program.WinScreen();

            }
            else if ((choice == "2") || (choice == "travel on foot") || (choice == "run"))
            {
                VisualController.SetLossColour();
                Console.WriteLine("You run through the woods," +
                    " but you have barely covered any ground before you start to tire " +
                    "\n" + "as you slow down you are caught by a couple of guards and the " +
                    "search dog accompanying them.");
                wplayer.URL = "dog.mp3";
                wplayer.controls.play();
                VisualController.Continue();
                Program.GameOver();
            }

        }
        public static void EveningRoute2()
        {
            VisualController.SetLossColour();
            Console.WriteLine("You make it to the pysch ward, " +
                "the desk clerk hits the alarm as you are spotted almostly instantly.");
            VisualController.Continue();
            Program.GameOver();
        }
    }
}
