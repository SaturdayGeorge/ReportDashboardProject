using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReportDashboard.Abstract
{
    public interface IRepository<T> : IDisposable
    {
        Task<IEnumerable<T>> GetAll();
    }
}
