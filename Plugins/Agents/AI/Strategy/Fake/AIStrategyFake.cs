﻿using System.Collections.Generic;
using TofuPlugin.Agents.AgentActions;
using TofuPlugin.Agents.AI.Strategy;

namespace Scripts.Agents.Strategy {

    /*
     * A stupid strategy for testing.
     */
    public class AIStrategyFake : AIStrategy {


        //Stub
        public override AgentAction PickAction(List<AgentAction> actions) {

            if (actions.Count > 0) return actions[0];
            return null;
        }



    }
}
