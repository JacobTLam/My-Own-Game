using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesManager : MonoBehaviour
{
    //public int defaultLives;
    public int livesCounter;

    public Text livesText;

    private GameManager theGM;

    void Start()
    {
        livesCounter = PlayerPrefs.GetInt("CurrentLives");
        //livesCounter = defaultLives;

        theGM = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        livesText.text = "x " + livesCounter;

        if(livesCounter < 1)
        {
            theGM.GameOver();
        }
    }

    public void TakeLife()
    {
        livesCounter--;
        PlayerPrefs.SetInt("CurrentLives", livesCounter);
    }

    public void AddLife()
    {
        livesCounter++;
        PlayerPrefs.SetInt("CurrentLives", livesCounter);
    }
}
