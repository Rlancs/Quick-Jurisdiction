using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Timer : MonoBehaviour
{
    [SerializeField] private Controller controllerScript;
    [SerializeField] private float timeValue = 30;
    [SerializeField] private TMPro.TextMeshProUGUI TimerText;
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private GameObject gameplayUI;

    void Update()
    {
        // Whilst time is above 0, constantly decreases the timer
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        // If the timer reaches 0, the game is ended with a failure
        else
        {
            timeValue = 0;
            gameOverMenu.SetActive(true);
            controllerScript.gameEnd = true;
            Time.timeScale = 0;
            gameplayUI.SetActive(false);
        }
        var timeDisplay = Mathf.CeilToInt(timeValue);
        TimerText.text = timeDisplay.ToString();
    }

    public void ResetTime()
    {
        timeValue = 30;
    }
}
