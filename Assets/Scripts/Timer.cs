﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{

    public float time = 60f;
    public Text timeText;
    public Text finalText;
    public Button finalButton;
    public GameObject scorer;
    bool runningTime = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(runningTime)
            {
            time -= Time.deltaTime;
            time = time < 0f ? 0f : time; 
            int intTime = (int)time;
            string stringTime = intTime.ToString();              
            timeText.text = stringTime;

            if(time <= 0f){
                ShowFinalText();
                Time.timeScale = 0;

                //restart game with space button
                if(Input.GetKey(KeyCode.Space)){
                    RestartGame();
                }                
            }
        }

    }

    public void RunTime(){
        runningTime = true;
    }

    public void StopTime(){
        runningTime = false;
    }

    public void ShowFinalText(){
        finalText.gameObject.SetActive(true);
        finalButton.gameObject.SetActive(true);
        int score = scorer.GetComponent<Scorer>().GetScore();
        string scoreText = score.ToString();
        finalText.text = "Good boy! You got " + scoreText + " balls!";
    }

    public void RestartGame(){
        Time.timeScale = 1;
        SceneManager.LoadScene("MenuScene");
    }
}
