using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core_NewServie.Models;

namespace Core_NewServie.Services
{
    public class EmployeeService : IService<Employee,int>
    {
        public EmployeeService()
        {
        }

        public Task<Employee> CreateDataAsync(Employee entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteDataAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Employee>> GetDataAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetDataAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> UpdateDataAsync(int id, Employee entity)
        {
            throw new NotImplementedException();
        }
    }
}
