using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note
{

    //static
    public static Note[] notes = new Note[88];
    static List<string> noteNames = new List<string>() { "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B" };

    public static Note findNote(int number)
    {
        foreach (Note n in notes)
        {
            if (n.number == number) return n;
        }

        return null;

    }
    public static Note findNote(string name)
    {
        foreach (Note n in notes)
        {
            if (n.name.Equals(name)) return n;
        }

        return null;

    }
    public static int nameToNum(string noteName)
    {
        int octave;
        string forParse = "" + noteName[noteName.Length - 1];
        if (!int.TryParse(forParse, out octave))
        {
            Debug.LogError("Parse failed : returning -1");
            return -1;
        }

        noteName = noteName.Remove(noteName.Length - 1, 1);

        return -9 + octave * 12 + noteNames.IndexOf(noteName);
    }
    public static string numToName(int number)
    {
        number += 9;
        int octaves = ((int)(number / 12));

        number -= octaves * 12;

        return "" + noteNames[number] + octaves;
    }
    public static void stopAll()
    {
        foreach (Note n in notes)
        {
            n.Stop();
        }
    }


    //not static

    public AudioClip clip;

    public int semiTonesUp;


    [HideInInspector]
    public AudioSource source;

    public string name;

    [HideInInspector]
    public int number;

    public void Stop()
    {
        source.Stop();
    }
    public void Play()
    {
        source.Play();
    }




}





