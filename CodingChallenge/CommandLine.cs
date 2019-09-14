using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenge
{
    class CommandLine
    {
        public static List<Instruction> ReadInstructionsFromCommandLine()
        {
            List<Instruction> instructionList = new List<Instruction>();
            Console.WriteLine("Enter Ship Instructions");
            string instructions = Console.ReadLine();

            if (instructions.Length >= 100 || instructions.Length == 0)
            {
                throw new Exception("Invalid Instruction Length");
            }

            for (int i = 0; i < instructions.Length; i++)
            {
                if (!Enum.IsDefined(typeof(Instruction), (int)instructions[i]))
                {
                    throw new Exception("Invalid Ship Instruction");
                }
                else
                {
                    instructionList.Add((Instruction)instructions[i]);
                }
            }

            return instructionList;
        }

        public static Coordinates ReadCoordinatesFromCommandLine()
        {
            string commandInput;
            int mapXCoordinate;
            int mapYCoordinate;

            Console.WriteLine("Enter Map Size");
            commandInput = Console.ReadLine();
            var coordinates = commandInput.Split(' ');

            if (coordinates.Length != 2)
            {
                throw new Exception("Invalid Input");
            }

            mapXCoordinate = Int32.Parse(coordinates[0]);
            mapYCoordinate = Int32.Parse(coordinates[1]);

            if (mapXCoordinate < 1 || mapYCoordinate < 1 ||
                mapXCoordinate > 50 || mapYCoordinate > 50)
            {
                throw new Exception("Invalid Map Coordinate");
            }

            return new Coordinates(Int32.Parse(coordinates[0]), Int32.Parse(coordinates[1]));
        }

        public static Ship ReadShipFromCommandLine()
        {
            string commandInput;
            int shipXCoordinate;
            int shipYCoordinate;
            char shipOrientation;

            Console.WriteLine("Enter Ship Starting Position and Orientation");
            commandInput = Console.ReadLine();
            var shipPositionAndOrientation = commandInput.Split(' ');

            if (shipPositionAndOrientation.Length != 3)
            {
                throw new Exception("Invalid Input for Ship");
            }

            shipXCoordinate = int.Parse(shipPositionAndOrientation[0]);
            shipYCoordinate = int.Parse(shipPositionAndOrientation[1]);
            shipOrientation = char.Parse(shipPositionAndOrientation[2]);

            if (shipXCoordinate < 1 || shipYCoordinate < 1 ||
                shipXCoordinate > 50 || shipYCoordinate > 50)
            {
                throw new Exception("Invalid Ship Coordinate");
            }

            if (!Enum.IsDefined(typeof(Orientation), (int)shipOrientation))
            {
                throw new Exception("Invalid Ship Orientation");
            }

            return new Ship(new Coordinates(shipXCoordinate, shipYCoordinate), (Orientation)shipOrientation);
        }

        public static void PrintShipFinalPosition(Ship ship)
        {
            if (ship.isLost)
            {
                Console.WriteLine("Ship Final Position is: {0} {1} {2} LOST", ship.coordinates.x, ship.coordinates.y, (char)ship.orientation);
            }
            else
            {
                Console.WriteLine("Ship Final Position is: {0} {1} {2}", ship.coordinates.x, ship.coordinates.y, (char)ship.orientation);
            }
        }
    }
}
