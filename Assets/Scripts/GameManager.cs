using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerController thePlayer;
    private Vector2 playerStart;

    public Ghost theGhost;
    private Vector2 ghostStart;

    public GameObject victoryScreen;
    public GameObject gameOverScreen;

    void Start()
    {
        playerStart = thePlayer.transform.position;
        ghostStart = theGhost.transform.position;
    }

    public void Victory()
    {
        victoryScreen.SetActive(true);
        thePlayer.gameObject.SetActive(false);
        theGhost.gameObject.SetActive(false);
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        thePlayer.gameObject.SetActive(false);
        theGhost.gameObject.SetActive(false);
    }
    
    public void Reset()
    {
        victoryScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        thePlayer.gameObject.SetActive(true);
        theGhost.gameObject.SetActive(true);
        thePlayer.transform.position = playerStart;
        theGhost.transform.position = ghostStart;
    }
}
