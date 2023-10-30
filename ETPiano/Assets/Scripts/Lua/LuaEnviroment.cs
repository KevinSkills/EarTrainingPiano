using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoonSharp.Interpreter;
using System;

public class LuaEnviroment : MonoBehaviour
{
    public string luaFileName;
    public string coroutineToRun;
    Script ev;
    DynValue c;

    public NoteManager nm;


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            runScript();
        }
    }

    // Start is called before the first frame update
    void runScript()
    {
        Script.DefaultOptions.DebugPrint = print;

        RythmCommands rythm = new RythmCommands(this);
        LuaCommands lc = new LuaCommands();
        NoteCommands nc = new NoteCommands(nm);

        ev = new Script();


        rythm.metronomeClick += (Action)(() => { nm.PlayNote(93); });



        //Rythm Commands
        ev.Globals["setBpm"] = (Action<int>)(i => { rythm.bpm = i; });
        ev.Globals["setMeasures"] = (Action<int>)(i => { rythm.measures = i; });
        ev.Globals["setBeatsInMeasure"] = (Action<int>)(i => { rythm.beatsInMeasure = i; });
        ev.Globals["setBeat"] = (Func<int, float, DynValue>)((i, f) => { return handleCoroutine(rythm.SetBeat(i, f)); });
        ev.Globals["endRound"] = (Func<DynValue>)(() => { return handleCoroutine(rythm.endRound()); });


        //notes
        ev.Globals["playNote"] = (Action<DynValue>)(r => { nc.playNote(r); });

        ev.Globals["toName"] = (Func<DynValue, DynValue>)nc.toNoteName;

        ev.Globals["toNum"] = (Func<DynValue, DynValue>)nc.toNoteNumber;

        ev.Globals["defineChord"] = (Action<string, DynValue>)nc.defineChord;

        ev.Globals["playChord"] = (Action<DynValue, string>)nc.playChord;

        ev.Globals["playChord_v"] = (Action<DynValue, string>)((d, s) => { nc.playVoicedChord(d, s); });

        ev.Globals["voiceAround"] = (Action<DynValue>)(d => { nc.voiceAround = nc.getNoteNumFromDyn(d); });


        //Lua Commands
        ev.Globals["wait"] = (Func<float, DynValue>)(seconds => { return handleCoroutine(lc.wait(seconds)); });

        string scriptString = LoadTextFromStreamingAssets(luaFileName + ".lua");

        ev.DoString(scriptString);
        c = ev.CreateCoroutine(ev.Globals[coroutineToRun]);
        c.Coroutine.Resume();
        rythm.startMetronome();



    }
    
    

    string LoadTextFromStreamingAssets(string fileName)
    {
        string path = System.IO.Path.Combine(Application.streamingAssetsPath, fileName);
        return System.IO.File.ReadAllText(path);
    }

    
    IEnumerator resumeAfterCoroutine(IEnumerator i)
    {
        yield return i;

        c.Coroutine.Resume();
    }
    public DynValue handleCoroutine(IEnumerator i)
    {
        StartCoroutine(resumeAfterCoroutine(i));
        return pause();
        
    }
    static DynValue pause()
    {
        return DynValue.NewYieldReq(new DynValue[0]);
    }





}
