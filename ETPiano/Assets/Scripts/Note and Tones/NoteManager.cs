using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using F1yingBanana.SfizzUnity;

public class NoteManager : MonoBehaviour
{
    static List<string> noteNames = new List<string>() { "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B" };
    static List<string> noteNamesFlat = new List<string>() { "C", "Db", "D", "Eb", "E", "F", "Gb", "G", "Ab", "A", "Bb", "B" };
    static List<string> solfa = new List<string>() { "Do", "Ra", "Re", "Me", "Mi", "Fa", "Fi", "So", "Le", "La", "Te", "Ti" };

    public List<Chord> chords = new List<Chord>();

    [field: Range(0, 127)]
    [field: SerializeField]
    public int Velocity
    {
        get; set;
    } = 64;

    [field: SerializeField]
    public SfizzPlayer Player { get; set; }

    public string InitialSfzFile;

    private void Awake()
    {
        string path = Application.streamingAssetsPath + "/piano/" + InitialSfzFile;


        if (!Player.Sfizz.LoadFile(path))
        {
            Debug.LogError($"Sfz not found at the given path: {path}, player will remain silent.");
        }


    }

    public void Update()
    {
    }

    public void PlayNote(int n)
    {
        Player.Sfizz.SendNoteOn(0, n, Velocity);
    }
    public void PlayNote(string s)
    {
        PlayNote(NameToNum(s));
    }

    public Chord findChord(string name)
    {
        foreach (Chord c in chords)
        {
            if (c.name.Equals(name)) return c;
        }

        return null;
    }



    public void StopAll()
    {
        for (int i = 0; i <= 127; i++)
        {
            Player.Sfizz.SendNoteOff(0, i, Velocity);
        }
    }

    public void PlayChord(int rootNote, string chordType)
    {
        List<int> noteNumbers = findChord(chordType).noteNumbers;
        for (int i = 0; i < noteNumbers.Count; i++)
        {
            PlayNote(rootNote + noteNumbers[i]);

        }


    }
    public void PlayChord(int rootNote, string chordType, int around)
    {
        List<int> noteNumbers = findChord(chordType).noteNumbers;
        for (int i = 0; i < noteNumbers.Count; i++)
        {
            int note = rootNote + noteNumbers[i];
            note = VoiceNote(note, around, 1, 0);
            note = VoiceNote(note, around, -1, 0);
            PlayNote(note);

        }


    }

    int VoiceNote(int note, int around, int sign, int depth)
    {
        if (depth > 10) return note; 

        if (Mathf.Abs((note + 12 * sign) - around) < Mathf.Abs((note) - around)) return VoiceNote(note + 12 * sign, around, sign, depth+1);
        return note;

    }


    string ToSharp(string noteName)
    {
        for (int i = 0; i < noteNames.Count; i++)
        {
            noteName = noteName.Replace(noteNamesFlat[i], noteNames[i]);
        }
        return noteName;
    }

    public string NumToName(int number)
    {
        int octaves = ((int)(number / 12)); 

        number -= octaves * 12;

        return "" + noteNames[number] + (octaves-1);
    }

    public int NameToNum(string noteName)
    {
        noteName = ToSharp(noteName);
        int octave;
        string forParse = ToSharp("" + noteName[noteName.Length - 1]);
        if (!int.TryParse(forParse, out octave))
        {
            Debug.LogError("Parse failed : returning -1");
            return -1;
        }

        noteName = noteName.Remove(noteName.Length - 1, 1);


        return (octave+1) * 12 + noteNames.IndexOf(noteName);
    }

    public string NumToSolfa(int num)
    {
        num = num % 12; 
        num = (num < 0) ? num + 12 : num;
        return solfa[num];
    }

}

[System.Serializable]
public class Chord
{
    public string name;

    public List<int> noteNumbers = new List<int>();

}
