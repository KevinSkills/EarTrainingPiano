using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeOperator : MonoBehaviour
{
   
    public enum Type
    {
        GREATER,
        LESSER,
        EQUALS,
        OR,
        AND
    }

    public Type type = Type.LESSER;
}
