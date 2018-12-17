﻿using System.Collections;
using System.Collections.Generic;
using TUFFYCore.Events;
using TUFFYCore.Service;
using UnityEngine;

namespace TUFFYPlugins.FrameUpdateService
{
    public class FrameUpdateService : AbstractMonoService
    {

        [Dependency("EventContext")] private EventContext _eventContext;

        void Update()
        {
            UpdateTime(Time.deltaTime);

        }

        public void ForceUpdate(float seconds)
        {
            UpdateTime(seconds);
        }

        void UpdateTime(float seconds)
        {
            EventPayload deltaTimePayload = new EventPayload(PayloadContentType.Float, seconds);
            _eventContext.TriggerEvent(_eventContext.GetEvent("FrameUpdate"), deltaTimePayload);
        }
    }
}

