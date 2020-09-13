using SpaceX.Models.Imps;
using SpaceX.Services.Interfaces;
using SpaceX.Utilitie.Constants;
using SpaceX.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceX.Services.Imps
{
    public class SpaceZService : ISpaceZService
    {
        public async Task<(SpaceZ, List<string>)> PrepareSpaceZAsync(bool isFirst = false)
        {
            return await Task.Run(() =>
            {
                if (isFirst)
                {
                    var gridSize = Console.ReadLine();
                    var gridCor = gridSize.Split(" ");
                }

                var coordinates = Console.ReadLine().Split(" ").ToList();
                var spaceZ = new SpaceZ
                {
                    Direction = coordinates.LastOrDefault(),
                    X = Convert.ToInt32(coordinates.FirstOrDefault()),
                    Y = Convert.ToInt32(coordinates[1])
                };

                var data = Console.ReadLine();
                var commands = data.ToCharArray();
                var commandList = new List<string>();
                foreach (var item in commands)
                {
                    commandList.Add(item.ToString());
                }
                return (spaceZ, commandList);
            });
        }

        public async Task<SpaceZ> ScanPlateauAsync(SpaceZ space, List<string> commands)
        {
            return await Task.Run(() =>
             {
                 var currentDirection = space.Direction;
                 foreach (var command in commands)
                 {
                     if (command == ControlTypes.Left || command == ControlTypes.Right)
                     {
                         space = (SpaceZ)space.Spin(currentDirection, command);
                         currentDirection = space.Direction;
                     }
                     else
                     {
                         space = (SpaceZ)space.Move(currentDirection);
                     }
                 }
                 return space;
             });
        }
    }
}
