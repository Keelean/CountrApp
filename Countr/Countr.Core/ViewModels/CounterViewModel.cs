using Countr.Core.Models;
using Countr.Core.Service;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Countr.Core.ViewModels
{
    public class CounterViewModel : MvxViewModel<Counter>
    {

        readonly ICountersService service;
        readonly IMvxNavigationService navigationService;

        public CounterViewModel(ICountersService service, IMvxNavigationService navigationService)
        {
            this.service = service;
            this.navigationService = navigationService;
            IncrementCommand = new MvxAsyncCommand(IncrementCounter);
            DeleteCommand = new MvxAsyncCommand(DeleteCounter);
            CancelCommand = new MvxAsyncCommand(Cancel);
            SaveCommand = new MvxAsyncCommand(Save);
        }

        public IMvxAsyncCommand IncrementCommand { get; }

        public IMvxAsyncCommand CancelCommand { get; }
        public IMvxAsyncCommand SaveCommand { get; }

        public IMvxAsyncCommand DeleteCommand { get; }
        async Task DeleteCounter()
        {
            await service.DeleteCounter(counter);
        }

        async Task IncrementCounter()
        {
            await service.IncrementCounter(counter);
            RaisePropertyChanged(() => Count);
        }

        Counter counter;
        public override void Prepare(Counter parameter)
        {
            counter = parameter;
        }

        async Task Cancel()
        {
            await navigationService.Close(this);
        }
        async Task Save()
        {
            //Task.Delay(TimeSpan.FromSeconds(30)).Wait();TimeSpan.FromMilliseconds(600);
            await service.AddNewCounter(counter.Name);
            await navigationService.Navigate(typeof(CountersViewModel));
            //await navigationService.Close(this); //original code from author
        }

        public string Name
        {
            get { return counter.Name; }
            set
            {
                if (Name == value) return;
                counter.Name = value;
                RaisePropertyChanged();
            }
        }

        public int Count => counter.Count;
    }
}
