using System.Threading.Tasks;
using Challenge.Models;

namespace Challenge.Services
{
    public interface IJDoodleService
    {
        Task<JDoodleResponse> CompileAndExecuteCode(string script, string stdIn = null);
    }
}