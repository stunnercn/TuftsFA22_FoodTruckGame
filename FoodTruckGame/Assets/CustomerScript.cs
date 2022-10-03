using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // OnTriggerStay2D(gameObject.GetComponent<Collider2D>());
    }

    void OnTriggerStay2D(Collider2D other) {
        Debug.Log("Player is close to a customer");
        if (Input.GetKeyUp(KeyCode.Space) && other.gameObject.tag == "Player") {
            Debug.Log("Player interacted with customer");
        }
    }
}
