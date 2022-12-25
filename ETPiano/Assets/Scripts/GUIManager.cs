using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIManager : MonoBehaviour
{
    public HeEvent first;

    public void startFirstEventline()
    {
        HeEventStarter he = gameObject.AddComponent<HeEventStarter>();
        print(he);
        StartCoroutine(he.startEventLine(first));

    }
}
