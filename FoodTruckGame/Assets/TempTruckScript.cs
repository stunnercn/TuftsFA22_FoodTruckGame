using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempTruckScript : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;
    float vertical;

    public float moveSpeed = 5.0f;

    void Start() {
        body = GetComponent<Rigidbody2D>(); 
    }

    void Update() {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical"); 
    }

    private void FixedUpdate() {  
        Vector2 moveDirection = new Vector2(horizontal * moveSpeed, vertical * moveSpeed);
        body.velocity = moveDirection;
        if (moveDirection.x != 0 || moveDirection.y != 0) {
            Quaternion rotation = Quaternion.LookRotation(Vector3.forward, moveDirection);
            transform.rotation = rotation * Quaternion.Euler(0f, 0f, 90f);
        }
    }
}
