using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntervalGame : MonoBehaviour
{
    int correct;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playRandomInterval()
    {
        StartCoroutine(IE_playRandomInterval());
    }

    public void Guess(int guess)
    {
        

        if (guess == correct) print("yes");
        else print("no");
    }

    IEnumerator IE_playRandomInterval()
    {
        Note.findNote("C4").Play();
        yield return null;
    }


}



