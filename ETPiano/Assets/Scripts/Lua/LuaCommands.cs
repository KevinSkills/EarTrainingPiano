using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoonSharp.Interpreter;
using System;

public class LuaCommands : MonoBehaviour
{

    public IEnumerator wait(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }

}
