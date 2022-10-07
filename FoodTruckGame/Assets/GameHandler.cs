using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{



    public GameObject meatText;
    public GameObject beansText;
    public GameObject veggiesText;
    public GameObject tortillasText;

    public GameObject moneyText;

    private int[] numVals = new int[5]; // 0 is the default value

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
        
    }

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
    
}
