using System;
using System.Collections.Generic;
using System.Text;

namespace OC.Xamarin.Forms.ExpandableView
{
    public sealed class StatusChangedEventArgs : EventArgs
    {
        public StatusChangedEventArgs(ExpandStatus status)
        {
            Status = status;
        }

        public ExpandStatus Status { get; }
    }
}
