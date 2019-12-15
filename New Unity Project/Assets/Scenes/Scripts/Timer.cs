using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timeText;
    public float timer = 10.00f; //Countdown Timer
    public GameObject retryMenu; // Set in inspector
    public bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        retryMenu.SetActive(false);
        timeText.text = "" + timer.ToString ("00:00");
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            timer -= Time.deltaTime;
        }
        timeText.text = "" + timer.ToString ("00:00");
        if (timer <= 0)
        {
            gameOver = true;
            if(!retryMenu.activeSelf) retryMenu.SetActive(true); // Activate Retry UI
        }
    }
}
