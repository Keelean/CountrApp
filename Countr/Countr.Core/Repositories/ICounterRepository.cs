using Countr.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Countr.Core.Repositories
{
    public interface ICounterRepository
    {
        Task Save(Counter counter);
        Task<List<Counter>> GetAll();
        Task Delete(Counter counter);
    }
}
