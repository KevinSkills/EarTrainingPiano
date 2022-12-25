using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyInput : MonoBehaviour
{
    public delegate void OnInputTurn(int i);
    public OnInputTurn onInputTurn;

    public delegate void OnInputForward();
    public OnInputForward onInputForward;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var horizontal = (int)Input.GetAxisRaw("Horizontal");
        if (horizontal != 0) onInputTurn(horizontal);

        var vertical = (int)Input.GetAxisRaw("Vertical");
        if (vertical == 1) onInputForward();
    }



}
