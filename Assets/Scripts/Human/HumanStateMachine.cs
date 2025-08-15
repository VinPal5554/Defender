using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanStateMachine 
{
    public HumanState currentState { get; private set; }

    public void StateSetup(HumanState state)
    {
        currentState = state;
        currentState.Enter();


    }

    public void ChangeState(HumanState state)
    {
        currentState.Exit();
        currentState = state;
        currentState.Enter();
    }
}
