using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.RegisterInformation.Repository
{
    public interface IRepositoryService<T> where T : class
    {

        Task<bool> InsertAsync(T obj);
        Task<bool> UpdateAsync(T obj);
        Task<bool> DeleteAsync(int id);

        Task<bool> Delete_Without_IdAsync(Expression<Func<T, bool>> expression);


        Task<T> FindAsync(int id);
        Task<T> Find_Without_IdAsync(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> GetListByWhere(Expression<Func<T, bool>> expression);

    }
}
