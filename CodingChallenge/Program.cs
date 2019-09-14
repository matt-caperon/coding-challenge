using System;
using System.Collections.Generic;

namespace CodingChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Coordinates mapSize;
            List<Ship> ships;
            List<Instruction> shipInstructions;
            List<Coordinates> warningPositions = new List<Coordinates>();
            Coordinates newCoordinates;
            bool shipOnWarningPosition;

            try
            {
                // Read map size from command line
                mapSize = CommandLine.ReadCoordinatesFromCommandLine();

                // Read ship starting position and orientation 
                ships = CommandLine.ReadShipsFromCommandLine();

                // Perform instructions on each ship sequentially
                foreach (Ship ship in ships)
                {
                    // Reset flag
                    shipOnWarningPosition = false;

                    // Read ship instructions
                    shipInstructions = CommandLine.ReadInstructionsFromCommandLine();

                    // Cycle through ship instructions from list
                    foreach (Instruction instruction in shipInstructions)
                    {
                        // Perform instruction on ship
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
                            // Get new coordinates if ship moves forward
                            newCoordinates = ship.GetNewCoordinatesOnForward();

                            // Check if new coordinates have a warning
                            foreach (Coordinates warningPosition in warningPositions)
                            {
                                if (newCoordinates.x == warningPosition.x &&
                                    newCoordinates.y == warningPosition.y)
                                {
                                    shipOnWarningPosition = true;
                                    break;
                                }
                            }

                            // New coordinates would cause ship to be lost, skip instruction
                            if (shipOnWarningPosition)
                            {
                                continue;
                            }

                            // Determine if ship is lost
                            if (newCoordinates.x > mapSize.x || newCoordinates.y > mapSize.y)
                            {
                                // Mark ship as lost
                                ship.isLost = true;

                                // Record warning for other ships
                                warningPositions.Add(newCoordinates);
                            }
                            else
                            {
                                // Move Ship forward
                                ship.GoForward();
                            }             
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
