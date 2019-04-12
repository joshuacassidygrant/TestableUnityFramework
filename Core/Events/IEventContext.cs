﻿using System;
using TofuCore.Service;

namespace TofuCore.Events
{
    public interface IEventContext
    {
        void TriggerEvent(string eventKey, EventPayload payload);
        TofuEvent GetEvent(string name);
        void ContextBindEventListener(TofuEvent evnt, IListener listener);
        void ContextRemoveEventListener(TofuEvent evnt, IListener listener);
    }
}