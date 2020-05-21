using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

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
    
    int incorrect = 0;
    int correct = 0;

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
        //
        // Set up the Editor before calling into the realtime database.
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://tentalesarquiz.firebaseio.com/");

        // Get the root reference location of the database.
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
        
        long quiztime = 15;
        //
        reference.Child("users").Child("timeelapsed").SetValueAsync(quiztime);
    }
    
    void ClearDisplay(){
        correctDisplay.SetActive(false);
        wrongDisplay.SetActive(false);
        fireworks.SetActive(false);
    }
    
    void OnTriggerEnter(Collider coll){
        ClearDisplay();
        //
        if (coll.gameObject.name == "ApplePrefab"){
            if (timerActive){
                timer = 0;
                fireworks.SetActive(true);
                correctDisplay.SetActive(true);
                if (timerActive){
                    timerActive = false;
                    correct = 1;
                    StopTheClock();
                }
            }
        }
        if (coll.gameObject.name == "EyesPrefab"){
            if (timerActive){
                timer = 0;
                wrongDisplay.SetActive(true);
                incorrect++;
                DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
                reference.Child("users").Child("incorrect").SetValueAsync(incorrect);
            }
        }
        if (coll.gameObject.name == "RiverPrefab"){
            if (timerActive){
                timer = 0;
                wrongDisplay.SetActive(true);
                incorrect++;
                DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
                reference.Child("users").Child("incorrect").SetValueAsync(incorrect);
            }
        }
        if (coll.gameObject.name == "SledPrefab"){
            if (timerActive){
                timer = 0;
                wrongDisplay.SetActive(true);
                incorrect++;
                DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
                reference.Child("users").Child("incorrect").SetValueAsync(incorrect);
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
        //
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
        
        long quiztime = 60 - Mathf.FloorToInt(timeRemaining);
        string resultstring = correct + " of " + (incorrect+correct);
        //
        reference.Child("users").Child("correct").SetValueAsync(correct);
        reference.Child("users").Child("incorrect").SetValueAsync(incorrect);
        reference.Child("users").Child("result").SetValueAsync(resultstring);
        reference.Child("users").Child("timeelapsed").SetValueAsync(quiztime);
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
