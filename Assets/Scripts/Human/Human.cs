using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : Entity
{
    [Header("Movement Stuff")]
    public float moveSpeed = 10.0f;

    public bool IsAbducted { get; private set; }
    public bool IsMutant { get; private set; }

    public HumanStateMachine stateMachine { get; private set; }
    public HumanIdleState idleState { get; private set; }
    public HumanMutantState mutantState { get; private set; }

    protected override void Awake()
    {
        base.Awake();

        stateMachine = new HumanStateMachine();
        idleState = new HumanIdleState(this, stateMachine, "Idle");
        mutantState = new HumanMutantState(this, stateMachine, "Mutant");
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

    public void Abduct()
    {
        IsAbducted = true;

        // maybe trigger animation, disable player interaction, etc.
    }

    public void Release()
    {
        IsAbducted = false;
        // drop logic, reset state
    }

    public void TransformIntoMutant()
    {
        IsAbducted = false;
        IsMutant = true;

        if (rb != null)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.gravityScale = 0;
        }

        stateMachine.ChangeState(mutantState);
    }
}
