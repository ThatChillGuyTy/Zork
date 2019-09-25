using System;
using System.Collections.Generic;

namespace Zork
{
    class Program
    {
        private static string CurrentRoom
        {

            get
            {
                return Rooms[Location.Row, Location.Colum];
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Zork");
            Commands command = Commands.UNKNOWN;
            while (command != Commands.QUIT)
            {
                Console.WriteLine(CurrentRoom);
                Console.Write(">");
                command = ToCommand(Console.ReadLine().Trim());
                
                switch (command)
                {
                    case Commands.QUIT:
                        Console.WriteLine( "Thank you for playing!");
                        break;
                    case Commands.LOOK:
                        Console.WriteLine("This is an open field west of a white house, with a boarded front door.A rubber mat saying 'Welcome to Zork!' lies by the door.");
                        break;

                    case Commands.NORTH:

                    case Commands.SOUTH:
                    case Commands.EAST:
                    case Commands.WEST:
                        if (Move(command) == false)
                        {
                            Console.WriteLine("The way is shut!");
                        }
                        break;

                    default:
                        Console.WriteLine("Unknown command.");
                        break;
                }
            }
        }

        private static bool Move(Commands command)
        {
            Assert.IsTrue(IsDirection(command), "Invalid direction.");
            bool isValidMove = true;
            switch (command)
            {
                case Commands.NORTH when Location.Row > 0:
                    Location.Row--;
                    break;

                case Commands.SOUTH when Location.Row < Rooms.GetLength(0) - 1:
                    Location.Row++;
                    break;

                case Commands.EAST when Location.Colum < Rooms.GetLength(1) - 1:
                    Location.Colum++;
                    break;

                case Commands.WEST when Location.Colum > 0:
                    Location.Colum--;
                    break;

                default:
                    isValidMove = false;
                    break;
            }

            return isValidMove;
            
        }

        private static Room[,] Rooms = {
            {new Room("Rocky Trail"),new Room("South of HOuse"),new Room("Canyon View")},
            { new Room("Forest"), new Room("West of House"), new Room("Behind House")},
            {new Room("Dense Woods"), new Room("Clearing"), new Room("Canyon View") }
        };

        private static bool IsDirection(Commands command) => Directions.Contains(command);

        private static Commands ToCommand(string commandString) => (Enum.TryParse<Commands>(commandString, true, out Commands result) ? result : Commands.UNKNOWN);

        private static readonly List<Commands> Directions = new List<Commands>
        {
            Commands.NORTH,
            Commands.SOUTH,
            Commands.EAST,
            Commands.WEST
        };

        private static (int Row, int Colum) Location = (1, 1);

        private static void InitializeRoomDescriptions()
        {
            Rooms[0, 0].Description = "You are on a rock-strewn trail.";
            Rooms[0, 1].Description = "You are facing the south side of a white house. There is no door here, and all the windows are barred.";
            Rooms[0, 0].Description = "YOu are at the top of the Great Canyon on its south wall.";

            Rooms[0, 0].Description
        }

    }

}

