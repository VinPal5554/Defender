using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanderFlyingState : EnemyState
{
    protected Lander enemy;
    
    public LanderFlyingState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Lander _enemy) :
        base(_enemyBase, _stateMachine, _animBoolName)
    {
        enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();


    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        // if detected human    
            // go into mvoe state 
    }
}
