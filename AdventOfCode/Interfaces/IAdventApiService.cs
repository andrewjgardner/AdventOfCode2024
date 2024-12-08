using System.Threading.Tasks;

namespace AdventOfCode.Interfaces;

public interface IAdventApiService
{
    public Task<string> RetrieveTestInputByDay(int day);

}