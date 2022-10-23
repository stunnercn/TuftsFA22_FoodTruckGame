using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TortillaStoreScript : MonoBehaviour
{
    
    public GameHandler gameHandlerObj;

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
        
    }

    void OnTriggerStay2D(Collider2D other) {
        if (Input.GetKeyDown(KeyCode.Space) && other.gameObject.tag == "Player") {
            if (gameHandlerObj.GetNum(GameHandler.Field.Money) > 0) {
                gameHandlerObj.AddToField(GameHandler.Field.Tortillas, 1);
                gameHandlerObj.AddToField(GameHandler.Field.Money, -1);
                Debug.Log("Player interacted with store, giving tortilla");
            } else {
                gameHandlerObj.ShowInsufficientMessage("Not enough money to buy tortilla");
            }
        }
    }
}
