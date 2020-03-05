using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine :  MonoBehaviour
{
    private IState state;
    private IState nextState;
    private IStateTransition transition;
    public StateMachine(IState initialState)
    {
        state = initialState;
        state.EndEnter();
    }
   
}
