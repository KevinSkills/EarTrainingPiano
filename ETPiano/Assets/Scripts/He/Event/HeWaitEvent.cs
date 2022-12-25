using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeWaitEvent : HeEvent
{

    public float delay;
    public override IEnumerator runEvent()
    {
        yield return new WaitForSeconds(delay);
    }
}
