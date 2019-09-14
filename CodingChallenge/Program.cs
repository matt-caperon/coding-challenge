using System;

namespace CodingChallenge
{
    class Program
    {
        private static Coordinates MapSize;

        static void Main(string[] args)
        {     
            string commandInput;
            int mapXCoordinate;
            int mapYCoordinate;
            Ship ship;
            int shipXCoordinate;
            int shipYCoordinate;
            char shipOrientation;

            try
            {
                // Read map size from command line
                Console.WriteLine("Enter Map Size");
                commandInput = Console.ReadLine();
                var coordinates = commandInput.Split(' ');

                if (coordinates.Length != 2)
                {
                    Console.WriteLine("Invalid Input");
                    return;
                }

                mapXCoordinate = Int32.Parse(coordinates[0]);
                mapYCoordinate = Int32.Parse(coordinates[1]);

                if (mapXCoordinate < 1 || mapXCoordinate < 1)
                {
                    Console.WriteLine("Invalid Map Size");
                    return;
                }

                MapSize = new Coordinates(Int32.Parse(coordinates[0]), Int32.Parse(coordinates[1]));
                Console.WriteLine("Map Size is: {0} {1}", MapSize.x, MapSize.y);

                // Read ship starting position and orientation 
                Console.WriteLine("Enter Ship Starting Position and Orientation");
                commandInput = Console.ReadLine();
                var shipPositionAndOrientation = commandInput.Split(' ');

                if (shipPositionAndOrientation.Length != 3)
                {
                    Console.WriteLine("Invalid Input for Ship");
                    return;
                }

                shipXCoordinate = int.Parse(shipPositionAndOrientation[0]);
                shipYCoordinate = int.Parse(shipPositionAndOrientation[1]);
                shipOrientation = char.Parse(shipPositionAndOrientation[2]);

                if (!Enum.IsDefined(typeof(Orientation), (int)shipOrientation))
                {
                    Console.WriteLine("Invalid Ship Orientation");
                    return;
                }

                ship = new Ship(new Coordinates(shipXCoordinate, shipYCoordinate), (Orientation) shipOrientation);

            }
            catch(Exception ex)
            {
                Console.WriteLine("An error has occured: " + ex.Message);
            }

            Console.WriteLine("End of program");
        }
    }
}
