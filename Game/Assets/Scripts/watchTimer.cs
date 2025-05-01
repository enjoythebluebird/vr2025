using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;

public class watchTimer : MonoBehaviour

{
    public TextMeshProUGUI roomOne_Timer;
    public float remainingTime = 120f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        // Check what level the player is in, so if true, timer starts.
        string levelName = SceneManager.GetActiveScene().name;
        if (levelName == "Level 1")
        {
            //Start timer.
            remainingTime -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(remainingTime / 60);
            int seconds = Mathf.FloorToInt(remainingTime / 60);
            roomOne_Timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}
