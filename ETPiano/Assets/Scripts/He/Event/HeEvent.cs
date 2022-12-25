using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HeEvent : HeObject
{

    public HeItemSlot next;

    public IEnumerator eventLine()
    {

        yield return StartCoroutine(runEvent());

        if(next.getHeEvent() != null)
        yield return StartCoroutine(next.getHeEvent().eventLine());
    }

    public abstract IEnumerator runEvent();

    


}
