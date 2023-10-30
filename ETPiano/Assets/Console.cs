using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Console : MonoBehaviour
{
    public Text text;
    public static Console main;

    // Start is called before the first frame update
    void Awake()
    {
        main = this;
        
    }

    
    public void AddText(string s)
    {
        text.text = text.text + "\n" + s;
    }

    public void SetText(string s)
    {
        text.text = s;
    }
}
