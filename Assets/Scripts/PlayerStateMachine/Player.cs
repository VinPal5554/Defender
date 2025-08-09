using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{

    [Header("Movement Stuff")]
    public float moveSpeed = 12.0f;



    public PlayerStateMachine stateMachine {  get; private set; }

    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }

    protected override void Awake()
    {
        base.Awake();

        stateMachine = new PlayerStateMachine();
        idleState = new PlayerIdleState(this, stateMachine, "Idle");
        moveState = new PlayerMoveState(this, stateMachine, "Move");
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
