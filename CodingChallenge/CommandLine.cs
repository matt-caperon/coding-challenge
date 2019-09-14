using System;
using System.Collections.Generic;

namespace CodingChallenge
{
    class CommandLine
    {
        private const int MaxShips = 10;
        private const int MaxInstructionLength = 100;
        private const int MaxCoordinate = 50;
        private const int MinShipCoordinate = 0;
        private const int MinMapSizeCoorinate = 1;
        
        public static List<Instruction> ReadInstructionsFromCommandLine()
        {
            List<Instruction> instructionList = new List<Instruction>();
            Console.WriteLine("Enter Ship Instructions");
            string instructions = Console.ReadLine();

            if (instructions.Length >= MaxInstructionLength || instructions.Length == 0)
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

            if (mapXCoordinate < MinMapSizeCoorinate || mapYCoordinate < MinMapSizeCoorinate ||
                mapXCoordinate > MaxCoordinate || mapYCoordinate > MaxCoordinate)
            {
                throw new Exception("Invalid Map Coordinate");
            }

            return new Coordinates(Int32.Parse(coordinates[0]), Int32.Parse(coordinates[1]));
        }

        public static int ReadShipCountFromCommandLine()
        {
            string commandInput;
            int numberOfShips;

            // Read number of ships from command line
            Console.WriteLine("Enter Number of Ships");
            commandInput = Console.ReadLine();
            numberOfShips = int.Parse(commandInput);

            if (numberOfShips > MaxShips || numberOfShips < 1)
            {
                throw new Exception("Invalid Ship Number");
            }

            return numberOfShips;
        }

        public static Ship ReadShipFromCommandLine()
        {
            string commandInput;
            int shipXCoordinate;
            int shipYCoordinate;
            char shipOrientation;

            // Read ship starting position and orientation
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

            if (shipXCoordinate < MinShipCoordinate || shipYCoordinate < MinShipCoordinate ||
                shipXCoordinate > MaxCoordinate || shipYCoordinate > MaxCoordinate)
            {
                throw new Exception("Invalid Ship Coordinate");
            }

            if (!Enum.IsDefined(typeof(Orientation), (int)shipOrientation))
            {
                throw new Exception("Invalid Ship Orientation");
            }

            return new Ship(new Coordinates(shipXCoordinate, shipYCoordinate), (Orientation) shipOrientation);
        }

        public static void PrintShipFinalPosition(Ship ship)
        {
            if (ship.isLost)
            {
                Console.WriteLine("{0} {1} {2} LOST", ship.coordinates.x, ship.coordinates.y, (char)ship.orientation);
            }
            else
            {
                Console.WriteLine("{0} {1} {2}", ship.coordinates.x, ship.coordinates.y, (char)ship.orientation);
            }
        }
    }
}
