using SpaceX.Models.Imps;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpaceX.Services.Interfaces
{
    public interface ISpaceZService
    {
        Task<SpaceZ> ScanPlateauAsync(SpaceZ space, List<string> commands);
        Task<(SpaceZ, List<string>)> PrepareSpaceZAsync(bool isFirst = false);
    }
}
