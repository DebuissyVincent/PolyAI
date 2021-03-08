using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Act : Task
{
    private string action;
    private bool active;

    /// <summary>
    /// Will call an animator's bool parameter.
    /// </summary>
    /// <param name="_agent">Agent's reference.</param>
    /// <param name="_action">Parameter's name.</param>
    /// <param name="_value">Parameter's value.</param>
    public Act(PolyAgentBase _agent, string _action) : base(_agent)
    {
        action = _action;
    }

    public override NodeState Tick()
    {   
        Animator animator = agent.GetComponent<Animator>();
        if (animator)
        {
            if (animator.GetBool(action))
            {
                // Get most recent anim
                AnimatorStateInfo animState = animator.GetNextAnimatorStateInfo(0);
                if (animState.IsName(""))
                {
                    animState = animator.GetCurrentAnimatorStateInfo(0);
                }
                // Is anim finished
                if (animState.normalizedTime >= 1.0f)
                {
                    animator.SetBool(action, false);
                    state = NodeState.Success;
                }
            }
            else
            {
                Debug.Log(action);
                animator.SetBool(action, true);
                state = NodeState.Running;
            }
        }
        else
        {
            Debug.LogError("There are no animator on the agent.");
            state = NodeState.Error;
        }
        return state;
    }
}
