using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeIfEvent : HeEvent
{
    public HeItemSlot booler;

    public HeEventStarter eventStarter;

    private void Awake()
    {
        eventStarter = gameObject.AddComponent<HeEventStarter>();
    }

    public HeItemSlot ifTrue;

    public HeItemSlot ifFalse;

    public override IEnumerator runEvent()
    {
        if (booler.getHeBooler().getValue()) yield return StartCoroutine(eventStarter.startEventLine(ifTrue.getHeEvent()));
        else yield return StartCoroutine(eventStarter.startEventLine(ifFalse.getHeEvent()));
    }
}
