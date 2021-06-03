using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventure
{

    class EncounterHandler
    {
        public static void EncounterCheck(bool HasMoney, bool IsAlone)
        {
            Random rnd = new Random();
            string[] rndEncounters = { "guard", "guards", "t-bag", "bogs" };
            int randomNumber = rnd.Next(0, 6);

            if (randomNumber < 4)
            {
                string Enc = rndEncounters[randomNumber];
                EncounterHandler.Encounters(Enc, HasMoney, IsAlone);
            }
            else
            {
                Console.WriteLine("You take some time arranging transport and consider possible routes." +
                    "\n" + "Thankfully no one has paid attention to you since lunch.");
                VisualController.Continue();
            }
        }
        public static void Encounters(string Enc, bool HasMoney, bool IsAlone)
        {
            string Echoice;
            switch (Enc)
            {
                case "guard":
                    {
                        Console.WriteLine("DANGER!"
                            + "\n" + "While preparing you run into a guard," +
                            "think carefully in these next moments.");
                        VisualController.Continue();
                        Console.WriteLine("The guard is suspcious and begins to " +
                            "question you about some rumours of an escape."
                            + "\n" + "What do you do?" + "\n");
                        VisualController.SetDecisionColour();
                        Console.WriteLine("1. Attempt to bribe" + "\n" + "2. Attempt to distract"
                            + "\n" + "3. Lie" + "\n" + "4. Run" + "\n" + "5. Headbutt!!!!" + "\n");
                        Console.Write("Choice: ");
                        Echoice = Console.ReadLine().ToLower();
                        VisualController.Continue();
                        GuardOutcome(Echoice, HasMoney, IsAlone);
                        break;
                    }
                case "guards":
                    {
                        Console.WriteLine("DANGER!"
                            + "\n" + "While preparing you run into 2 guards," +
                            " think carefully in these next moments.");
                        VisualController.Continue();
                        Console.WriteLine("The guards are suspcious and begin to " +
                            "question you about some rumours of an escape."
                        + "\n" + "What do you do?" + "\n");
                        VisualController.SetDecisionColour();
                        Console.WriteLine("1. Attempt to bribe" + "\n" + "2. Attempt to distract"
                            + "\n" + "3. Lie" + "\n" + "4. Run" + "\n" + "5. Headbutt!!!!" + "\n");
                        Console.Write("Choice: ");
                        Echoice = Console.ReadLine().ToLower();
                        VisualController.Continue();
                        GuardsOutcome(Echoice, HasMoney, IsAlone);
                        break;
                    }
                case "t-bag":
                    {
                        Console.WriteLine("DANGER!" + "\n"
                            + "\n" + "T-bag emerges from the corner..." +
                            "\n" + "T-bag: It's first of the month pretty, you still owe me money."
                            + "\n" + "\n" + "Think carefully in these next moments.");
                        VisualController.Continue();
                        Console.WriteLine("T-bag is cold, cunning and erratic. "
                           + "\n" + "What do you do?" + "\n");
                        VisualController.SetDecisionColour();
                        Console.WriteLine("1. Pay him" + "\n" + "2. Attempt to bargain"
                            + "\n" + "3. Lie" + "\n" + "4. Run" + "\n" + "5. Headbutt!!!!" + "\n");
                        Console.Write("Choice: ");
                        Echoice = Console.ReadLine().ToLower();
                        VisualController.Continue();
                        TbagOutcome(Echoice, HasMoney, IsAlone);
                        break;
                    }
                case "bogs":
                    {
                        VisualController.SetLossColour();
                        Console.WriteLine("While looking for some essential items for your escape you run into " +
                            "Bogs." + "\n" + "He's been trying to break your spirit since the beginning of your incarceration."
                            + "\n" + "\n" + "He has decided he's had his share of fun with you.." +
                            "\n" + "His buddies hold you still and as much as you struggle you know this is it." + "\n" +
                            "\n" + "You close your eyes for the very last time.");
                        VisualController.Continue();
                        Program.GameOver();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("You appear to have an Angel on your side.");
                        VisualController.Continue();
                        break;
                    }

            }
        }
        public static void GuardOutcome(string Echoice, bool HasMoney, bool IsAlone)
        {
            switch (Echoice)
            {
                case "1":
                case "bribe":
                case "attempt to bribe":
                    {
                        if (HasMoney == true)
                        {
                            if (ChanceSystem.BribeAttempt() == true)
                            {
                                VisualController.SetColour();
                                Console.WriteLine("SUCCESS: You manage to bribe the guard, using what little money" +
                                    " you have left to ensure he leaves you be.");
                                VisualController.Continue();
                            }
                            else
                            {
                                VisualController.SetLossColour();
                                Console.WriteLine("FAIL: The guard scoffs at your bold assumption he need or wants" +
                                    " your money." + "\n" + "He's definitely going to report your attempted bribery."
                                    + "\n" + "For now you've earned a trip to solitary.");
                                VisualController.Continue();
                                Program.GameOver();
                            }
                        }
                        else
                        {
                            Console.WriteLine("You don't have any money. The guard is aware of this and" +
                           "disciplines you for attempting to bribe");
                            VisualController.Continue();
                            Program.GameOver();
                           
                        }
                        break;
                    }

                case "2":
                case "distract":
                case "attempt to distract":
                    {
                        if (ChanceSystem.DistractAttempt() == true )
                        {
                            VisualController.SetColour();
                            if (IsAlone == false)
                            {
                                Console.WriteLine("You manage to give Felix a signal and he comes to your rescue." +
                                    "\n" + "Felix: 'Come quick boss, Big Andy fainted out in the corridor to B'." + "\n" +
                                    "'Bogs and some of the others were talking about doing him in'."
                                    + "\n" + "'C.O Bob tried to radio you but couldn't get through'.");
                                Console.WriteLine("The guard raises a brow, finding this unlikely," +
                                    " he radios Bob to confirm..."
                                   + "\n" + "'Bob, got a couple of smart asses here who expect me to believe you" + "\n" +
                                   "sent them over to get me instead of pushing a single button'." +
                                   " 'Tell me how full of it they are'."
                                   + "\n" + "\n" + "Bob doesn't respond... The guard makes his way over to him."
                                   + "\n" + "You're relieved but also very confused, you turn to Felix, 'Why didn't Bob answer?'"
                                   + "\n" + "Felix: I saw im' sweatin' an' fidgetin' with his radio during role call, figured he didn't want to fess up"
                                   + "\n" + "on the count of him being new an' all... don't look a gift horse in the mouth buddy."
                                   + "\n" + "Something is o f f about Felix. He's been shaking and jittery all day."
                                   );
                                VisualController.Continue();
                            }
                            else
                            {
                                Console.WriteLine("You decide the best course of action is to distract the guard"
                                + "\n" + "You start looking in the direction of your cell." + "\n"
                                + "The guard decides to inspect it and finds nothing. He figures the rumours were" +
                                " exagerrated and leaves");
                                VisualController.Continue();
                            }
                        }
                        else
                        {
                            VisualController.SetLossColour();
                            Console.WriteLine("You try the first thing that comes to mind, throwing a rolled up paper at a fellow inmate.");
                            Console.WriteLine("It misses and earns you a couple of confused gazes." +
                               "\n" + "The guard grills you until you have a hole in your story.");
                            VisualController.Continue();
                            Program.GameOver();
                        }
                        
                        break;
                    }

                case "3":
                case "lie":
                    {
                        Console.WriteLine("'I dont know nothing about that Chief', you insist." +
                            "\n" + "You're sweating and they see right through you");
                        VisualController.Continue();
                        Program.GameOver();
                        break;
                    }

                case "4":
                case "run":
                    {
                        Console.WriteLine("You run and the guard radio's for backup. You're caught.");
                        VisualController.Continue();
                        Program.GameOver();
                        break;
                    }

                case "5":
                case "headbutt":
                case "headbutt!!!!":
                    {
                        if (HailMary.IsSuccess() == true)
                        {
                            Console.WriteLine("You headbutt the officer, but before he can strike back you trip him." + "\n"
                                + "The guards and inmates both come running, amidst the chaos of flying fists you manage to flee.");
                            VisualController.Continue();
                            Program.GameOver();

                        }
                        else
                        {
                            VisualController.SetLossColour();
                            Console.WriteLine("You headbutted the guard. He beat you to a bloody pulp..." +
                                " you're left clinging to your life " + "\n" + "If you make it you're going to solitary.");
                            VisualController.Continue();
                            Program.GameOver();
                        }
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Unrecognised choice.");
                        VisualController.Continue();
                        Encounters(Echoice, HasMoney, IsAlone);
                        break;
                    }
            }
        }
        public static void GuardsOutcome(string Echoice, bool HasMoney, bool IsAlone)
        {
            switch (Echoice)
            {
                case "1":
                case "bribe":
                case "attempt to bribe":
                    {
                        if (HasMoney == true)
                        {
                            if (ChanceSystem.BribeAttempt() == true)
                            {
                                Console.WriteLine("SUCCESS: You manage to bribe the guards, using what little money" +
                                    " you have left to ensure they leave you be.");
                                VisualController.Continue();
                            }
                            else
                            {
                                Console.WriteLine("FAIL: The guards scoff at your bold assumption that they need or want" +
                                    " your money." + "\n" + "They are definitely going to report your attempted bribery."
                                    + "\n" + "For now you've earned a trip to solitary.");
                                VisualController.Continue();
                                Program.GameOver();
                            }

                        }
                        else
                        {
                            Console.WriteLine("You don't have any money. The guards are aware of this and" +
                           "discipline you for attempting to bribe");
                            VisualController.Continue();
                            Program.GameOver();

                        }
                        break;
                    }

                case "2":
                case "distract":
                case "attempt to distract":
                    {
                        if (ChanceSystem.DistractAttempt() == true)
                        {
                            if (IsAlone == false)
                            {
                                Console.WriteLine("You manage to give Felix a signal and he comes to your rescue." +
                                    "\n" + "Felix: 'Come quick boss, Big Andy fainted out in the corridor to B'." + "\n" +
                                    "'Bogs and some of the others were talking about doing him in'."
                                    + "\n" + "'C.O Bob tried to radio you but couldn't get through'.");
                                Console.WriteLine("The guards raise a brow, finding this unlikely," +
                                    " one of them radios Bob to confirm..."
                                   + "\n" + "'Bob, got a couple of smart asses here who expect me to believe you" + "\n" +
                                   "sent them over to get me instead of pushing a single button'." +
                                   " 'Tell me how full of it they are'."
                                   + "\n" + "\n" + "Bob doesn't respond... The guards make their way over to him."
                                   + "\n" + "You're relieved but also very confused, you turn to Felix, 'Why didn't Bob answer?'"
                                   + "\n" + "Felix: I saw im' sweatin' an' fidgetin' with his radio during role call, figured he didn't want to fess up"
                                   + "\n" + "on the count of him being new an' all... don't look a gift horse in the mouth buddy."
                                   + "\n" + "Something is o f f about Felix. He's been shaking and jittery all day."
                                   );
                                VisualController.Continue();
                            }
                            else
                            {
                                Console.WriteLine("You decide the best course of action is to distract the guards."
                                + "\n" + "You start looking in the direction of your cell." + "\n"
                                + "The guards decide to inspect it and finds nothing. One of them decides the rumours were" +
                                "exagerrated and convinces the other to leave.");
                                VisualController.Continue();
                            }
                        }
                        else
                        {
                            VisualController.SetLossColour();
                            Console.WriteLine("You try the first thing that comes to mind, throwing a rolled up paper at a fellow inmate.");
                            Console.WriteLine("It misses and earns you a couple of confused gazes." +
                               "\n" + "The guards grill you until you have a hole in your story.");
                            VisualController.Continue();
                            Program.GameOver();
                        }
                        break;
                    }

                case "3":
                case "lie":
                    {
                        Console.WriteLine("'I dont know nothing about that Chief', you insist." +
                            "\n" + "You're sweating and they see right through you");
                        VisualController.Continue();
                        Program.GameOver();
                        break;
                    }

                case "4":
                case "run":
                    {
                        Console.WriteLine("You run and the guards corner you. You're caught.");
                        VisualController.Continue();
                        Program.GameOver();
                        break;
                    }

                case "5":
                case "headbutt":
                case "headbutt!!!!":
                    {
                        VisualController.SetLossColour();
                        Console.WriteLine("You headbutted the first guard. The pair beat you to a bloody pulp..." +
                            " you're left clinging to your life " + "\n" + "If you make it you're going to solitary.");
                        VisualController.Continue();
                        Program.GameOver();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Unrecognised choice.");
                        VisualController.Continue();
                        Encounters(Echoice, HasMoney, IsAlone);
                        break;
                    }
            }
        }

        public static void TbagOutcome(string Echoice, bool HasMoney, bool IsAlone)
        {
            switch (Echoice)
            {
                case "1":
                case "pay":
                    {
                        if (HasMoney == true)
                        {
                            Console.WriteLine("You give the little money you have left to the redneck" +
                                "\n" + "He doesn't bother you any further");
                            VisualController.Continue();
                        }
                        else
                        {
                            Console.WriteLine("You don't have any money. The redneck is aware of this and" +
                           " gives you a trip to the infirmary as a warning");
                            VisualController.Continue();
                            Program.GameOver();

                        }
                        break;
                    }

                case "2":
                case "bargain":
                case "attempt to bargain":
                    {
                        if (ChanceSystem.BargainAttempt() == true)
                        {
                            Console.WriteLine(@"                                                                            ░░▒▒▓▓▓▓▓▓▓▓▓▓▒▒░░                                                                          
                                                                    ▒▒▓▓▓▓████▓▓▓▓▓▓▓▓██▓▓██▓▓▓▓▓▓██▓▓░░                                                                
                                                              ▒▒▓▓▓▓██▒▒██▓▓████▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓██████▓▓▒▒                                                          
                                                          ▓▓██░░██▒▒██▓▓░░                      ░░▒▒▓▓████▓▓▓▓██▓▓                                                      
                                                      ▓▓▓▓▓▓▓▓▒▒▓▓              ░░                        ▓▓██████▓▓▓▓                                                  
                                                  ░░██▓▓▓▓░░░░                  ██              ▓▓            ░░▓▓▓▓▓▓██▒▒                                              
                                                ▓▓██▒▒▓▓░░      ▒▒          ▓▓▓▓▓▓██▓▓      ▓▓▓▓▓▓▓▓░░            ░░▓▓██▓▓▓▓░░                                          
                                            ▒▒▓▓▓▓▓▓▒▒          ▓▓▒▒▓▓        ▒▒████          ██▓▓▓▓▒▒                ▒▒▒▒▓▓▓▓                                          
                                          ▓▓▓▓▓▓▒▒            ▓▓▓▓▓▓          ██░░▓▓        ░░▓▓██▓▓        ▒▒  ▒▒      ░░▓▓████                                        
                                        ▓▓▓▓▓▓▒▒              ░░▓▓▓▓▓▓                      ░░    ▓▓        ▓▓▓▓▓▓          ▓▓▓▓██░░            ░░▓▓▓▓▒▒                
                                      ▓▓▓▓██▒▒        ▒▒        ▓▓░░░░                                      ██▓▓████          ▓▓▓▓██▒▒      ▒▒▓▓▓▓██▓▓▓▓                
                                    ▓▓██▓▓░░      ▓▓▓▓▓▓        ░░          ░░▒▒▓▓▓▓▓▓▓▓▓▓▓▓▒▒░░          ▒▒▒▒▓▓▓▓              ▓▓▓▓██▒▒▓▓▓▓████▓▓░░▓▓██░░              
                                  ▓▓▒▒▓▓        ▓▓▓▓▒▒██░░          ▓▓██▓▓██▓▓▓▓▒▒▒▒░░▒▒▒▒▓▓▓▓████▓▓▓▓░░                        ░░▓▓▓▓██▓▓▒▒          ████              
                                ▓▓██▓▓░░          ▓▓██░░        ▓▓██▓▓▓▓░░                        ▒▒▓▓████░░                ░░▒▒██▓▓▓▓                ▓▓██░░            
                              ▒▒████░░              ▒▒      ░░██▓▓▓▓                                  ░░▓▓██▓▓          ▓▓██████▒▒                      ▓▓▓▓            
                              ████▓▓      ▓▓              ▓▓▓▓▓▓                                          ░░████▒▒░░▓▓▓▓▓▓▓▓▒▒                          ▓▓██            
                            ▓▓██▓▓    ▓▓▓▓██            ████▒▒                                                ▓▓▓▓▓▓▓▓▓▓░░                ░░▓▓▓▓▒▒      ░░▓▓▓▓          
                          ░░████░░    ▓▓▓▓▓▓▒▒░░      ▓▓██░░                                            ░░▓▓▓▓▓▓▓▓▒▒                  ▒▒▓▓▓▓████▒▒        ████          
                          ▓▓▓▓▓▓      ████▓▓░░      ████                                            ▒▒▓▓████▓▓░░                  ▒▒▓▓██▓▓▓▓░░            ▓▓▓▓▒▒        
                        ░░▓▓▓▓      ░░░░░░▓▓      ████                                        ░░▓▓████▓▓▒▒                  ░░▓▓  ░░████          ░░        ▒▒▓▓        
                        ▓▓██▓▓            ░░    ▓▓▓▓░░                                    ▒▒██▓▓▓▓▓▓░░                      ▓▓▓▓    ██▓▓▒▒    ▓▓▓▓▓▓        ▓▓▓▓▓▓      
                        ████                  ░░▓▓▒▒                                  ▓▓▓▓▓▓██▒▒                            ▒▒██▒▒  ▒▒██████▓▓▓▓▓▓░░        ░░██▓▓░░    
                      ▒▒▒▒▓▓      ▓▓          ██▓▓                              ▒▒██████▓▓░░                    ██▓▓▓▓▒▒      ▓▓▓▓    ██████▒▒                ██████    
                      ▓▓▒▒▒▒  ░░▒▒▓▓        ▒▒▓▓                          ░░▓▓▓▓▓▓▓▓▒▒                  ░░▓▓░░  ▒▒████▒▒▒▒    ▓▓▓▓░░  ▒▒▓▓▓▓        ▒▒▒▒      ░░▓▓▓▓▒▒  
                      ▓▓░░    ░░▒▒▓▓▓▓▒▒    ██▓▓                      ▒▒▓▓▒▒▓▓▒▒░░                      ▒▒▓▓▓▓    ▓▓██▓▓██▒▒░░▒▒▓▓▒▒  ░░▓▓▓▓  ░░▒▒▓▓▓▓██        ▓▓▓▓██  
                    ▒▒▓▓▒▒      ▓▓▓▓▒▒    ▒▒▓▓░░                  ▒▒▒▒▒▒▓▓▒▒░░                            ▓▓██    ▓▓██▒▒▒▒████░░▓▓▓▓    ▓▓▓▓▒▒░░▓▓▓▓▒▒            ██▓▓  
                    ▓▓▓▓▓▓    ▒▒▒▒░░▓▓    ▓▓▓▓              ░░▓▓██▒▒██▒▒                  ▒▒▒▒            ▒▒▓▓▓▓  ░░▓▓▓▓  ░░██▓▓▓▓██▒▒  ▒▒▓▓██▓▓░░                ▒▒██▓▓
                    ▓▓▓▓░░                ██▒▒          ▒▒██▓▓▓▓▓▓░░                    ░░▓▓▓▓            ░░▓▓▓▓    ██▓▓░░    ▓▓▓▓▒▒▓▓    ▒▒                      ░░████
                    ▓▓██                ░░▓▓      ░░▓▓██▓▓██▓▓                            ▓▓██▒▒            ██▓▓░░  ▒▒▓▓▓▓      ▒▒██▒▒                      ░░▓▓████▓▓▓▓
                    ▓▓██                ▒▒██  ▒▒▓▓████▓▓░░                  ▓▓██▓▓██▓▓    ▒▒████            ▒▒▓▓▓▓    ██▓▓                            ░░▒▒████▓▓██▓▓▒▒  
                  ░░▓▓██                ▓▓████▒▒██▒▒░░                ▒▒▓▓██▓▓▓▓██▓▓▓▓▒▒    ▓▓██░░            ▓▓██░░  ▓▓▓▓▒▒                      ░░████████▓▓░░        
                  ▒▒▓▓▓▓            ▒▒██▓▓▓▓▓▓                        ▓▓██▓▓░░      ▓▓▓▓▓▓  ▓▓▓▓▓▓            ▓▓██▓▓  ░░░░                    ▒▒▓▓██▓▓██▒▒              
                  ▒▒▓▓██        ▓▓██▓▓▓▓▓▓                  ░░        ░░▓▓▓▓        ░░░░██  ░░▓▓▓▓      ▒▒██░░░░██░░                    ░░▓▓██▓▓▓▓▓▓▓▓██                
                  ▒▒▓▓██  ▒▒████▓▓██░░                    ██▓▓▓▓        ████░░        ██▓▓░░  ▓▓▓▓▓▓▓▓██▓▓██▓▓                      ▒▒▓▓▓▓████▒▒    ▓▓██                
                  ▒▒▓▓████▓▓▓▓▓▓░░                        ██▒▒▓▓▓▓      ▒▒██▓▓        ▓▓██▒▒  ▒▒▓▓▓▓████░░                    ░░▓▓██▓▓▓▓▓▓░░        ▓▓██                
                ░░▓▓████▓▓▒▒                  ▒▒▓▓        ▓▓▓▓▓▓▓▓▓▓      ▓▓██        ▓▓██░░    ▓▓▓▓                      ░░▓▓██▒▒▓▓▒▒              ██▓▓                
            ▓▓██▓▓▓▓▓▓░░                ░░▒▒██▓▓██▒▒      ▓▓██  ▓▓▓▓░░    ▓▓██▓▓    ▓▓██▓▓                            ▒▒██▓▓██████                  ██▓▓                
      ░░▓▓██▓▓▓▓▒▒                  ▒▒▓▓██▓▓▓▓▒▒          ██▓▓  ░░████    ░░▓▓▓▓▓▓▓▓▓▓██░░                        ▓▓██▓▓██▓▓░░▓▓██                ░░████                
░░▓▓██████▓▓░░                      ▓▓██▓▓░░              ██░░  ▒▒██▓▓▓▓░░  ████▓▓▒▒▒▒                      ░░▓▓██▓▓██▒▒      ▓▓▓▓                ░░████                
░░██▓▓▒▒                  ░░░░      ░░▒▒██      ▒▒▒▒░░    ██▓▓██▓▓▓▓▓▓▓▓██  ▒▒▓▓░░                      ▒▒██▓▓████░░          ▓▓▓▓                ▓▓██▓▓                
  ▓▓▓▓▒▒            ░░▓▓████████▓▓    ▒▒██▓▓▓▓▓▓▓▓▓▓░░    ▓▓██▒▒░░    ████▒▒                      ░░▓▓▓▓██▒▒▒▒                ██░░    ▒▒  ▒▒      ▓▓██▒▒                
    ▓▓██        ░░▓▓██▒▒██▓▓▓▓▓▓██▓▓  ▒▒▓▓▓▓▒▒▓▓          ▓▓▒▒                                ▒▒██▓▓▓▓██░░                  ░░██      ██▓▓▒▒      ▓▓██░░                
    ▓▓▓▓░░        ▓▓▓▓▒▒      ░░▓▓▓▓░░  ████░░            ▓▓▓▓                          ░░▓▓██▓▓▓▓▓▓                        ▓▓▒▒    ▒▒▓▓▓▓▓▓    ░░▓▓██                  
    ░░▓▓▓▓        ▓▓▓▓▓▓        ▓▓▓▓▓▓  ▓▓▓▓▓▓    ▒▒████  ▓▓▒▒                      ▒▒██▓▓████▒▒                          ░░▓▓      ░░▓▓▓▓▒▒▒▒  ▓▓▓▓▓▓                  
      ▓▓▓▓        ░░▓▓██          ▓▓██  ░░██▓▓▒▒▓▓▓▓▓▓▓▓░░                      ▓▓██████▓▓                                ▓▓██          ▓▓      ▓▓██▒▒                  
      ▒▒██▒▒        ▓▓▓▓░░        ▓▓██    ████▓▓▓▓▒▒                        ▓▓▓▓████▒▒                                  ░░██▒▒                ░░████                    
        ██▓▓        ▓▓▓▓▓▓      ▒▒██▓▓    ▒▒▓▓░░                      ▓▓██▓▓▓▓▓▓░░                                      ██▓▓                  ▓▓▓▓▓▓                    
        ▒▒▒▒░░        ▓▓▓▓    ▒▒██▓▓░░                            ▓▓▓▓▒▒██▓▓                                          ▓▓██      ▓▓            ████░░                    
        ░░██▓▓        ▓▓▓▓▓▓▓▓██▓▓▒▒                        ▒▒▓▓██▓▓▓▓▒▒                                            ▓▓██░░      ▓▓██▓▓      ▓▓██▓▓                      
          ▓▓▓▓        ░░██████▒▒                      ░░▓▓██▓▓██▓▓░░                                              ▓▓██▒▒    ░░██▓▓▓▓▒▒    ░░▓▓██░░                      
          ▒▒▓▓▒▒        ▓▓░░                      ░░▓▓████▓▓▓▓                                                  ▓▓██▒▒          ▓▓▓▓██    ████▓▓                        
            ██▓▓                              ▒▒████▒▒▓▓▓▓▓▓▒▒                                              ░░████░░            ▓▓      ▒▒████                          
            ▓▓██░░                      ░░▓▓██████▓▓░░    ▒▒████▒▒                                        ▒▒██▓▓                      ░░████▒▒                          
              ██▓▓                  ▓▓████▓▓██▒▒              ▒▒████░░                                ▒▒▓▓██░░        ▓▓▒▒            ██▓▓▓▓                            
              ▓▓██            ░░▓▓██▓▓▓▓▓▓░░                    ░░▓▓▓▓██▓▓░░                  ░░▒▒████▒▒▒▒        ░░▓▓▓▓████░░      ▓▓▓▓▒▒                              
              ▒▒▓▓▓▓      ▒▒▓▓██▓▓██▓▓██░░                  ░░      ░░▒▒▓▓██▓▓██▓▓▓▓▒▒▓▓▓▓██████░░▓▓░░              ▒▒██▓▓▒▒      ▓▓▓▓▓▓░░                              
                ▓▓▓▓░░▓▓▓▓▓▓██▓▓░░  ▓▓▓▓██░░              ░░██              ░░▒▒▓▓▒▒▓▓▓▓▓▓▓▓░░░░          ░░        ░░██▓▓▒▒    ▒▒▓▓██░░                                
                ▒▒██▓▓▓▓▓▓▒▒          ▒▒▓▓██▒▒          ▓▓██████▒▒                                    ░░░░██        ░░        ▒▒▓▓▓▓░░                                  
                  ▓▓▓▓░░                ▓▓▓▓██▓▓          ▓▓████        ▒▒                            ▒▒▓▓██▓▓              ▓▓▒▒▓▓▒▒                                    
                  ░░                      ▓▓██▓▓▓▓        ▓▓▒▒▓▓░░      ▓▓▓▓██░░        ██▒▒▓▓        ▒▒██▓▓▓▓░░        ░░▓▓▒▒▓▓░░                                      
                                            ▒▒▓▓████▒▒    ░░          ░░▓▓▓▓▓▓          ▓▓▓▓▓▓        ▓▓▒▒██          ▒▒▓▓██▓▓                                          
                                                ████▓▓██░░            ▒▒██▓▓▓▓▓▓      ▒▒████████          ░░      ░░████▓▓██                                            
                                                  ▒▒██▓▓██▓▓░░          ░░██              ██                  ░░██▓▓████▒▒                                              
                                                      ██  ▓▓████░░        ░░              ▒▒              ░░██▓▓██▓▓██░░                                                
                                                        ▒▒██▓▓▓▓▓▓██░░░░                              ▓▓██▓▓██▓▓▓▓▒▒                                                    
                                                            ░░▓▓██▓▓▓▓████▓▓▓▓▒▒▒▒▒▒░░  ▒▒▒▒▓▓▓▓████████▓▓██▓▓░░                                                        
                                                                  ▒▒▓▓██▓▓▓▓▓▓▓▓██▓▓▓▓██▓▓████▓▓▓▓████▓▓▒▒                                                              
");
                            Console.WriteLine("\n" + "You bought yourself until the end of the day.");
                            VisualController.Continue();
                        }
                        else
                        {
                            VisualController.SetLossColour();
                            Console.WriteLine("You try to get some more time, but you've already had a month and T-bag " +
                                "isn't the most patient fella to begin with." + "\n" + "He makes an example of you, taking your hand!");
                            VisualController.Continue();
                            Program.GameOver();

                        }
                        break;
                    }

                case "3":
                case "lie":
                    {
                        VisualController.SetLossColour();
                        Console.WriteLine("'I gave it to Joe already, he said it went into your account', you insist." +
                            "\n" + "You're sweating and they see right through you... you're killed." + "\n");
                        VisualController.Continue();
                        Program.GameOver();
                        break;
                    }

                case "4":
                case "run":
                    {
                        if (ChanceSystem.RunAttempt() == true)
                        {
                            VisualController.SetColour();
                            Console.WriteLine("The other inmates don't call you The Jet for nothing as your advesary quickly learns."
                                +  "\n" + "Before he can even display any anger or confusion you're nearly at the end of the hallway."
                                + "\n" + "By the time he starts chasing you you've managed to hide in the library");
                        }
                        else
                        {
                            VisualController.SetLossColour();
                            Console.WriteLine(@"██▓▓▓▓░░░░░░░░░░▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒
██████▒▒░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒▒░░░░▒▒░░▒▒░░▒▒▒▒▒▒▒▒▒▒▒▒░░░░▒▒▒▒░░░░░░▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒
██████▓▓▒▒░░░░░░░░░░▒▒▒▒░░░░░░░░░░░░░░▒▒▒▒▓▓▒▒░░░░▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒
████████▓▓▒▒░░░░▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒░░░░▓▓▓▓▓▓▒▒░░░░░░░░░░░░░░░░░░░░▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒░░▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒
████████████▒▒▒▒░░░░░░░░░░░░▒▒░░░░░░▓▓▓▓▓▓▒▒▒▒░░░░░░░░░░░░▒▒▒▒▒▒▓▓██▒▒▓▓▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒▒▒▒▒▒▒▒
████████████████▒▒░░░░░░░░░░░░░░░░░░▓▓▓▓▓▓▒▒▒▒░░░░░░░░░░▒▒▓▓▓▓▓▓▓▓▓▓██▓▓▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
██████████████████▒▒▒▒▒▒▒▒▒▒░░░░░░▒▒▓▓▓▓▒▒▒▒▒▒▒▒░░░░░░▓▓▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
██████████████████▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓▓▓▓▓░░▒▒░░▒▒░░░░▒▒▓▓▓▓██▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▓▓▓▓▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
▓▓██████████████▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██████░░▒▒▒▒▒▒▒▒▒▒░░▒▒▒▒▓▓▓▓▓▓████████▓▓▓▓▓▓▓▓▓▓▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
██████▓▓██▓▓██████▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓▓▓▓▓░░▓▓▒▒▒▒▒▒▒▒▒▒▒▒▓▓▓▓▓▓████████▓▓▓▓▓▓▓▓▓▓▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
▓▓████████▓▓▓▓████▓▓▓▓▒▒▒▒▒▒▒▒▒▒▒▒██▓▓██░░██▓▓▒▒▒▒▒▒▒▒▒▒▓▓▓▓▓▓██▓▓████▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
████▓▓████████▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒▒▒▒▓▓▒▒▓▓░░██▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓████▓▓██▓▓▓▓▓▓▓▓▓▓▓▓▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
▓▓██▓▓████████████████▓▓▓▓▒▒░░▒▒▒▒▓▓▒▒▓▓░░░░░░▒▒░░▒▒▒▒░░▒▒▓▓▓▓▓▓▓▓██████▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
██████▓▓██▓▓▓▓▓▓██████████▓▓▓▓▒▒░░▓▓▓▓▓▓░░░░░░░░░░▒▒▒▒▒▒▓▓▓▓████▓▓██████▓▓▓▓▓▓██▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
▓▓██████▓▓▓▓▓▓██▓▓▓▓██▓▓██▓▓▓▓▓▓▒▒▓▓▒▒▒▒░░░░░░░░░░░░▒▒▓▓▓▓▓▓████▓▓████▓▓▓▓▓▓▓▓▓▓██████▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒▒▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
██▓▓▓▓▓▓▓▓▒▒██▓▓▓▓▓▓▓▓██████▓▓▓▓▒▒▓▓▒▒▒▒░░░░░░░░░░░░░░▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓██▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▓▓▓▓▓▓▓▓░░░░░░░░░░▓▓▒▒▒▒▓▓██▓▓▓▓▓▓▓▓▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒░░░░░░░░
████████████▓▓██████▓▓▓▓▓▓▓▓██▓▓░░▓▓▒▒▓▓░░░░░░░░░░░░░░▓▓▓▓▓▓▓▓▓▓████▓▓▓▓▓▓▓▓▓▓▓▓▓▓████▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒░░▒▒▓▓▓▓████████▓▓████▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒░░░░░░░░░░░░░░░░░░░░▓▓▓▓▓▓▓▓▓▓▒▒░░░░
▓▓▓▓██████▓▓██▓▓████▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▓▓░░░░░░░░░░░░░░▓▓▓▓▓▓██████████▓▓▓▓▓▓▓▓██▓▓▓▓██▓▓▓▓▓▓▓▓▓▓▓▓██▓▓▓▓██▓▓████▓▓▓▓██████████▓▓▓▓████████▓▓██▓▓▓▓▓▓▓▓▓▓▒▒░░░░░░░░░░▒▒▒▒▓▓██▓▓▓▓▓▓██▓▓▓▓
▓▓▓▓▓▓████▓▓▓▓████▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░▓▓░░░░░░░░░░░░░░▓▓▓▓▓▓██████████▓▓▓▓▓▓▓▓▓▓▓▓██▓▓██▓▓██████████▓▓██████████▓▓▓▓▓▓▓▓▓▓▓▓▓▓████▓▓▓▓▓▓▓▓▓▓████▓▓▓▓▓▓▓▓▓▓░░░░░░░░▓▓████▓▓▓▓████▓▓▓▓████
▓▓▓▓▓▓████████▓▓██▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▓▓▒▒▓▓░░░░░░░░░░░░░░▓▓████▓▓▓▓▓▓▓▓██▓▓██▓▓▓▓▓▓▓▓██▓▓▓▓▓▓████████████████████████▓▓▓▓██▓▓▓▓██▓▓▓▓▓▓████▓▓████████▓▓▓▓▓▓▓▓░░░░░░▒▒██████████████████████
▓▓████████████████▓▓▓▓▓▓▓▓▓▓▓▓▒▒░░▓▓▒▒▓▓░░░░░░░░░░░░░░██████▓▓▓▓▓▓▓▓▓▓██▓▓██▓▓▓▓▓▓▓▓▓▓▓▓████████████████████████████████████▓▓▓▓▓▓████████████████████▓▓▓▓▓▓▒▒▒▒▓▓██████████████████████
▓▓██▓▓████████▓▓██▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▓▓░░░░░░░░░░░░████████████▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓██████████████████████████████████▓▓▓▓▓▓▓▓██████████████████████▓▓▓▓▒▒▓▓██████████████████████
████▓▓██▓▓████▓▓██▓▓▓▓██▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒░░░░░░░░▓▓▓▓████████▓▓▓▓██▓▓████████▓▓▓▓▓▓▓▓▓▓▓▓██████████████████████████████▓▓▓▓██▓▓████████▓▓████████████████████▓▓██████████████████████████
▓▓▓▓██████▓▓▓▓████████▓▓██▓▓▓▓▓▓▓▓▒▒░░░░░░░░░░░░██████████████▓▓████████████▓▓▓▓▓▓██▓▓▓▓████████████████████████████▓▓▓▓▓▓██████▓▓██████████████████████▓▓██████████████▓▓████████▓▓▓▓██
▓▓██▓▓████▓▓▓▓▓▓██████████▓▓▓▓▓▓▓▓░░▒▒░░░░░░░░░░████████████████████████████████▓▓████▓▓████████████████████████████████▓▓▓▓████▓▓██████████████████████▓▓████████████████▓▓██████████▓▓
████▓▓▓▓████████████▓▓▓▓██▓▓▓▓▓▓▓▓░░▒▒░░▒▒░░░░▒▒▓▓████████▓▓▓▓██████████████▓▓██▓▓██▓▓████████████████████████████████▓▓████████████████████████████████████████████████████████████████
██▓▓██▓▓▓▓▓▓██▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░▒▒░░▒▒░░▒▒▓▓▓▓██████████████████████████▓▓▓▓████████████████████████████████████▓▓██████████████████████████████████████████████████████████████████
▓▓▓▓▓▓██▓▓██████▓▓▓▓▓▓▓▓▓▓██▓▓▓▓▓▓░░▒▒░░▒▒▒▒▓▓▓▓▓▓██████████████████████████▓▓██████████████████████████████████████████████████████████████████████████████████████████████████████████
▓▓▓▓▓▓▓▓██████▓▓▓▓▓▓▓▓▓▓▓▓████▓▓▓▓░░▒▒░░▒▒▓▓▓▓▓▓▓▓▓▓██████████████████████████████████████████████████████████████████▓▓████████████████████████████████████████████████████████████████
▓▓██▓▓▓▓████████▓▓▓▓▓▓████████████░░▓▓▓▓▓▓▓▓██▓▓▓▓▓▓▓▓▒▒██████████████████████████████▒▒░░▓▓▓▓████████████████▓▓████████████████▓▓████████████████████████████████▓▓████████████████████
██▒▒▓▓██████████▓▓▓▓██████████████▓▓▓▓▓▓▓▓▓▓██▓▓▓▓▓▓▓▓▒▒▓▓████████████████▓▓██████████▓▓▓▓▓▓████████████████████████████▓▓██████████████████████████████████████████████████████████████
████████████████████████████████▓▓▓▓██▓▓██▓▓▓▓▒▒▓▓▒▒▓▓▓▓████████▓▓▓▓▓▓██▓▓▓▓▓▓▓▓▓▓▓▓██▓▓▓▓▓▓▓▓▓▓▓▓██▒▒░░  ░░████▓▓▒▒▓▓██▓▓▓▓▒▒▓▓▒▒▒▒████████▓▓▒▒▓▓▓▓  ░░████████▓▓██▓▓▓▓▓▓▓▓▓▓██▓▓▓▓▓▓▓▓
░░▒▒▒▒▒▒▒▒▒▒▓▓██▓▓▓▓▓▓▓▓▓▓▓▓▓▓██▓▓██▓▓▒▒▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓██▓▓██▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓██▒▒▓▓▓▓████████████████▓▓██▓▓▒▒████████████▓▓██▒▒▒▒▒▒▒▒▒▒▓▓▒▒░░▒▒░░░░▒▒██░░██░░▒▒░░░░
▓▓██▓▓▒▒░░▓▓▒▒░░▒▒░░░░▒▒▒▒▒▒░░▒▒░░░░░░░░░░░░░░░░░░░░▒▒░░▒▒░░░░▓▓░░██▓▓░░██▒▒▓▓██░░██▓▓░░▓▓▒▒░░▓▓▒▒░░▓▓▒▒▒▒▓▓▒▒████▓▓▒▒▓▓▓▓▓▓▒▒██▓▓████▒▒██████▓▓██▓▓████▓▓▓▓████▓▓▓▓████████████▓▓██▓▓▓▓
▓▓▒▒▓▓▒▒▓▓▒▒▓▓▒▒▓▓▒▒▓▓▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░▒▒▓▓▓▓▓▓▒▒▒▒▒▒▒▒▒▒░░▒▒▒▒▒▒▒▒▒▒▒▒░░░░▒▒░░  ▓▓▒▒░░▓▓▓▓  ████▒▒▓▓██▓▓░░██▓▓▒▒▒▒▓▓▓▓░░▓▓▒▒░░████▒▒░░░░▒▒▒▒░░▓▓▒▒▒▒██▒▒▒▒████▓▓▓▓██▓▓████████▓▓████▓▓
▒▒██░░▓▓▒▒▒▒██░░██░░██▒▒▓▓▓▓░░██▒▒▒▒██░░▓▓██▓▓██████████▓▓▓▓████▓▓▓▓██▓▓▓▓██▒▒▒▒██▒▒▒▒▓▓▓▓▒▒▒▒▓▓▓▓░░██▓▓▓▓▒▒▓▓▓▓▓▓▒▒▓▓▓▓▒▒▓▓▓▓▓▓████▓▓▓▓▒▒▓▓▓▓▒▒▓▓▓▓▓▓▓▓▓▓▒▒▓▓▓▓▒▒██▓▓▒▒██▓▓▒▒▓▓▓▓▓▓██▒▒
▓▓░░▒▒▒▒░░██▒▒░░██░░██▓▓▒▒██░░▒▒▓▓░░██▒▒░░▓▓▓▓████▓▓▓▓██████████████████▓▓████████▓▓██████▓▓██████▓▓██████▓▓██████████████████▒▒██████▒▒▓▓██▓▓▓▓▒▒██▒▒▓▓▓▓▒▒██▒▒▒▒▒▒▒▒▒▒▓▓▒▒▓▓▓▓▒▒████▒▒
██▒▒██▒▒▒▒████▓▓▓▓▒▒████▒▒▓▓██▓▓██▒▒▓▓██▒▒██▓▓▓▓████████▒▒████████▒▒██████▓▓▒▒██████░░▓▓██████▒▒████████▓▓████████████████████▒▒██████▓▓▓▓██▓▓██▒▒██▒▒██▓▓▓▓▓▓▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▒▒▓▓██▒▒▓▓
▓▓████▓▓████░░████▓▓██▓▓▓▓████▒▒██░░▓▓████▒▒▓▓░░██▓▓▓▓▒▒░░▓▓▓▓▒▒░░▒▒▓▓▓▓▓▓░░▓▓▓▓▓▓██░░▓▓██████░░▓▓██████░░████████▓▓▓▓████████▓▓████████████████████▓▓██████▓▓██▓▓▓▓████████▒▒▓▓████▓▓██
░░████░░██▓▓░░██▓▓░░██▓▓▓▓██▓▓░░▓▓▒▒██  ██░░▓▓▒▒██░░▓▓▒▒▒▒██▒▒░░░░▒▒████▒▒░░▓▓████▓▓░░████████░░▓▓████▓▓░░▒▒▓▓▓▓▓▓▓▓▒▒▓▓██████▒▒▒▒▒▒████████▓▓██████████████▓▓██████████████▓▓██████▓▓██
▒▒██▓▓▒▒██▓▓░░▓▓██░░██▓▓░░▒▒██░░▓▓▓▓▓▓░░██▒▒██▒▒▒▒▓▓██▒▒▒▒▓▓░░▒▒▓▓████▒▒▒▒▓▓████▓▓░░▒▒████████░░████████▓▓░░██████▓▓▓▓▒▒▓▓████▓▓▓▓▒▒▓▓██████▓▓██▒▒▓▓██████▓▓▒▒██▓▓██████████▓▓██████████
▓▓██▒▒░░████░░████░░▒▒██▓▓▒▒██▓▓▓▓████░░██░░▓▓▓▓██▓▓▒▒▓▓░░▓▓░░▓▓██▓▓██▒▒▒▒██████▒▒░░▓▓██████▓▓░░▓▓████████▒▒████████▓▓▒▒░░████████▒▒▒▒▓▓▓▓██▓▓██▒▒██▒▒██████▓▓██▒▒▓▓██████▓▓▓▓████▓▓████
██▓▓▒▒████▒▒  ▓▓██▓▓▓▓████▒▒▓▓██▓▓██░░▓▓██▒▒██▓▓██▓▓░░▓▓▒▒██▓▓▓▓▓▓▒▒██▒▒██████▒▒▓▓▒▒████████▒▒░░██████████▒▒▓▓████████▓▓▒▒▓▓██████▓▓▓▓▒▒▒▒▓▓████▒▒██▒▒██▒▒██▓▓██▒▒████▓▓████▓▓██▓▓▒▒████
██░░▒▒████▓▓▒▒████░░░░████▓▓░░████▓▓░░▓▓██▒▒██▒▒▓▓██▒▒██▓▓▓▓██░░░░▓▓████████▒▒▒▒▓▓██████████░░▒▒██████████░░░░██████████▒▒▒▒████████▓▓██▓▓▒▒▓▓██████▒▒▓▓▒▒▓▓████▒▒████▓▓████▒▒████▒▒████
▒▒░░▓▓████░░░░██████▓▓████▒▒░░░░████░░██▒▒████▒▒▓▓██▒▒████░░██▓▓▒▒▓▓██████▒▒░░▒▒██████████░░░░▓▓██████████▓▓▓▓████████████▒▒▒▒██████████▒▒▒▒██▒▒████▓▓██▓▓██▓▓▓▓██████▓▓██▓▓▒▒▓▓██▒▒████
██░░████▓▓░░▒▒████▒▒████████▒▒██████▒▒▒▒░░▓▓██▒▒████▓▓██▓▓░░▓▓▓▓▓▓██████▒▒██▒▒▓▓████████▓▓░░▒▒████████████▒▒▒▒████████████▓▓▒▒████████████▒▒▓▓▒▒▓▓██████▓▓██▓▓▒▒██▓▓██▓▓████▓▓████▓▓████
▓▓░░██████░░████▓▓    ▓▓████▒▒░░████████▒▒████▒▒████░░████▒▒██████████░░░░▓▓▒▒████████▒▒▓▓▒▒▒▒████████████▒▒▓▓████████████▒▒░░▒▒██████████▓▓██▒▒▓▓▓▓██████████████▒▒▓▓██████▓▓██▓▓▒▒▒▒██
▒▒██▓▓▓▓░░░░██████▓▓▓▓██████▓▓  ▒▒██████░░████████░░  ▒▒██▒▒██████  ████▒▒██▓▓████████▒▒▒▒▒▒████████████▓▓░░▒▒██████████████▒▒░░██████████████▒▒▓▓▒▒██████████▓▓██▒▒▓▓████████████▓▓████
▓▓▓▓▓▓▒▒░░▒▒▓▓▓▓██▒▒▒▒▓▓▓▓▓▓▒▒  ▓▓██████▒▒▓▓▒▒██████  ██████████▒▒  ░░██▒▒██████████▓▓▒▒▓▓▒▒████████████▓▓░░████████████████▒▒░░▒▒████████████▒▒▓▓▒▒██████████████▓▓████▓▓▓▓██████▓▓████
████▓▓▓▓░░██▓▓▓▓▓▓  ▓▓▓▓▓▓▓▓▓▓  ▓▓██▓▓▓▓▓▓░░░░▒▒████  ██████████▓▓  ████▓▓████████░░▓▓▓▓▓▓████████████▓▓░░  ▓▓██████████████▓▓░░████████████████▓▓▓▓▓▓▒▒██████████▓▓▓▓██▒▒▒▒▓▓██████████
▓▓▓▓▓▓▓▓░░▓▓▓▓▓▓▒▒  ░░▓▓▓▓▓▓██  ██▓▓▓▓▓▓▓▓▒▒▒▒▓▓▓▓██▒▒▓▓▓▓  ▓▓▓▓▓▓  ████████████▒▒  ░░▒▒▓▓██████████████▓▓▒▒██████████████████░░▒▒██████████████▓▓▒▒▒▒░░▒▒████████▓▓████▓▓▓▓████████████
▓▓▓▓▓▓▓▓  ▓▓██▓▓▓▓░░▓▓▓▓▓▓▓▓▓▓░░▓▓▓▓▓▓▓▓▓▓▒▒▒▒▓▓▓▓▓▓▓▓▓▓▒▒  ░░▓▓██  ████████▓▓██▓▓░░▓▓██▓▓████████████░░▒▒▒▒████████████████▓▓░░░░▒▒██████████████▓▓▓▓▒▒████████████████▓▓▓▓████▒▒▓▓████
▓▓  ▓▓████▓▓▓▓▓▓▓▓  ▓▓▓▓▓▓▓▓▓▓  ░░▒▒██▓▓▓▓▒▒▒▒▓▓██▓▓▓▓▓▓██  ██▓▓▓▓▓▓▓▓██▓▓▓▓░░▓▓▓▓░░▓▓██▓▓██████████▓▓░░░░▒▒██████████████████▒▒▒▒██████████████████▓▓▒▒██  ████████████▓▓▓▓████▒▒░░▓▓██
▓▓  ██▓▓▓▓▓▓▓▓▓▓██  ████████░░  ░░▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓  ██▓▓▓▓▓▓▓▓██▓▓▓▓░░████░░▓▓████▓▓▓▓▓▓▓▓██░░░░░░▓▓██████████████████▒▒░░██████████████████▓▓▒▒██  ██████████████▓▓██▓▓░░▒▒▓▓██
      ▓▓▓▓▓▓▓▓████▒▒▓▓▓▓▓▓▓▓▓▓░░▓▓██▓▓████▓▓▓▓▒▒░░▓▓▓▓████  ██████▓▓▓▓▓▓▓▓      ▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▓▓████▓▓▓▓██████████▓▓  ████████████████████▒▒      ██████████████████▓▓▓▓████
██  ▓▓▓▓▓▓▓▓▓▓░░▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░▓▓▓▓▓▓▓▓▓▓▓▓██▒▒░░▒▒██▓▓▓▓  ██▓▓▓▓▓▓▓▓▓▓████░░▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓██▓▓▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓████████▓▓  ▓▓██████████████████████  ████████████████████▓▓▓▓████
▓▓  ▓▓▓▓▓▓▓▓▓▓  ██████▓▓▓▓▓▓▓▓  ▓▓████████▓▓        ██▓▓▓▓██▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░▓▓▓▓▓▓████████▓▓▓▓▓▓▒▒░░▒▒▒▒██▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓      ▒▒██▓▓▓▓▓▓████▓▓██████  ████████████████████▓▓▒▒████
▓▓  ██████▓▓▒▒  ░░▒▒▓▓▓▓▓▓▓▓██▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒░░▓▓████▓▓▓▓▓▓▓▓▓▓▒▒░░▓▓▓▓██░░▓▓██▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░  ░░▓▓▓▓▓▓▓▓▓▓▓▓▓▓██▓▓▓▓██▓▓  ██▓▓▓▓▓▓▓▓▓▓▓▓▓▓████████  ██▓▓░░██████████████▓▓▓▓████
▓▓  ▓▓▓▓▓▓▓▓░░  ▒▒▓▓██▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓██▒▒  ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒░░████▓▓░░▓▓▓▓▓▓▓▓▓▓▓▓▓▓████░░░░  ▒▒██▓▓▓▓██▓▓████▓▓██▓▓▓▓▓▓  ▓▓▓▓▓▓▓▓▓▓██████▓▓▓▓▓▓▓▓  ██▓▓  ██▓▓██▓▓██████████████
████▓▓▓▓▓▓▓▓▓▓░░▓▓▓▓▓▓▓▓▓▓▓▓██░░▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒░░██████████▓▓▓▓▒▒░░    ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░██████████▓▓██▓▓▓▓▓▓▓▓▓▓▓▓  ▒▒██████▓▓▓▓▓▓▓▓▓▓▓▓████▓▓▓▓▒▒  ░░▓▓▓▓▓▓▓▓▓▓▓▓▓▓██████
");
                            Console.WriteLine("You run, but you you don't get far. You're caught and " +
                                "killed to serve as an example." + "\n");
                            VisualController.Continue();
                            Program.GameOver();
                        }
                        break;
                    }
                case "5":
                case "headbutt":
                case "headbutt!!!!":
                    {
                        if (HailMary.IsSuccess() == true)
                        {
                            Console.WriteLine("You headbutt the crazy redneck, but before he can strike back you trip him" + "\n"
                                + "His friends and enemies both come running, amidst the chaos of flying fists and gang rivalry you manage to flee.");
                            VisualController.Continue();
                            Program.GameOver();

                        }
                        else
                        {
                            VisualController.SetLossColour();
                            Console.WriteLine("You headbutt the crazy redneck. He savagely beats you to death..." +
                                "\n");
                            VisualController.Continue();
                            Program.GameOver();
                        }
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Unrecognised choice.");
                        VisualController.Continue();
                        Encounters(Echoice, HasMoney, IsAlone);
                        break;
                    }
            }
        }
    }
}
