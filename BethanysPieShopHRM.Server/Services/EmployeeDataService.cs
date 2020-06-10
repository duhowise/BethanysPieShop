using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using BethanysPieShopHRM.Shared;
using Microsoft.Extensions.DependencyInjection;

namespace BethanysPieShopHRM.Server.Services
{
    public class EmployeeDataService:IEmployeeDataService
    {
        private readonly HttpClient _httpClient;
        private readonly string baseUrl = "api/employee";
        public EmployeeDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Employee>>(
                await _httpClient.GetStreamAsync(baseUrl),
                new JsonSerializerOptions {PropertyNameCaseInsensitive = true});
        }

        public async Task<Employee> GetAllEmployeeDetails(int employeeId)
        {
            return await JsonSerializer.DeserializeAsync<Employee>(
                await _httpClient.GetStreamAsync($"{baseUrl}/{employeeId}"),
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public Task<Employee> AddEmployee(Employee employee)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateEmployee(Employee employee)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteEmployee(int employeeId)
        {
            throw new System.NotImplementedException();
        }
    }
}