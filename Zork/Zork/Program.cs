<<<<<<< HEAD
<<<<<<< HEAD
﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
=======
﻿using System;
>>>>>>> parent of 6e12662... 9/25
=======
﻿using System;
>>>>>>> parent of 6e12662... 9/25

namespace Zork
{
    class Program
    {
        static void Main(string[] args)
<<<<<<< HEAD
        {
<<<<<<< HEAD
            const string defaultGameFilename = "Zork.json";
            string gameFilename = (args.Length > 0 ? args[(int)CommandLineArguments.GameFilename] : defaultGameFilename);

            Game game = Game.Load(gameFilename);
            Console.WriteLine("Welcome to Zork!");
            game.Run();
            Console.WriteLine("Thank you for playing!");
        }

        private enum CommandLineArguments
        {
           
            GameFilename = 0
        }




      

=======
           
=======
        {
           
>>>>>>> parent of 6e12662... 9/25
            Console.WriteLine("Welcome to Zork!");
            Commands command = Commands.UNKNOWN;
            while (command !=Commands.QUIT)
            {
                Console.Write(">");
                command = ToCommand(Console.ReadLine().Trim());

                string outputString;
                switch (command)
                {
                    case Commands.QUIT:
                        outputString = "Thank you for playing!";
                        break;
                    case Commands.LOOK:
                        outputString = "This is an open field west of a white house, with a boarded front door.A rubber mat saying 'Welcome to Zork!' lies by the door.";
                        break;

                    case Commands.NORTH:
                    case Commands.SOUTH:
                    case Commands.EAST:
                    case Commands.WEST:
                        outputString = $"You moved {command}.";
                        break;

                    default:
                        outputString = "Unknown command.";
                        break;
                };
<<<<<<< HEAD


=======


>>>>>>> parent of 6e12662... 9/25
                Console.WriteLine(outputString);
            }

            
        }

        private static string[] Rooms = { "Forest", "West of House", "Behind House", "Clearing", "Canyon View"};


        private static Commands ToCommand(string commandString) => (Enum.TryParse<Commands>(commandString, true, out Commands result) ? result : Commands.UNKNOWN);
        
            
        }
        
<<<<<<< HEAD
>>>>>>> parent of 6e12662... 9/25
=======
>>>>>>> parent of 6e12662... 9/25
    }

