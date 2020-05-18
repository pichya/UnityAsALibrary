using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckAnswer : MonoBehaviour
{
    public GameObject correctDisplay;
    public GameObject wrongDisplay;
    public GameObject fireworks;
    
    public TextMeshPro counterTextPro;
    
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject text4;
    
    int timer;
    public float timeRemaining = 60;
    bool timerActive = true;

    // Start is called before the first frame update
    void Start()
    {
        fireworks.SetActive(false);
        text1.SetActive(false);
        text2.SetActive(false);
        text3.SetActive(false);
        text4.SetActive(false);
        ClearDisplay();
        counterTextPro.text = "Timer: 60";
    }
    
    void ClearDisplay(){
        correctDisplay.SetActive(false);
        wrongDisplay.SetActive(false);
        fireworks.SetActive(false);
    }
    
    void OnTriggerEnter(Collider coll){
        ClearDisplay();
        
        if (coll.gameObject.name == "ApplePrefab"){
            if (timerActive){
                timer = 0;
                fireworks.SetActive(true);
                correctDisplay.SetActive(true);
                if (timerActive){
                    timerActive = false;
                    StopTheClock();
                }
            }
        }
        if (coll.gameObject.name == "EyesPrefab"){
            if (timerActive){
                timer = 0;
                wrongDisplay.SetActive(true);
            }
        }
        if (coll.gameObject.name == "RiverPrefab"){
            if (timerActive){
                timer = 0;
                wrongDisplay.SetActive(true);
            }
        }
        if (coll.gameObject.name == "SledPrefab"){
            if (timerActive){
                timer = 0;
                wrongDisplay.SetActive(true);
            }
        }
    }
    
    void StopTheClock(){
        timerActive = false;
        counterTextPro.text = "Timer: " + Mathf.FloorToInt(timeRemaining);
        text1.SetActive(true);
        text2.SetActive(true);
        text3.SetActive(true);
        text4.SetActive(true);
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        if (timer<60){
            timer++;
            if (timer>58){
                ClearDisplay();
            }
        }
        //
        if (timerActive){
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                counterTextPro.text = "Timer: " + Mathf.FloorToInt(timeRemaining);
                
            }else{
                timeRemaining = 0;
                StopTheClock();
            }
        }
    }
}
