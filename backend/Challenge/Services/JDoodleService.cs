using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Challenge.Models;
using Microsoft.Extensions.Options;

namespace Challenge.Services
{
    public class JDoodleService : IJDoodleService
    {
        private readonly HttpClient _httpClient;
        private readonly JDoodleOptions _options;

        public JDoodleService(HttpClient httpClient, IOptions<JDoodleOptions> jDoodleOptions)
        {
            _httpClient = httpClient;
            _options = jDoodleOptions.Value;
        }

        public async Task<JDoodleResponse> CompileAndExecuteCode(string script, string stdIn = null)
        {
            var jDoodleEntry = new JDoodleEntry
            {
                ClientId = _options.ClientId,
                ClientSecret = _options.ClientSecret,
                Language = _options.Language,
                VersionIndex = _options.VersionIndex,
                Script = script,
                StdIn = stdIn
            };

            var @string = JsonSerializer.Serialize(jDoodleEntry);
            using var content = new StringContent(@string, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(_options.ExecuteEndpoint, content);
            var result = await response.Content.ReadFromJsonAsync<JDoodleResponse>();

            return result;
        }
    }
}