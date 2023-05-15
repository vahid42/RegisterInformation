using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;
using WebApi.RegisterInformation.Db;


namespace WebApi.RegisterInformation.Repository
{
    public class RepositoryService<T> : IRepositoryService<T> where T : class
    {
        private MyContext db = null;
        private DbSet<T> table = null;

        public RepositoryService(MyContext context)
        {
            db = context;
            table = db.Set<T>();
        }

     

        public async Task<bool> InsertAsync(T obj)
        {
            try
            {
                //addasync  Microsoft.EntityFrameworkCore 3.1.3.
                table.Add(obj);
                await SaveAsync();
                
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public async Task<bool> UpdateAsync(T obj)
        {
            try
            {
                // table.AsNoTracking(obj);
                //db.Entry(obj).State = EntityState.Modified;
                table.AddOrUpdate(obj);
                await SaveAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var entity = await table.FindAsync(id);
                table.Remove(entity);
                await SaveAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }


        }




        public async Task<bool> Delete_Without_IdAsync(Expression<Func<T, bool>> expression)
        {
            try
            {
                var entity = await table.Where(expression).FirstOrDefaultAsync();
                table.Remove(entity);
                await SaveAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }



   
        public async Task<T> FindAsync(int id)
        {

            return await table.FindAsync(id);
        }

        public async Task<T> Find_Without_IdAsync(Expression<Func<T, bool>> expression)
        {
            return await table.Where(expression).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetListByWhere(Expression<Func<T, bool>> expression)
        {
            return await table.Where(expression).ToListAsync();
        }






        private async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }

     }
}