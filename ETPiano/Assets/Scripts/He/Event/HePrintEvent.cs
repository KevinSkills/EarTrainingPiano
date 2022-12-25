using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HePrintEvent : HeEvent
{
    public string toPrint;
    public override IEnumerator runEvent()
    {
        print(toPrint);
        yield return null;
    }
}
