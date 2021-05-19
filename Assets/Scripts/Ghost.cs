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
    public GameManager theGM;

    private bool controlActive;
    private bool isKilled;
    private Animator theAnimator;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        theAnimator = GetComponent<Animator>();

        controlActive = true;
    }

    void Update()
    {
        if(controlActive == true)
        {
            Turn();
            ghostMovement();
        }
        
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
        if (controlActive == true)
        {
            moveCharacter(movement);
        }
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("LOl");
            Killed();
        }
    }

    void Killed()
    {
        isKilled = true;
        theAnimator.SetBool("Dead", isKilled);

        controlActive = false;


        StartCoroutine("PlayerRespawn");
    }

    IEnumerator PlayerRespawn()
    {
        yield return new WaitForSeconds(1.5f);
        isKilled = false;
        theAnimator.SetBool("Dead", isKilled);


        yield return new WaitForSeconds(0.1f);
        controlActive = true;
        //theGM.Reset();
    }

}
