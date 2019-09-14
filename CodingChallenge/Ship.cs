
namespace CodingChallenge
{
    enum Orientation{
        North = 'N', 
        East = 'E',
        South = 'S',
        West = 'W'
    }
    
    class Ship
    {
        public bool IsLost { get; set; }
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public Orientation Orientation { get; set; }
    }
}
