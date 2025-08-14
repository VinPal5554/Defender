using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public Animator anim { get; private set; }
    public Rigidbody2D rb { get; private set; }
    public SpriteRenderer sr { get; private set; }
    public BoxCollider2D bc { get; private set; }

    public int facingDirection { get; private set; } = 1;
    protected bool facingRight = true;


    protected virtual void Awake()
    {

    }

    protected virtual void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponentInChildren<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();

    }

    protected virtual void Update()
    {

    }

    public virtual void SetVelocity(float _xVelocity,  float _yVelocity)
    {
        rb.velocity = new Vector2(_xVelocity, _yVelocity);

       // FlipController(_xVelocity);
    }

    public virtual void Flip()
    {
        facingDirection *= -1;
        facingRight = !facingRight;

        transform.Rotate(0, 180, 0);

       
    }

    public virtual void FlipController(float direction)
    {
        if (direction > 0 && !facingRight)
            Flip();
        else if (direction < 0 && facingRight)
            Flip();
    }
}
