using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 rawInput;

    [SerializeField] float playerSpeed = 1f;
    [SerializeField] float paddingLeft;
    [SerializeField] float paddingRight;
    [SerializeField] float paddingTop;
    [SerializeField] float paddingBottom;


    Vector2 minBounds;
    Vector2 maxBounds;

    //Rigidbody2D myRigdbody;
    
    

    bool isAlive = true;

    void Start()
    {
        //myRigdbody = GetComponent<Rigidbody2D>();
        InitBounds();
    }

    void Update()
    {
        Move();
    }

    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }

    void Move()
    {
        Vector2 delta = rawInput * playerSpeed * Time.deltaTime;
        Vector2 newPos = new Vector2();
        newPos.x = Math.Clamp(transform.position.x + delta.x, minBounds.x + paddingLeft, maxBounds.x - paddingRight);
        newPos.y = Math.Clamp(transform.position.y + delta.y, minBounds.y + paddingBottom, maxBounds.y - paddingTop);
        transform.position =newPos;

        //bool playerHasHorizontalSpeed = MathF.Abs(myRigdbody.velocity.x) > Mathf.Epsilon;
        //myAnimator.SetBool("IsRunning", playerHasHorizontalSpeed);

    }

    void OnMove(InputValue value)
    {
        if (!isAlive) { return; }
        rawInput = value.Get<Vector2>();
    }
}
