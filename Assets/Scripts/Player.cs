using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    [SerializeField] float moveSpeed = 5f;

    Vector2 userInput;

    void Start()
    {
        
    }
    void Update()
    {
        Move();
    }

    void Move() 
    {
        Vector3 delta = userInput * moveSpeed * Time.deltaTime;

        Vector2 newPosition = new Vector2();
        newPosition.x = transform.position.x + delta.x;
        newPosition.y = transform.position.y;

        transform.position = newPosition;
    }
    
    void OnMove(InputValue value) 
    {
        userInput = value.Get<Vector2>();
        Debug.Log(userInput);
    }
}
