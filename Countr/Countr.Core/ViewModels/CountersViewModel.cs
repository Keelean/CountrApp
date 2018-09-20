using Countr.Core.Models;
using Countr.Core.Service;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Countr.Core.ViewModels
{
    public class CountersViewModel:MvxViewModel
    {
        readonly ICountersService service;
        readonly MvxSubscriptionToken token;
        readonly IMvxNavigationService navigationService;

        public CountersViewModel(ICountersService service, IMvxMessenger messenger, IMvxNavigationService navigationService)
        {
            this.navigationService = navigationService;
            token = messenger.SubscribeOnMainThread<CountersChangedMessage>(async m => await LoadCounters());
            this.service = service;
            Counters = new ObservableCollection<CounterViewModel>();
            ShowAddNewCounterCommand = new MvxAsyncCommand(ShowAddNewCounter);
        }

        public ObservableCollection<CounterViewModel> Counters { get; }

        public IMvxAsyncCommand ShowAddNewCounterCommand { get; }
        async Task ShowAddNewCounter()
        {
            await navigationService.Navigate<Counter>(typeof(CounterViewModel), new Counter());
        }

        public override async Task Initialize()
        {
            Counters.Clear();
            await LoadCounters();
        }


        public async Task LoadCounters()
        {
            var counters = await service.GetAllCounters();
            foreach (var counter in counters)
            {
                var viewModel = new CounterViewModel(service,navigationService);
                viewModel.Prepare(counter);
                Counters.Add(viewModel);
            }
        }
    }
}
