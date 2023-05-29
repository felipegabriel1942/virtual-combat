using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float paddingLeft;
    [SerializeField] float paddingRight;

    Vector2 userInput;
    Animator animator;
    Rigidbody2D rigidBody;
    Vector2 minBounds;
    Vector2 maxBounds;
    Vector3 playerDelta;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();

        InitBounds();
    }

    void Update()
    {
        Move();
        FlipSprite();
    }

    private void InitBounds() 
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }

    void Move()
    {
        playerDelta = userInput * moveSpeed * Time.deltaTime;

        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + playerDelta.x, minBounds.x + paddingLeft, maxBounds.x - paddingRight);
        newPos.y = Mathf.Clamp(transform.position.y, minBounds.y, maxBounds.y);

        transform.position = newPos;

        animator.SetBool("isRunning", PlayerHasHorizontalSpeed());
    }

    void FlipSprite()
    {
        if (PlayerHasHorizontalSpeed())
        {
            transform.localScale = new Vector2(Mathf.Sign(playerDelta.x), 1f);
        }
    }

    private bool PlayerHasHorizontalSpeed()
    {
        return Mathf.Abs(playerDelta.x) > Mathf.Epsilon;
    }

    void OnMove(InputValue value)
    {
        userInput = value.Get<Vector2>();
    }


}
