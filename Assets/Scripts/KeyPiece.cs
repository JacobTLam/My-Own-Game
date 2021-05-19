using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPiece : MonoBehaviour
{
    private KeyManager theKM;

    void Start()
    {
        theKM = FindObjectOfType<KeyManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            theKM.AddKey();
            Destroy(gameObject);
        }
    }
}
