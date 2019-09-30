using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Zork
{
    class Program
    {
        public static Room CurrentRoom
        {

            get
            {
                return Rooms[Location.Row, Location.Colum];
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Zork");

            string roomsFilename = "Rooms.json";

            // Optionally, allowing the user to specify the file that needs to be read.
            // const string defaultRoomsFilename = "Rooms.txt";
            // string roomFilename = (args.Length > 0 ? args[(int)CommandLineArguments.RoomsFilename] : defaultRoomsFilename);

            InitializeRooms(roomsFilename);

            Room previousRoom = null;
            Commands command = Commands.UNKNOWN;
            while (command != Commands.QUIT)
            {
                Console.WriteLine(CurrentRoom);
                if (previousRoom != CurrentRoom)
                {
                    Console.WriteLine(CurrentRoom.Description);
                    previousRoom = CurrentRoom;
                }
                Console.Write(">");
                command = ToCommand(Console.ReadLine().Trim());

                switch (command)
                {
                    case Commands.QUIT:
                        Console.WriteLine("Thank you for playing!");
                        break;
                    case Commands.LOOK:
                        Console.WriteLine(CurrentRoom.Description);
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
            {new Room("Rocky Trail"),new Room("South of House"),new Room("Canyon View")},
            { new Room("Forest"), new Room("West of House"), new Room("Behind House")},
            {new Room("Dense Woods"), new Room("North of House"), new Room("Clearing") }
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

        private static readonly Dictionary<string, Room> RoomMap;

        static Program()
        {
            RoomMap = new Dictionary<string, Room>();
            foreach (Room room in Rooms)
            {
                RoomMap[room.Name] = room;
            }
        }

        private enum Fields
        {
            Name = 0,
            Description
        }

        private enum CommandLineArguments
        {
            RoomsFilename = 0
        }

        private static void InitializeRooms(string roomsFilename) => Rooms = JsonConvert.DeserializeObject<Room[,]>(File.ReadAllText(roomsFilename));
            
            

            /*
            string[] lines = File.ReadAllLines(roomsFilename);
            foreach (string line in lines)
            {
                string[] fields = line.Split(fieldDelimiter);
                if (fields.Length != expectedFieldCOunt)
                {
                    throw new InvalidDataException("Invalid record.");
                }

                string name = fields[(int)Fields.Name];
                string description = fields[(int)Fields.Description];

                RoomMap[name].Description = description;
            }
            */
        
    }
}

