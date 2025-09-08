using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanderAbductState : LanderFlyingState
{
    private Lander lander;

    public LanderAbductState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Lander _enemy)
        : base(_enemyBase, _stateMachine, _animBoolName, _enemy)
    {
        lander = _enemy;
    }

    public override void Enter()
    {
        base.Enter();

        if (lander.targetHuman != null)
        {
            Human human = lander.targetHuman.GetComponent<Human>();
            if (human != null && !human.IsAbducted)
            {
                // Mark human as abducted
                human.Abduct();

                // Parent human to Lander so it follows
                lander.targetHuman.SetParent(lander.transform);
            }
        }
    }

    public override void Exit()
    {
        base.Exit();

        // Make sure the human isn’t stuck parented if something interrupts abduction
        if (lander.targetHuman != null)
        {
            lander.targetHuman.SetParent(null);
        }
    }

    public override void Update()
    {
        base.Update();

        // Move upward while carrying human
        lander.SetVelocity(0f, lander.moveSpeed);

        // Example: once Lander reaches a certain height, drop the human
        if (lander.transform.position.y > 8f) // arbitrary ceiling
        {
            if (lander.targetHuman != null)
            {
                Human human = lander.targetHuman.GetComponent<Human>();
                if (human != null)
                {
                    human.TransformIntoMutant();
                }

                // Unparent human
                lander.targetHuman.SetParent(null);
                lander.targetHuman = null;
            }

            // Go back to idle once done
            stateMachine.ChangeState(lander.idleState);
        }
    }
}
