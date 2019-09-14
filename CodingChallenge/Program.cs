using System;
using System.Collections.Generic;

namespace CodingChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Coordinates MapSize;
            List<Ship> ships;
            List<Instruction> shipInstructions;

            try
            {
                // Read map size from command line
                MapSize = CommandLine.ReadCoordinatesFromCommandLine();

                // Read ship starting position and orientation 
                ships = CommandLine.ReadShipsFromCommandLine();

                foreach (Ship ship in ships) {

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
            }
            catch(Exception ex)
            {
                Console.WriteLine("An error has occured: " + ex.Message);
            }

            Console.WriteLine("End of program");
        }
    }
}
