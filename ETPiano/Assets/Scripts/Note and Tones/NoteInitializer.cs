using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class NoteInitializer : MonoBehaviour
{
    


    public static NoteInitializer singleton;

    const float semitone = 1.05946309436f;

    List<string> availableNames = new List<string>() {"C", "D#", "F#", "A"};



   


    [Range(0,1)]
    public float volume = 1;


    private void Awake()
    {
        //singleton
        if (singleton == null)
        {
            singleton = this;
        }
        else {
            Debug.LogWarning("Multiple SoundManagers in game");
            Destroy(this);
            return;
        }

        InitializeNotes();
    }

    void InitializeNotes() { 

        //load clips from folder:

        string path = "samples/";

        for(int i = 0; i< 88; i++)
        {
            //vars
            string note;
            string noteName;
            int semiTonesUp = -1;


            //check if it is available or go down a semitone and check and so on. (SemiTonesUp is the amount of pitcing required later)
            do
            {
                semiTonesUp++;
                note = Note.numToName(i - semiTonesUp); 
                noteName = note.Remove(note.Length - 1, 1);
            }
            while (!availableNames.Contains(noteName));

            
            
            
            //got the note, now time to load

            string filePath = path + note + "vL"; //specific for this 

            AudioClip c = Resources.Load<AudioClip>(filePath);


            //add the note to list after some configuration

            Note n = new Note();
            n.clip = c;
            n.semiTonesUp = semiTonesUp;
            n.name = Note.numToName(i);

            Note.notes[i] = n;

        }


        //make audio sources and hide them

        for (int i = 0; i < Note.notes.Length; i++){
            Note n = Note.notes[i];
            n.source = gameObject.AddComponent<AudioSource>();
            n.source.hideFlags = HideFlags.HideInInspector;
            n.source.clip = n.clip;
            n.source.volume = volume;
            n.number = Note.nameToNum(n.name);


            n.source.pitch *= Mathf.Pow(semitone, n.semiTonesUp);

        }
    }
}

