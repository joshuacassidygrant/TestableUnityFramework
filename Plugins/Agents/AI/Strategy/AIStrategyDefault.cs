﻿using System.Collections.Generic;
using TofuPlugin.Agents.AgentActions;
using TofuPlugin.Agents.Commands;

namespace TofuPlugin.Agents.AI.Strategy
{
    /*
     * A stupid strategy for testing.
     */
    public class AIStrategyDefault : AIStrategy {


        //Stub
        public override AgentCommand PickCommand() {

            AgentAction action = FindActionById("idle");

            if (action == null)
            {
                return new AgentCommand(new AgentActionIdle("idle", "Idle"), new TargettableDefault(), 0);
            }

            return new AgentCommand(action, new TargettableDefault(), 0);

        }



    }
}
