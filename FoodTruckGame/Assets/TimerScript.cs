using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public float timeLeft;
    public bool timerOn = false;

    public Text timerUI;

    // Start is called before the first frame update
    void Start()
    {
        timerOn = true;   
    }

    // Update is called once per frame
    void Update()
    {
        if (timerOn) {
            if (timeLeft > 0) {
                timeLeft -= Time.deltaTime;
                updateTimer(timeLeft);
            }
            else {
                timeLeft = 0;
                timerOn = false;
            }
        }
    }

    void updateTimer(float currentTime) {
        currentTime += 1;

        float seconds = Mathf.FloorToInt(currentTime % 60);
        float minutes = Mathf.FloorToInt(currentTime / 60);

         timerUI.GetComponent<UnityEngine.UI.Text>().text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}
