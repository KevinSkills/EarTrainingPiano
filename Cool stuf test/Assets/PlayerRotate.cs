using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    [SerializeField]
    MyInput myInput;

    Rigidbody2D rigidbody2D;

    [SerializeField]
    float maxRotationSpeed;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        if (rigidbody2D == null) Debug.LogWarning("No rigidbody2D on the gameobject: " + gameObject.name);

        myInput.onInputTurn += rotate;
    }

    void rotate(int rotationDirection)
    {
        transform.Rotate(0, 0, -rotationDirection * maxRotationSpeed * Time.deltaTime);
    }
}
