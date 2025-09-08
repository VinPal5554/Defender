using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanderMoveState : LanderFlyingState
{
    private Lander lander;

    public LanderMoveState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Lander _enemy) :
        base(_enemyBase, _stateMachine, _animBoolName, _enemy)
    {
        lander = _enemy;
    }

    public override void Enter()
    {
        base.Enter();
        lander.targetHuman = null;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        // 1. Check for humans in range
        if (lander.targetHuman == null)
        {
            lander.targetHuman = FindNearestHuman();
        }

        // 2. If found a human ? move toward it
        if (lander.targetHuman != null)
        {
            Vector2 dir = (lander.targetHuman.position - lander.transform.position).normalized;
            lander.SetVelocity(dir.x * lander.moveSpeed, dir.y * lander.moveSpeed);

            // Close enough? Start abduction
            float dist = Vector2.Distance(lander.transform.position, lander.targetHuman.position);
            if (dist < 0.5f)
            {
                Human human = lander.targetHuman.GetComponent<Human>();
                if (human != null && !human.IsAbducted)
                {
                   // human.Abduct();
                   stateMachine.ChangeState(lander.abductState);
                }
            }
        }
        else
        {
            // 3. Otherwise just wander (e.g. left/right drift)
            lander.SetVelocity(lander.moveSpeed, 0f);
        }

    }

    private Transform FindNearestHuman()
    {
        Human[] humans = GameObject.FindObjectsOfType<Human>();
        Transform nearest = null;
        float minDist = Mathf.Infinity;

        foreach (var h in humans)
        {
            if (h.IsMutant) continue;

            float d = Vector2.Distance(lander.transform.position, h.transform.position);
            if (d < lander.detectionRange && d < minDist && !h.IsAbducted)
            {
                minDist = d;
                nearest = h.transform;
            }
        }

        return nearest;
    }
}
