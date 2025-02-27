using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class Countdown : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;
   

    // Update is called once per frame
    void Update()
    {
        remainingTime -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:D2}:{1:D2}", minutes, seconds);

        if (remainingTime <= 0)
        {
            Debug.Log("Time has run out, you're fired!");
            Application.Quit();
        }
    }
}
