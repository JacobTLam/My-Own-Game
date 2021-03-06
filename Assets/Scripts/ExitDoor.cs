using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    public GameManager theGM;
    private KeyManager theKM;
    private PlayerController theDude;

    void Start()
    {
        theKM = FindObjectOfType<KeyManager>();
        theDude = FindObjectOfType<PlayerController>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && theKM.GTG == true)
        {
            theGM.Victory();
        }
    }
}
