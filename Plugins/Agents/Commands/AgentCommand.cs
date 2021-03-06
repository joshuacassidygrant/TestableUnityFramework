﻿using System.Collections;
using System.Collections.Generic;
using TofuCore.Command;
using TofuCore.Tangible;
using TofuPlugin.Agents.AgentActions;

namespace TofuPlugin.Agents.Commands
{
    /*
     *  An AgentCommand is a goal set by a Controller (either AI or human),
     *  responsible for finding and triggering AgentActions able to fulfill 
     *  that goal.
     *  
     *  AgentCommands can interrupt themselves or be interrupted by a controller 
     *  when a situation arises.
     */
    public class AgentCommand : Command
    {

        public AgentAction Action;
        public Stack<AgentAction> ActionStack;
        public ITangible Target;
        public int Priority;

        public AgentCommand(AgentAction action, ITangible target, int priority)
        {
            Action = action;
            Target = target;
            Priority = priority;
        }

        public virtual bool Executable()
        {
            return Target != null /*&& Target.Active*/;
        }

        public bool IsFinished()
        {
            return Action == null || Action.CurrentCooldown > 0;
            //return ActionStack.Count == 0;
        }

        public override bool TryExecute()
        {
            if (Action.Ready())
            {
                //TODO: check all action preconditions here -- in range, resource costs, condition preconditions, etc
                // If not satisfied, add the precondition to the action stack.
                if (!Action.InRange(Target))
                {
                    //Action.Agent.GetMobilityActions();
                    //TEMP:
                    //Action.Agent.GetMoveAction().TriggerAction(Target);
                    if (Action.Agent.Mobility.MoveTarget != Target)
                    {
                        Action.Agent.Mobility.SetMoveTarget(Target, 0.1f);
                    }
                    return false;
                }
                else
                {
                    Action.Agent.Mobility.UnsetMoveTarget();
                }

                Action.TriggerAction(Target);
                return true;
            }
            return false;

        }

    

        public override string ToString()
        {
            return Action.Name + " targetting " + Target.ToString();
        }
    }
}
