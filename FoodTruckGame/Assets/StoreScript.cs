using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other) {
        Debug.Log("Player is close to a store");
        if (Input.GetKeyDown(KeyCode.Space) && other.gameObject.tag == "Player") {
            Debug.Log("Player interacted with store");
        }
    }
}
