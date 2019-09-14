using System;

namespace CodingChallenge
{    
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

        public void TurnLeft()
        {
            switch (orientation)
            {
                case Orientation.North:
                    orientation = Orientation.West;
                    break;
                case Orientation.West:
                    orientation = Orientation.South;
                    break;
                case Orientation.South:
                    orientation = Orientation.East;
                    break;
                case Orientation.East:
                    orientation = Orientation.North;
                    break;
                default:
                    throw new Exception("Invalid Orientation");
            }
        }

        public void TurnRight()
        {
            switch (orientation)
            {
                case Orientation.North:
                    orientation = Orientation.East;
                    break;
                case Orientation.East:
                    orientation = Orientation.South;
                    break;
                case Orientation.South:
                    orientation = Orientation.West;
                    break;
                case Orientation.West:
                    orientation = Orientation.North;
                    break;
                default:
                    throw new Exception("Invalid Orientation");
            }
        }

        public void GoForward()
        {
            switch (orientation)
            {
                case Orientation.North:
                    coordinates.y++;
                    break;
                case Orientation.East:
                    coordinates.x++;
                    break;
                case Orientation.South:
                    coordinates.y--;
                    break;
                case Orientation.West:
                    coordinates.x--;
                    break;
                default:
                    throw new Exception("Invalid Orientation");
            }
        }

        public Coordinates GetNewCoordinatesOnForward()
        {
            // Set current coordinates
            Coordinates newCoordinates = coordinates;

            // Determine next coordinates if ship is moved forwards
            switch (orientation)
            {
                case Orientation.North:
                    newCoordinates.y++;
                    break;
                case Orientation.East:
                    newCoordinates.x++;
                    break;
                case Orientation.South:
                    newCoordinates.y--;
                    break;
                case Orientation.West:
                    newCoordinates.x--;
                    break;
                default:
                    throw new Exception("Invalid Orientation");
            }
            return newCoordinates;
        }
    }
}
