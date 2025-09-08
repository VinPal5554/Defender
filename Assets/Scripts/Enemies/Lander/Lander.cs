using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lander : Enemy
{
    public float detectionRange = 500f;
    public Transform targetHuman;

    public LanderIdleState idleState { get; private set; }
    public LanderMoveState moveState { get; private set; }  
    public LanderAbductState abductState { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        idleState = new LanderIdleState(this, stateMachine, "Idle", this);
        moveState = new LanderMoveState(this, stateMachine, "Idle", this);
        abductState = new LanderAbductState(this, stateMachine, "Idle", this);
    }
  

    protected override void Start()
    {
        base.Start();

        stateMachine.StateSetup(idleState);
    }

    protected override void Update()
    {
        base.Update();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }

}
