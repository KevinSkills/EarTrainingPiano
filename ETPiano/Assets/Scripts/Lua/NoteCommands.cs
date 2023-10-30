using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoonSharp.Interpreter;
using System;
public class NoteCommands : MonoBehaviour
{
    NoteManager nm;

    public int voiceAround = 40;

    public NoteCommands(NoteManager nm)
    {
        this.nm = nm;
    }

    public void playNote(DynValue r)
    {
        nm.PlayNote(getNoteNumFromDyn(r));
    }


    public int getNoteNumFromDyn (DynValue r)
    {

        if (r.Type == DataType.Number) return (int)r.CastToNumber();
        else return nm.NameToNum(r.CastToString());
    }

    public DynValue toNoteNumber(DynValue r)
    {
        if (r.Type == DataType.Number) return r;
        else return DynValue.NewNumber(nm.NameToNum(r.CastToString()));
    }

    public DynValue toNoteName(DynValue r)
    {
        if (r.Type == DataType.Number) return DynValue.NewString(nm.NumToName((int)r.CastToNumber()));
        else return r;
    }

    public void defineChord(string s, DynValue noteNumbers)
    {
        

        Table table = noteNumbers.Table;
        nm.findChord(s);

        Chord c = nm.findChord(s);
        if (c == null)
        {
            c = new Chord();
            c.name = s;
        }

        
        for (int i = 1; i <= table.Length; i++)
        {
            c.noteNumbers.Add((int)table.Get(i).CastToNumber());
        }

        nm.chords.Add(c);
    }


    public void playChord(DynValue note, string chordName)
    {

        nm.PlayChord(getNoteNumFromDyn(note), chordName);
    }

    public void playVoicedChord(DynValue note, string chordName)
    {

        nm.PlayChord(getNoteNumFromDyn(note), chordName, voiceAround);
    }

}
