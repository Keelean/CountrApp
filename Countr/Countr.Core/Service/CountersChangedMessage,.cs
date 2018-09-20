using MvvmCross.Plugins.Messenger;
using System;
using System.Collections.Generic;
using System.Text;

namespace Countr.Core.Service
{
    public class CountersChangedMessage: MvxMessage
    {
        public CountersChangedMessage(object sender):base(sender)
        {

        }
    }
}
