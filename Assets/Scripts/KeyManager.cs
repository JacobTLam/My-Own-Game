using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyManager : MonoBehaviour
{
    public int keyAmount;
    public Text keyText;
    public bool GTG;

    void Start()
    {
        keyAmount = 0;
        GTG = false;
    }

    void Update()
    {
        keyText.text = keyAmount + "/3";
        
        if(keyAmount == 3)
        {
            GTG = true;
        }
    }

    public void AddKey()
    {
        keyAmount++;
    }

    public void SubtractKey()
    {
        keyAmount--;
    }

    

    
}
