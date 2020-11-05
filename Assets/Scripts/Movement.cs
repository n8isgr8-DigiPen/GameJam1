using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 movement = new Vector2(Input.GetAxis("Horizontal") * 8f * Time.deltaTime, Input.GetAxis("Vertical") * 8f * Time.deltaTime);
        rb.velocity = rb.velocity + movement;
        if(rb.velocity.x > 8)
        {
            rb.velocity = new Vector2(2,rb.velocity.y);
        }
        if (rb.velocity.x < -8)
        {
            rb.velocity = new Vector2(-2, rb.velocity.y);
        }
        if (rb.velocity.y > 5)
        {
            rb.velocity = new Vector2(rb.velocity.x, 1);
        }
        if (rb.velocity.y < -5)
        {
            rb.velocity = new Vector2(rb.velocity.x, -1);
        }
    }
}
