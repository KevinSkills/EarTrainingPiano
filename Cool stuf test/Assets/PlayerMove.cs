using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    MyInput myInput;

    Rigidbody2D rigidbody2D;

    [SerializeField]
    float maxSpeed;



    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        if (rigidbody2D == null) Debug.LogWarning("No rigidbody2D on the gameobject: " + gameObject.name);

        myInput.onInputForward += moveForward;
    }


    void moveForward()
    {
        transform.position += transform.up * maxSpeed * Time.deltaTime;
    }
}
