using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrapTrigger : MonoBehaviour
{
    public PolygonCollider2D confinerCollider; // assign your confiner GameObject's PolygonCollider2D

    private void Update()
    {
        WrapPlayer();
    }

    private void WrapPlayer()
    {
        if (confinerCollider == null) return;

        Vector3 pos = transform.position;
        Bounds bounds = confinerCollider.bounds;

        // Horizontal wrap
        if (pos.x < bounds.min.x) pos.x = bounds.max.x;
        else if (pos.x > bounds.max.x) pos.x = bounds.min.x;

        // Vertical wrap (optional)
        if (pos.y < bounds.min.y) pos.y = bounds.max.y;
        else if (pos.y > bounds.max.y) pos.y = bounds.min.y;

        transform.position = pos;
    }
}
