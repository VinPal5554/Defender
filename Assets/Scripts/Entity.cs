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

    [Header("Death Effect")]
    public GameObject deathEffectPrefab;

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

    public virtual void Die()
    {
        // 1. Hide the sprite & disable the collider
        if (sr != null) sr.enabled = false;
        if (bc != null) bc.enabled = false;

        // 2. Stop movement
        if (rb != null) rb.velocity = Vector2.zero;

        // 3. Play particle effect
        if (deathEffectPrefab != null)
        {
            GameObject effect = Instantiate(deathEffectPrefab, transform.position, Quaternion.identity);
            ParticleSystem ps = effect.GetComponent<ParticleSystem>();
            if (ps != null)
            {
                Destroy(effect, ps.main.duration + ps.main.startLifetime.constantMax);
            }
            else
            {
                Destroy(effect, 2f); // fallback destroy time
            }
        }

        // 4. Destroy the entity
        Destroy(gameObject);
    }
}
