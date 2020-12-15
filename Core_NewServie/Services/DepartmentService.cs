using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core_NewServie.Models;
using Microsoft.EntityFrameworkCore;

namespace Core_NewServie.Services
{
    public class DepartmentService : IService<Department,int>
    {
        private readonly CompanyDbContext context;
        /// <summary>
        /// Inject the DbContext in Repository
        /// </summary>
        /// <param name="context"></param>
        public DepartmentService(CompanyDbContext context)
        {
            this.context = context;
        }

        public async Task<Department> CreateDataAsync(Department entity)
        {
            // adding a new entity in DbSet
            var result = await context.Departments.AddAsync(entity);
            // commit trsnsaction
            await context.SaveChangesAsync();
            return result.Entity; // returned the commit entity
        }

        public async Task<bool> DeleteDataAsync(int id)
        {
            // serach record based on P.K.
            var record = await context.Departments.FindAsync(id);
            if (record == null) return false;
            else
            {
                context.Departments.Remove(record);
                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<IEnumerable<Department>> GetDataAsync()
        {
            return await context.Departments.ToListAsync();
        }

        public async Task<Department> GetDataAsync(int id)
        {
            var record = await context.Departments.FindAsync(id);
            return record;
        }

        public async Task<Department> UpdateDataAsync(int id, Department entity)
        {
            var record = await context.Departments.FindAsync(id);
            if (record == null) return entity;


          //  context.Entry<Department>(entity).State = EntityState.Modified;

            // replace values of record
            record.DeptName = entity.DeptName;
            record.Location = entity.Location;
            record.Capacity = entity.Capacity;
            await context.SaveChangesAsync();
            return record;

        }
    }
}
