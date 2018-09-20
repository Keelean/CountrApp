using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Support.V7.Widget;
//using Android.Widget;
using Countr.Core.ViewModels;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Support.V7.RecyclerView;
using Android.Support.V7.Widget.Helper;

namespace Countr.Droid.Views
{
    [Activity(Label = "@string/ApplicationName")]
    public class CountersView: MvxAppCompatActivity<CountersViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.counters_view);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            var recyclerView = FindViewById<MvxRecyclerView>(Resource.Id.recycler_view);
            recyclerView.SetLayoutManager(new LinearLayoutManager(this));
            var callback = new SwipeItemTouchHelperCallback(ViewModel);
            var touchHelper = new ItemTouchHelper(callback);
            touchHelper.AttachToRecyclerView(recyclerView);
        }
    }
}