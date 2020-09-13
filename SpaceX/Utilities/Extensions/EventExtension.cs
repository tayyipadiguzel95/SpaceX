using SpaceX.Models.Interfaces;

namespace SpaceX.Utilities.Extensions
{
    public static class EventExtension
    {
        public static ISpaceX Spin(this ISpaceX model, string currentDirection, string newDirectory)
        {
            var nextDirection = string.Empty;
            switch (newDirectory)
            {
                case "L":
                    if (currentDirection == "N") nextDirection = "W";
                    if (currentDirection == "W") nextDirection = "S";
                    if (currentDirection == "S") nextDirection = "E";
                    if (currentDirection == "E") nextDirection = "N";
                    break;
                case "R":
                    if (currentDirection == "N") nextDirection = "E";
                    if (currentDirection == "W") nextDirection = "N";
                    if (currentDirection == "S") nextDirection = "W";
                    if (currentDirection == "E") nextDirection = "S";
                    break;
            }
            model.Direction = nextDirection;
            return model;
        }

        public static ISpaceX Move(this ISpaceX model, string currentDirection)
        {
            switch (currentDirection)
            {
                case "N":
                    model.Y += 1;
                    break;
                case "S":
                    model.Y += -1;
                    break;
                case "W":
                    model.X += -1;
                    break;
                case "E":
                    model.X += +1;
                    break;

            }
            return model;
        }
    }
}
