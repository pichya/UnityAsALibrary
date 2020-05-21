using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

/// <summary>
/// Simple MonoBehaviour to set the Application's targetFrameRate
/// </summary>
public class SetTargetFramerate : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Sets the application's target frame rate.")]
    int m_TargetFrameRate = 60;

    /// <summary>
    /// Get or set the application's target frame rate.
    /// </summary>
    public int targetFrameRate
    {
        get { return m_TargetFrameRate; }
        set
        {
            m_TargetFrameRate = value;
            SetFrameRate();
        }
    }

    void SetFrameRate()
    {
        Application.targetFrameRate = targetFrameRate;
    }
    
    public DateTime starttime;
    void Start()
    {
        SetFrameRate();
        // Set up the Editor before calling into the realtime database
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://tentalesarquiz.firebaseio.com/");

        // Get the root reference location of the database.
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
        
        // Starttime
        DateTime starttime = DateTime.Now;
        
        long randomID = UnityEngine.Random.Range(1000, 50000);
        reference.Child("users").Child("id").SetValueAsync(randomID);
        //
        reference.Child("users").Child("correct").SetValueAsync(0);
        reference.Child("users").Child("incorrect").SetValueAsync(0);
        reference.Child("users").Child("result").SetValueAsync("0 of 0");
        reference.Child("users").Child("timeelapsed").SetValueAsync(0);
    }
    
    void OnApplicationQuit()
    {
        DateTime currentTime = DateTime.Now;
        TimeSpan difference = currentTime.Subtract(starttime);
        long sessiontime = difference.Seconds;
        //
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
        reference.Child("users").Child("sessiontime").SetValueAsync(sessiontime);
    }
    
}
