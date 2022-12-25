using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeBoolBox : HeBooler
{
    public HeObject obj1;

    public HeOperator op;

    public HeObject obj2;


    private void Update()
    {
        
    }

    public override bool getValue()
    {
        switch (op.type)
        {
            case HeOperator.Type.LESSER:
                if (((HeValue)obj1).value < ((HeValue)obj2).value) return true;
                break;

            case HeOperator.Type.GREATER:
                if (((HeValue)obj1).value > ((HeValue)obj2).value) return true;
                break;

            case HeOperator.Type.EQUALS:
                if (((HeValue)obj1).value.Equals( ((HeValue)obj2).value)) return true;
                break;

            case HeOperator.Type.AND:
                if (((HeBooler)obj1).getValue() && ((HeBooler)obj2).getValue()) return true;
                break;

            case HeOperator.Type.OR:
                if (((HeBooler)obj1).getValue() || ((HeBooler)obj2).getValue()) return true;
                break;
        }


        return false;
    }



}
