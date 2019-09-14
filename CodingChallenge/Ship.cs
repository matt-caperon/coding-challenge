
using static CodingChallenge.Program;

namespace CodingChallenge
{
    public struct Coordinates
    {
        public int x { get; set; }
        public int y { get; set; }

        public Coordinates(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    enum Orientation{
        North = 'N', 
        East = 'E',
        South = 'S',
        West = 'W'
    }
    
    class Ship
    {
        public bool isLost { get; set; }

        public Coordinates coordinates;

        public Orientation orientation { get; set; }

        public Ship(Coordinates coordinates, Orientation orientation)
        {
            this.coordinates = coordinates;
            this.orientation = orientation;
        }

    }
}
