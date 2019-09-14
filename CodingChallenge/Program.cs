using System;

namespace CodingChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Coordinates MapSize;
            Ship ship;
              
            try
            {
                // Read map size from command line
                MapSize = ReadCoordinatesFromCommandLine();
                Console.WriteLine("Map Size is: {0} {1}", MapSize.x, MapSize.y);

                // Read ship starting position and orientation 
                ship = ReadShipFromCommandLine();

                PrintShipFinalPosition(ship);
            }
            catch(Exception ex)
            {
                Console.WriteLine("An error has occured: " + ex.Message);
            }

            Console.WriteLine("End of program");
        }

        private static Coordinates ReadCoordinatesFromCommandLine()
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

            if (mapXCoordinate < 1 || mapXCoordinate < 1)
            {
                throw new Exception("Invalid Map Size");
            }

            return new Coordinates(Int32.Parse(coordinates[0]), Int32.Parse(coordinates[1]));       
        }

        private static Ship ReadShipFromCommandLine()
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

            if (!Enum.IsDefined(typeof(Orientation), (int)shipOrientation))
            {
                throw new Exception("Invalid Ship Orientation");
            }

            return new Ship(new Coordinates(shipXCoordinate, shipYCoordinate), (Orientation)shipOrientation);
        }

        private static void PrintShipFinalPosition(Ship ship)
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
