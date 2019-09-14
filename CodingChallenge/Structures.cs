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

    enum Orientation : int
    {
        North = 'N',
        East = 'E',
        South = 'S',
        West = 'W'
    }
    enum Instruction : int
    {
        Left = 'L',
        Right = 'R',
        Forward = 'F'
    }

}
