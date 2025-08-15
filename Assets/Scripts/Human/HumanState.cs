using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanState 
{
    protected HumanStateMachine stateMachine;
    protected Human human;
    private string animBoolName;
    protected float stateTimer;
    protected bool triggerCalled;

    public HumanState(Human _human, HumanStateMachine _stateMachine, string _animBoolName)
    {
        this.human = _human;
        this.stateMachine = _stateMachine;
        this.animBoolName = _animBoolName;


    }

    public virtual void Enter()
    {
        human.anim.SetBool(animBoolName, true);
        triggerCalled = false;


    }

    public virtual void Update()
    {
        stateTimer = Time.deltaTime;



    }

    public virtual void Exit()
    {

        human.anim.SetBool(animBoolName, false);



    }
}
