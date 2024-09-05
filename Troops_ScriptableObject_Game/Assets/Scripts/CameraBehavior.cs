using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraBehavior : MonoBehaviour
{
    private float moveDirection;
    [SerializeField] private int velocity;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        moveDirection = GameManager.Instance.InputManager.HorizontalMove;
        Vector2 directionToMove = new Vector2(moveDirection * velocity, rb.velocity.y);
        rb.velocity = directionToMove;
    }
}
