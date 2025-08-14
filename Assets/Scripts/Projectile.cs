using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 20.0f;
    public float lifetime = 1.0f;

    private Rigidbody2D rb;


    public void SetDirection(Vector2 dir)
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = dir.normalized * speed;

    }

    void Update()
    {

    }

}
