using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public float time = 60f;
    public Text timeText;
    bool runningTime = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime; 
        int intTime = (int)time;
        string stringTime = intTime.ToString();              
        timeText.text = stringTime;
    }

    public void runTime(){
        runningTime = true;
    }

    public void stopTime(){
        runningTime = false;
    }
}
