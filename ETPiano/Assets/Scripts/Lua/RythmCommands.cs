using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoonSharp.Interpreter;
using System;


public class RythmCommands : MonoBehaviour
{

    public float bpm;

    public int beatsInMeasure;

    public int measures;


    public float currentBeat;

    private UnityEngine.Coroutine met;

    LuaEnviroment luaEnv;

    public Action metronomeClick;

    public RythmCommands(LuaEnviroment luaEnv) : this(120, 4, 1, luaEnv)
    {

    }

    public RythmCommands(float bpm, int beatsInMeasure, int measures, LuaEnviroment luaEnv)
    {
        this.bpm = bpm;

        this.beatsInMeasure = beatsInMeasure;

        this.measures = measures;

        this.currentBeat = -4.5f;

        this.luaEnv = luaEnv;

    }

    public void startMetronome()
    {
        if (met != null) StopCoroutine(met);
        met = luaEnv.StartCoroutine(metronome());


    }


    /// <summary>
    /// Set the player to the total amounts of beats b
    /// </summary>
    public IEnumerator SetBeat(float b)
    {  
        b -= 1;

        float theBeat = Mathf.Min(roundLength() -1, b);

        yield return waitForBeat (theBeat);
    }

    /// <summary>
    /// Set the player to the m measure and mb beat
    /// </summary>
    public IEnumerator SetBeat(int m, float mb)
    {
        m -= 1;
        float b = m * beatsInMeasure + mb;

        yield return SetBeat(b);
    }

    IEnumerator metronome()
    {
        float multiplier = bpm/60;


        while (true)
        {
            int a = (int)(currentBeat + roundLength()); ;
            currentBeat += Time.deltaTime * multiplier;

            if(a != (int)(currentBeat + roundLength())) //beat change
            {
                print(currentBeat);
                metronomeClick();
            }
            if(currentBeat > roundLength())
            {
                currentBeat -= roundLength();
            }

            yield return null;
        }
    }

    private float roundLength()
    {
        return beatsInMeasure* measures;
    }

    IEnumerator waitForBeat(float b)
    {

        if (currentBeat > b && currentBeat > 0.5f) Debug.LogError("Bad");

        print("waiting for beat + " + b);


        while (currentBeat < b)
        {
            yield return null;
        }


    }



    /// <summary>
    /// Waits for next round to start
    /// </summary>
    public IEnumerator endRound()
    {

        while (currentBeat > 0.5f)
        {
            yield return null;
        }


        


    }



}
