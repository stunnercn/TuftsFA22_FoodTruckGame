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
        body.velocity = new Vector2(horizontal * moveSpeed, vertical * moveSpeed);
    }
}
