using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{

    [Header("Movement Stuff")]
    public float maxMoveSpeed = 10f;
    public float maxVerticalSpeed = 6f;
    public float acceleration = 20f;
    public float deceleration = 15f;

    [HideInInspector] public Vector2 currentVelocity;

    public GameObject projectilePrefab;
    public Transform projectilePosition;
    public float fireRate = 0.3f;
    private float fireCooldown = 0.0f;


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

        HandleShooting();
        if (fireCooldown > 0f)
        {
            fireCooldown -= Time.deltaTime;
        }

    }

    void HandleShooting()
    {
        if (Input.GetKey(KeyCode.Space) && fireCooldown <= 0f)
        {
            Shoot();
            fireCooldown = fireRate;
        }
    }

    public void Shoot()
    {
        GameObject bullet = Instantiate(projectilePrefab, projectilePosition.position, Quaternion.identity);
        Projectile proj = bullet.GetComponent<Projectile>();

        Vector2 shootDir = facingRight ? Vector2.right : Vector2.left;
        proj.SetDirection(shootDir);
    }
}
