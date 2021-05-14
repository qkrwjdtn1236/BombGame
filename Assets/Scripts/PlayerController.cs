using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float translation;
    private float rotation;

    public float PlayerSpeed;
    public float PlayerRotateSpeed;
    void Update()
    {
        translation = Input.GetAxis("Vertical") * PlayerSpeed;

        rotation = Input.GetAxis("Horizontal") * PlayerRotateSpeed;

        transform.Translate(0, 0, translation*Time.deltaTime);
        transform.Rotate(0, rotation*Time.deltaTime, 0);
    }
}
