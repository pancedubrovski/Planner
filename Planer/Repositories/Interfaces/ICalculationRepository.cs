using Planer.Models.Responses;

namespace Planer.Repositories.Interfaces
{
    public interface ICalculationRepository
    {
        public Task<BugetResponse> CalcuateBuget();
    }
}
