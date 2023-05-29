using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;

    Vector2 userInput;
    Animator animator;
    Rigidbody2D rigidBody;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        FlipSprite();
    }

    void Move()
    {
        Vector2 playerVelocity = new Vector2(userInput.x * moveSpeed, rigidBody.velocity.y);
        rigidBody.velocity = playerVelocity;

        animator.SetBool("isRunning", PlayerHasHorizontalSpeed());
    }

    void FlipSprite()
    {
        if (PlayerHasHorizontalSpeed())
        {
            transform.localScale = new Vector2(Mathf.Sign(rigidBody.velocity.x), 1f);
        }
    }

    private bool PlayerHasHorizontalSpeed()
    {
        return Mathf.Abs(rigidBody.velocity.x) > Mathf.Epsilon;
    }

    void OnMove(InputValue value)
    {
        userInput = value.Get<Vector2>();
    }


}
