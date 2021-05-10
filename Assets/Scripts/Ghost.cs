using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    float ghostPos;
    public Transform player;
    public float moveSpeed;
    private Rigidbody2D rb;
    private Vector2 movement;
    private bool canMove;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();       
    }

    void Update()
    {
        Turn();
        ghostMovement();
        Debug.Log(movement);
    }

    void ghostMovement()
    {
        Vector2 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
    }

    private void FixedUpdate()
    {
        moveCharacter(movement);
    }

    void Turn()
    {
        if (movement.x > 0)
        {
            transform.localScale = new Vector2(3.5f, 3.5f);
        }
        else if (movement.x < 0)
        {
            transform.localScale = new Vector2(3.5f, -3.5f);
        }
    }

    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}
