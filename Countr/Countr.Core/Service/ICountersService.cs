using Countr.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Countr.Core.Service
{
    public interface ICountersService
    {
        Task<Counter> AddNewCounter(string name);
        Task<List<Counter>> GetAllCounters();
        Task DeleteCounter(Counter counter);
        Task IncrementCounter(Counter counter);
    }
}
