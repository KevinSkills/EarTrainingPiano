using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChordManager : MonoBehaviour
{
    public Chord[] chords;

    public Chord findChord(string name)
    {
        foreach (Chord c in chords)
        {
            if (c.name.Equals(name)) return c;
        }

        return null;
    }

}

[System.Serializable]
public class Chord
{
    public string name;

    public int[] noteNumbers;




}
