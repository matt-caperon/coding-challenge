using System;
using System.Collections.Generic;

namespace CodingChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Coordinates MapSize;
            Ship ship;
            List<Instruction> shipInstructions;

            try
            {
                // Read map size from command line
                MapSize = CommandLine.ReadCoordinatesFromCommandLine();
                Console.WriteLine("Map Size is: {0} {1}", MapSize.x, MapSize.y);

                // Read ship starting position and orientation 
                ship = CommandLine.ReadShipFromCommandLine();

                // Read ship instructions
                shipInstructions = CommandLine.ReadInstructionsFromCommandLine();

                foreach (Instruction instruction in shipInstructions)
                {
                    if (instruction == Instruction.Left)
                    {
                        ship.TurnLeft();
                    }
                    else if (instruction == Instruction.Right)
                    {
                        ship.TurnRight();
                    }
                    else if (instruction == Instruction.Forward)
                    {
                        ship.GoForward();
                    }
                }

                // Print ship final position and orientation
                CommandLine.PrintShipFinalPosition(ship);
            }
            catch(Exception ex)
            {
                Console.WriteLine("An error has occured: " + ex.Message);
            }

            Console.WriteLine("End of program");
        }
    }
}
