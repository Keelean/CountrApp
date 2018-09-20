using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Countr.Core.Models;
using Countr.Core.Repositories;
using MvvmCross.Plugins.Messenger;

namespace Countr.Core.Service
{
    public class CountersService : ICountersService
    {
        readonly ICounterRepository repository;
        readonly IMvxMessenger messenger;

        public CountersService(ICounterRepository repository,IMvxMessenger messenger)
        {
            this.repository = repository;
            this.messenger = messenger;
        }

        public async Task<Counter> AddNewCounter(string name)
        {
            var counter = new Counter { Name = name };
            await repository.Save(counter).ConfigureAwait(false);
            //messenger.Publish(new CountersChangedMessage(this));
            return counter;
        }

        public async Task DeleteCounter(Counter counter)
        {
            await repository.Delete(counter).ConfigureAwait(false);
            messenger.Publish(new CountersChangedMessage(this));
            
        }

        public Task<List<Counter>> GetAllCounters()
        {
            return repository.GetAll();
        }

        public Task IncrementCounter(Counter counter)
        {
            counter.Count += 1;
            return repository.Save(counter);
        }
    }
}
