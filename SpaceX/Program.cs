using Microsoft.Extensions.DependencyInjection;
using SpaceX.Models.Imps;
using SpaceX.Services.Imps;
using SpaceX.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpaceX
{
    public class Program
    {
        static async Task Main()
        {
            #region main

            var serviceProvider = GetServiceProvider();
            var spaceService = serviceProvider.GetService<ISpaceZService>();
            var rovers = new List<Task<SpaceZ>>();

            var rover1 = await Task.Run(async () =>
            {
                var (spaceZ, commands) = await spaceService.PrepareSpaceZAsync(true);
                return spaceService.ScanPlateauAsync(spaceZ, commands);
            });
            rovers.Add(rover1);
            await Task.WhenAll(rover1);

            var rover2 = await Task.Run(async () =>
            {
                var (spaceZ, commandList) = await spaceService.PrepareSpaceZAsync();
                return spaceService.ScanPlateauAsync(spaceZ, commandList);
            });
            rovers.Add(rover2);
            await Task.WhenAll(rover2);

            PrintValues(rovers);
            #endregion

        }

        #region privates
        private static void PrintValues(List<Task<SpaceZ>> rovers)
        {
            foreach (var rover in rovers)
            {
                var result = rover.Result;
                Console.WriteLine(string.Concat(result.X, " ", result.Y, " ", result.Direction));
            }
            Console.ReadKey();
        }

        private static ServiceProvider GetServiceProvider()
        {
            return new ServiceCollection()
             .AddSingleton<ISpaceZService, SpaceZService>()
             .BuildServiceProvider();
        }
        #endregion
    }
}
