using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    // Pause Menu stuff:
    public static int playerStat;
    public static bool GameisPaused = false;
    public GameObject pauseMenuUI;

    // Everything else:
    public GameObject meatText;
    public GameObject beansText;
    public GameObject veggiesText;
    public GameObject tortillasText;

    public GameObject insufficientText;

    public GameObject moneyText;

    public GameObject GameOver;

    private int[] numVals = new int[5];

    void Awake (){

    }

    public enum Field {
        Money,
        Meat,
        Beans,
        Veggies,
        Tortillas
    }

    private GameObject[] textObjList = new GameObject[5];



    // Start is called before the first frame update
    void Start()
    {
        pauseMenuUI.SetActive(false);
        GameisPaused = false;
        insufficientText.SetActive(false);
        numVals[(int) Field.Money] = 0;
        numVals[(int) Field.Meat] = 5;
        numVals[(int) Field.Beans] = 5;
        numVals[(int) Field.Veggies] = 5;
        numVals[(int) Field.Tortillas] = 5;

        textObjList[(int) Field.Money] = moneyText;
        textObjList[(int) Field.Meat] = meatText;
        textObjList[(int) Field.Beans] = beansText;
        textObjList[(int) Field.Veggies] = veggiesText;
        textObjList[(int) Field.Tortillas] = tortillasText;
        UpdateAll();
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Escape)){
          if (GameisPaused){
              Resume();
          }
          else{
              Pause();
          }
      }
    }
// --- Pause Menu ---
    void Pause(){
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameisPaused = true;
    }

    public void Resume(){
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameisPaused = false;
    }

    public void RestartGame(){
        Time.timeScale = 1f;
        // Add commands to zero-out any scores or other stats before restarting
        pauseMenuUI.SetActive(false);
        GameisPaused = false;
        insufficientText.SetActive(false);
        numVals[(int) Field.Money] = 0;
        numVals[(int) Field.Meat] = 5;
        numVals[(int) Field.Beans] = 5;
        numVals[(int) Field.Veggies] = 5;
        numVals[(int) Field.Tortillas] = 5;

        textObjList[(int) Field.Money] = moneyText;
        textObjList[(int) Field.Meat] = meatText;
        textObjList[(int) Field.Beans] = beansText;
        textObjList[(int) Field.Veggies] = veggiesText;
        textObjList[(int) Field.Tortillas] = tortillasText;
        UpdateAll();
        SceneManager.LoadScene("Start");
    }

    public void QuitGame(){
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
// ---
    public void AddToField(Field field, int numToAdd) {
        numVals[(int) field] += numToAdd;
        UpdateField(field);
    }

    public void UpdateField(Field field) {
        System.String fillString = ": x";
        if (field == Field.Money) {
            fillString = ": $";
        }
        Text textB = textObjList[(int) field].GetComponent<Text>();
        textB.text = field.ToString() + fillString + numVals[(int) field];
    }

    private void UpdateAll() {
        foreach(Field field in System.Enum.GetValues(typeof(Field))) {
            UpdateField(field);
        }
    }

    public void GameOverScreen() {
        GameOver.SetActive(true);
    }

    public int GetNum(Field field) {
        return numVals[(int) field];
    }

    IEnumerator ShowInsufficientMessageRoutine(System.String message) {
        insufficientText.GetComponent<Text>().text = message;
        insufficientText.SetActive(true);
        yield return new WaitForSeconds(1f);
        insufficientText.SetActive(false);
    }

    public void ShowInsufficientMessage(System.String message) {
        StartCoroutine(ShowInsufficientMessageRoutine(message));
    }

}
