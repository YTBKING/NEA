using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;

    public bool isFacingRight = true;
    public float enSpeed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isFacingRight)
        {
            rb.velocity = new Vector2(1 * enSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(-1 * enSpeed, rb.velocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag != "Ground")
        {
            isFacingRight = !isFacingRight;
        }
    }
}
