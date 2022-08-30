using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    
    Vector2 rawInput;
    [SerializeField] float moveSpeedConstant = 0.5f;
    [SerializeField] float paddingRight;
    [SerializeField] float paddingLeft;
    [SerializeField] float paddingTop;
    [SerializeField] float paddingBottom;
    Shooter shooter;

    Vector2 minBounds;
    Vector2 maxBounds;

    void Awake() 
    {
        shooter = GetComponent<Shooter>();    
    }
    void Start() 
    {
        InitBounds();    
    }

    void Update()
    {
        Move();
    }

    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2 (0,0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2 (1,1));
    }

    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();

    }

    void OnFire(InputValue value)
    {
        
        shooter.isFiring = value.isPressed;
    }

    void Move()
    {
        Vector2 delta = rawInput * moveSpeedConstant * Time.deltaTime;
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + delta.x , minBounds.x + paddingLeft , maxBounds.x - paddingRight);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y , minBounds.y + paddingBottom , maxBounds.y - paddingTop);
        transform.position = newPos;
    }

}