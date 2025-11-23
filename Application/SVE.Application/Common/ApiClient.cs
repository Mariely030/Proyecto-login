using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

namespace SVE.Application.Common
{
    public abstract class ApiClient
    {
        protected readonly HttpClient _http;

        private readonly JsonSerializerOptions _options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        protected ApiClient(HttpClient http)
        {
            _http = http;
        }

        protected async Task<ApiResponse<T>> GetAsync<T>(string url)
        {
            return await _http.GetFromJsonAsync<ApiResponse<T>>(url, _options);
        }

        protected async Task<ApiResponse<T>> PostAsync<T>(string url, object data)
        {
            var response = await _http.PostAsJsonAsync(url, data);
            return await response.Content.ReadFromJsonAsync<ApiResponse<T>>(_options);
        }

        protected async Task<ApiResponse<T>> PutAsync<T>(string url, object data)
        {
            var response = await _http.PutAsJsonAsync(url, data);

            // Caso NoContent
            if (response.StatusCode == HttpStatusCode.NoContent)
                return new ApiResponse<T> { Success = true };

            var content = await response.Content.ReadAsStringAsync();

            if (string.IsNullOrWhiteSpace(content))
                return new ApiResponse<T> { Success = response.IsSuccessStatusCode };

            return JsonSerializer.Deserialize<ApiResponse<T>>(content, _options)!;
        }

        protected async Task<ApiResponse<T>> DeleteAsync<T>(string url)
        {
            var response = await _http.DeleteAsync(url);
            return await response.Content.ReadFromJsonAsync<ApiResponse<T>>(_options);
        }
    }
}



