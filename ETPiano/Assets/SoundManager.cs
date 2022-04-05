using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public string toPlay = "A4";

    List<string> noteNames = new List<string>() {  "C", "Db", "D", "Eb", "E", "F", "Gb", "G", "Ab", "A", "Bb", "B"};

    public Chord[] chords;

    public Note[] notes;


    [Range(0,1)]
    public float volume = 1;


    private void Awake()
    {
        Debug.Log(nameToNum("C1"));

        for (int i = 0; i < notes.Length; i++){
            Note n = notes[i];
            n.source = gameObject.AddComponent<AudioSource>();
            n.source.clip = n.clip;
            n.source.volume = volume;
            n.number = nameToNum(n.name);

            print("semitones up: " + n.semiTonesUp + " and pitch: " + n.source.pitch);

            float semitone = 1.05946309436f;
            print("a semitone is : " + semitone);

            n.source.pitch *= Mathf.Pow(semitone, n.semiTonesUp);
            print("semitones up: " + n.semiTonesUp + " and pitch: " + n.source.pitch);


            /*n.name = convertNumberToName(i);

            for(int ii = 0; ii <= 7; ii++)
            {
                if (n.name.Contains("A" + ii)) n.semiTonesUp = 0;
                if (n.name.Contains("Bb" + ii)) n.semiTonesUp = 1;
                if (n.name.Contains("B" + ii)) n.semiTonesUp = -1;
                if (n.name.Contains("C" + ii)) n.semiTonesUp = 0;
                if (n.name.Contains("Db" + ii)) n.semiTonesUp = 1;
                if (n.name.Contains("D" + ii)) n.semiTonesUp = 2;
                if (n.name.Contains("Eb" + ii)) n.semiTonesUp = 0;
                if (n.name.Contains("E" + ii)) n.semiTonesUp = 1;
                if (n.name.Contains("F" + ii)) n.semiTonesUp = -1;
                if (n.name.Contains("Gb" + ii)) n.semiTonesUp = 0;
                if (n.name.Contains("G" + ii)) n.semiTonesUp = 1;
                if (n.name.Contains("Ab" + ii)) n.semiTonesUp = -1;
            }
            */


        }
    }




    public Note findNote(int number)
    {
        foreach (Note n in notes)
        {
            if (n.number == number) return n;
        }

        return null;

    }
    public Note findNote(string name)
    {
        foreach (Note n in notes)
        {
            if (n.name.Equals(name)) return n;
        }

        return null;

    }


    public int nameToNum(string noteName)
    {
        int octave;
        string forParse = "" + noteName[noteName.Length - 1];
        print(forParse);
        if (!int.TryParse(forParse, out octave)){
            Debug.LogError("Parse failed : returning -1");
            return -1;
        }

        noteName = noteName.Remove(noteName.Length - 1, 1);

        return -9 + octave*12 + noteNames.IndexOf(noteName);
    }

    public string convertNumberToName(int number)
    {
        number += 9;
        int octaves = ((int)(number / 12));

        number -=  octaves * 12;

        return "" + noteNames[number] + octaves;
    }


    public void playChord(Chord c, string startingNote)
    {
        int n = nameToNum(startingNote);

        foreach (int note in c.noteNumbers){
            findNote(note + n).Play();
        }


    }

    Chord findChord(string name)
    {
        foreach (Chord c in chords)
        {
            if (c.name.Equals(name)) return c;
        }

        return null;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){

            playChord(findChord(toPlay), "C4");
        }
        
    }
}


[System.Serializable]
public class Note
{


    public AudioClip clip;

    public int semiTonesUp;


    [HideInInspector]
    public AudioSource source;

    public string name;

    [HideInInspector]
    public int number;




    public void Play()
    {
        source.Play();
    }

   





}



[System.Serializable]
public class Chord{

    public string name;

    public int[] noteNumbers;




}
