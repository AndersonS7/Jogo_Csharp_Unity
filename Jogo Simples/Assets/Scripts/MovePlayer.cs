using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private Rigidbody2D rb;
    private float movePlayer;
    public int speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movePlayer = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(movePlayer * speed, rb.velocity.y);
    }
}
