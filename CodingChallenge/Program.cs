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
                    Console.WriteLine("Invalid Map Sizez");
                    return;
                }

                MapSize = new Coordinates(Int32.Parse(coordinates[0]), Int32.Parse(coordinates[1]));

                Console.WriteLine("Map Size is: {0} {1}", MapSize.x, MapSize.y);

            }
            catch(Exception ex)
            {
                Console.WriteLine("An error has occured: " + ex.Message);
            }

            Console.WriteLine("End of program");
        }
    }
}
