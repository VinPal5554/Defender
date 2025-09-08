using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanMutantState : HumanState
{
    private Transform player;
    private float chaseSpeed = 3f;

    public HumanMutantState(Human _human, HumanStateMachine _stateMachine, string _animBoolName) : base(_human, _stateMachine, _animBoolName)
    {

    }

    public override void Enter()
    {
        base.Enter();

        if (player != null)
            player = GameObject.FindGameObjectWithTag("Player").transform;
     
            

    
    }

    public override void Update()
    {
        base.Update();

        if (player != null)
        {
            Vector2 dir = (player.position - human.transform.position).normalized;
            human.rb.velocity = dir * chaseSpeed;
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}