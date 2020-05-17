using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAnswer : MonoBehaviour
{
    public GameObject correctDisplay;
    public GameObject wrongDisplay;
    public GameObject fireworks;
    
    int timer;
    
    // Start is called before the first frame update
    void Start()
    {
        fireworks.SetActive(false);
        ClearDisplay();
    }
    
    void ClearDisplay(){
        correctDisplay.SetActive(false);
        wrongDisplay.SetActive(false);
        fireworks.SetActive(false);
    }
    
    void OnTriggerEnter(Collider coll){
        ClearDisplay();
        if (coll.gameObject.name == "ApplePrefab"){
            timer = 0;
            fireworks.SetActive(true);
            correctDisplay.SetActive(true);
        }
        if (coll.gameObject.name == "EyesPrefab"){
            timer = 0;
            wrongDisplay.SetActive(true);
        }
        if (coll.gameObject.name == "RiverPrefab"){
            timer = 0;
            wrongDisplay.SetActive(true);
        }
        if (coll.gameObject.name == "SledPrefab"){
            timer = 0;
            wrongDisplay.SetActive(true);
        }
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
    }
}
