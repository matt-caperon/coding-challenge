using System;
using System.Collections.Generic;

namespace CodingChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Coordinates mapSize;
            Ship ship;
            List<Ship> ships = new List<Ship>();
            List<Instruction> shipInstructions;
            List<Coordinates> warningPositions = new List<Coordinates>();
            Coordinates newCoordinates;
            int shipCount;
            bool shipOnWarningPosition;

            try
            {
                // Read map size from command line
                mapSize = CommandLine.ReadCoordinatesFromCommandLine();

                // Read ship count;
                shipCount = CommandLine.ReadShipCountFromCommandLine();

                for (int i = 0; i < shipCount; i++)
                {
                    // Read ship starting position and orientation 
                    ship = CommandLine.ReadShipFromCommandLine();
                
                    // Read ship instructions
                    shipInstructions = CommandLine.ReadInstructionsFromCommandLine();

                    // Cycle through ship instructions from list
                    foreach (Instruction instruction in shipInstructions)
                    {
                        // Reset flag
                        shipOnWarningPosition = false;

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

                            // New coorinates have no warning
                            if (!shipOnWarningPosition)
                            {
                                // Determine if ship is lost
                                if (newCoordinates.x > mapSize.x || newCoordinates.y > mapSize.y ||
                                    newCoordinates.x < 0 || newCoordinates.y < 0)
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
                            else
                            {
                                // New coordinates would cause ship to be lost, no instruction performed
                                continue;
                            }                 
                        }
                    }
                    ships.Add(ship);
                }

                // Print ship final position and orientation
                foreach (Ship shipFinal in ships)
                {        
                    CommandLine.PrintShipFinalPosition(shipFinal);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error has occured: " + ex.Message);
            }

            Console.WriteLine("End of program");
        }
    }
}
