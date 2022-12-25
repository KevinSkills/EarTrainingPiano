using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeBoolContainer : HeBooler
{
    public bool not;

    public HeBooler obj;
    public override bool getValue()
    {
        if (not) return !obj.getValue();
        else return obj.getValue();
    }

    private void Start()
    {
        print(getValue());
    }


}
