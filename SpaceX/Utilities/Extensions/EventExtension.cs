using SpaceX.Models.Interfaces;

namespace SpaceX.Utilities.Extensions
{
    public static class EventExtension
    {
        public static ISpaceX Spin(this ISpaceX model, string currentDirectory, string newDirectory)
        {
            var nextDirectory = string.Empty;
            switch (newDirectory)
            {
                case "L":
                    if (currentDirectory == "N") nextDirectory = "W";
                    if (currentDirectory == "W") nextDirectory = "S";
                    if (currentDirectory == "S") nextDirectory = "E";
                    if (currentDirectory == "E") nextDirectory = "N";
                    break;
                case "R":
                    if (currentDirectory == "N") nextDirectory = "E";
                    if (currentDirectory == "W") nextDirectory = "N";
                    if (currentDirectory == "S") nextDirectory = "W";
                    if (currentDirectory == "E") nextDirectory = "S";
                    break;
            }
            model.Direction = nextDirectory;
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
