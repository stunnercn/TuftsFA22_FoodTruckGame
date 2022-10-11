using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerScript : MonoBehaviour
{

    GameHandler gameHandlerObj;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindWithTag("GameHandler") != null){
               gameHandlerObj = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // OnTriggerStay2D(gameObject.GetComponent<Collider2D>());
    }

    void OnTriggerStay2D(Collider2D other) {
        if (Input.GetKeyUp(KeyCode.Space) && other.gameObject.tag == "Player") {
            Debug.Log("Player interacted with customer");
            gameHandlerObj.AddToField(GameHandler.Field.Money, 2);
            gameHandlerObj.AddToField(GameHandler.Field.Meat, -1);
            gameHandlerObj.AddToField(GameHandler.Field.Beans, -1);
            gameHandlerObj.AddToField(GameHandler.Field.Tortillas, -1);
            Destroy(this.gameObject);
        }
    }
}
