using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    [SerializeField] protected LayerMask player;

    [Header("Move Stuff")]
    public float moveSpeed;
    public float idleTime;
    public float battleTime;

    public EnemyStateMachine stateMachine { get; private set; }
    public string lastAnimBoolName { get; private set; }

    protected override void Awake()
    {
        stateMachine = new EnemyStateMachine();

    }

    protected override void Update()
    {
        base.Update();

        stateMachine.currentState.Update();
    }


}
