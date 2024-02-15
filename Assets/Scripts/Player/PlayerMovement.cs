using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Moves and animated Player
public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer sprite;
    public Vector2 movement;
    public float timer;
    public Vector3 currentPosition;
    public float moveSpeed = 5f;
    public bool isCaught = false;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        if (!isCaught)
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
            currentPosition.Set(rb.position.x, rb.position.y, 1);
        }
        else
        {
            //PLAYER CAUGHT, WHAT DO
        }
    }
}
