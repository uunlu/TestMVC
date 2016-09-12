using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using testweb.Models;

namespace testweb.Services
{
    public interface IEntityService
    {
        IList<T> GetAll<T>();

        Task<T> GetById<T>(string id) where T : BaseClass;

        Task DeleteAsync<T>(T entity) where T : BaseClass;

        Task UpdateAsync<T>(T entity) where T : BaseClass;

        Task InsertAsync<T>(T entity) where T : BaseClass;

        Task InsertBulkAsync<T>(List<T> entities) where T : BaseClass;
    }
}