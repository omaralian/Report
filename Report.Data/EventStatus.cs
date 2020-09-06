using System;
using System.Collections.Generic;
using System.Text;

namespace Report.Data
{
    public enum EventStatus
    {
        Scheduled, // The event's Date Start is in the future. When events are generated, or when you manually enter an event, by default, its status is set to Scheduled.
        Canceled, // The event has been cancelled.
        InProgress, // The event has begun, but is not yet completed.
        OnHold, // The event has been placed on hold before it began.
        Stopped, // The event began but was stopped before completion.
        Completed, // The event has completed.
        Closed // The event has been closed.
    }
}
