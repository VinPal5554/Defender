using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : Entity
{
    [Header("Movement Stuff")]
    public float moveSpeed = 10.0f;

    public HumanStateMachine stateMachine { get; private set; }

    public HumanIdleState idleState { get; private set; }

    protected override void Awake()
    {
        base.Awake();

        stateMachine = new HumanStateMachine();
        idleState = new HumanIdleState(this, stateMachine, "Idle");
    }

    protected override void Start()
    {
        base.Start();

        stateMachine.StateSetup(idleState);
    }

    protected override void Update()
    {
        base.Update();

        stateMachine.currentState.Update();


    }
}
