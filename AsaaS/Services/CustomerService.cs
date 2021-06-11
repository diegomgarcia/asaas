using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AsaaS.Contracts;
using AsaaS.Entities;

namespace AsaaS.Services
{
    public class CustomerRepositoryService : ICustomerService
    {
        private readonly ISettingsService _settingsService;
        private readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions() {
            IgnoreNullValues = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        
        public CustomerRepositoryService(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        public string ServiceUrl()
        {
            return _settingsService.CurrentSettings().Url + "customers/";
        }

        public async Task<Customer> CreateAsync(Customer model)
        {
            var data = JsonSerializer.Serialize(model, _jsonOptions);

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("access_token", _settingsService.CurrentSettings().AccessToken);
            
            var response = await client.PostAsync(
                ServiceUrl(),
                new StringContent(data, Encoding.UTF8, "application/json")
            );

            if (response.StatusCode != HttpStatusCode.OK) return null;
            
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Customer>(responseString, _jsonOptions);
        }

        public async Task<Customer> ReadAsync(string id)
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("access_token", _settingsService.CurrentSettings().AccessToken);
            
            var response = await client.GetAsync(
                ServiceUrl()+$"/{id}"
            );

            if (response.StatusCode != HttpStatusCode.OK) return null;
            
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Customer>(responseString, _jsonOptions);
        }

        public async Task<Customer> UpdateAsync(Customer model)
        {
            var data = JsonSerializer.Serialize(model, _jsonOptions);

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("access_token", _settingsService.CurrentSettings().AccessToken);
            
            var response = await client.PostAsync(
                ServiceUrl()+$"/{model.Id}",
                new StringContent(data, Encoding.UTF8, "application/json")
            );

            if (response.StatusCode != HttpStatusCode.OK) return null;
            
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Customer>(responseString, _jsonOptions);
        }

        public async Task<Boolean> DeleteAsync(string id)
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("access_token", _settingsService.CurrentSettings().AccessToken);
            
            var response = await client.DeleteAsync(
                ServiceUrl()+$"/{id}"
            );

            return response.StatusCode == HttpStatusCode.OK;
        }
    }
}