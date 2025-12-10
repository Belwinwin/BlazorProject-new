using BlazorProject.Data;
using BlazorProject.Repository.iRepository;
using Dapper;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace BlazorProject.Repository
{
    public class OracleEmployeeRepository : iEmployeeRepository, IOracleEmployeeRepository
    {
        private readonly string _connStr;

        public OracleEmployeeRepository(IConfiguration config)
        {
            _connStr = config.GetConnectionString("OracleConnection")
                       ?? throw new InvalidOperationException("OracleConnection not found");
        }

        private OracleConnection CreateConnection() => new OracleConnection(_connStr);

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            const string sql = "SELECT ID, NAME, EMAIL, ROLE, PHONENUMBER FROM EMPLOYEES";
            await using var conn = CreateConnection();
            await conn.OpenAsync();
            var rows = await conn.QueryAsync<Employee>(sql);
            return rows;
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            const string sql = "SELECT ID, NAME, EMAIL, ROLE, PHONENUMBER FROM EMPLOYEES WHERE ID = :Id";
            await using var conn = CreateConnection();
            await conn.OpenAsync();
            return await conn.QuerySingleOrDefaultAsync<Employee>(sql, new { Id = id });
        }

        public async Task<int> AddAsync(Employee employee)
        {
            const string sql = "INSERT INTO EMPLOYEES (NAME, EMAIL, ROLE, PHONENUMBER) VALUES (:Name, :email, :role, :PhoneNumber)";
            await using var conn = CreateConnection();
            await conn.OpenAsync();
            return await conn.ExecuteAsync(sql, employee);
        }

        public async Task<int> UpdateAsync(Employee employee)
        {
            const string sql = "UPDATE EMPLOYEES SET NAME = :Name, EMAIL = :email, ROLE = :role, PHONENUMBER = :PhoneNumber WHERE ID = :Id";
            await using var conn = CreateConnection();
            await conn.OpenAsync();
            return await conn.ExecuteAsync(sql, employee);
        }

        public async Task<int> DeleteAsync(int id)
        {
            const string sql = "DELETE FROM EMPLOYEES WHERE ID = :Id";
            await using var conn = CreateConnection();
            await conn.OpenAsync();
            return await conn.ExecuteAsync(sql, new { Id = id });
        }

        // Interface methods
        public async Task<Employee> CreateAsync(Employee obj)
        {
            await AddAsync(obj);
            return obj;
        }

        async Task<Employee> iEmployeeRepository.UpdateAsync(Employee obj)
        {
            await UpdateAsync(obj);
            return obj;
        }

        async Task<bool> iEmployeeRepository.DeleteAsync(int id)
        {
            var result = await DeleteAsync(id);
            return result > 0;
        }

        public async Task<Employee> GetAsync(int id)
        {
            var result = await GetByIdAsync(id);
            return result ?? new Employee();
        }
    }
}
