﻿using System.Collections.Generic;
using Scripts.Sensors;
using TofuPlugin.Agents.AgentActions;
using TofuPlugin.Agents.Commands;
using UnityEngine;

namespace TofuPlugin.Agents.AI.Strategy
{
    /*
     * Class to determine AI targetting and longterm planning, action use etc.
     * Plug into AIAgentController.
     */
    public abstract class AIStrategy
    {
        private AbstractSensor _sensor;
        protected IControllableAgent Agent;
        
        public void BindAgent(IControllableAgent agent)
        {
            Agent = agent;
        }

        public void SetSensor(AbstractSensor sensor)
        {
            _sensor = sensor;
        }

        public AgentAction FindActionById(string id)
        {
            List<AgentAction> actions = Agent.Actions;
            AgentAction action = Agent.Actions.Find(x => x.Id == id);
            if (action == null)
            {
                Debug.Log("No action found for id: " + id);
                return new AgentActionIdle("idleX", "IdleX");
            }
            return action;
        }

        public abstract AgentCommand PickCommand();

    }
}
