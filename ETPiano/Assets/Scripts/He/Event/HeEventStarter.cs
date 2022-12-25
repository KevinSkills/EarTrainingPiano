using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeEventStarter : MonoBehaviour
{
    bool running = false;

    public bool isRunning()
    {
        return running;
    }



    public IEnumerator startEventLine(HeEvent first)
    {
        running = true;
        HeEvent temp = first;
        yield return StartCoroutine(temp.eventLine());
        running = false;

    
    }
    
}
