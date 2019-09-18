using System;

namespace Zork
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Zork!");
            Commands command = Commands.UNKNOWN;
            while (command !=Commands.QUIT)
            {
                Console.Write(">");
                command = ToCommand(Console.ReadLine().Trim());

                string outputString;
                switch (command)
                {
                    case Commands.LOOK:
                        Console.WriteLine("This is an open field west of a white house, with a boarded front door.A rubber mat saying 'Welcome to Zork!' lies by the door.");
                        break;
                    default:
                        command = Commands.UNKNOWN;
                        break;
                };


                Console.WriteLine(command);
            }
            
        }

        private static Commands ToCommand(string commandString) => (Enum.TryParse<Commands>(commandString, true, out Commands result) ? result : Commands.UNKNOWN);
        
            
        }
        
    }

