using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
   public enum RotationAxis
    {
        MouseX = 1,
        MouseY = 2
    }

    public RotationAxis axes = RotationAxis.MouseX;

    // hversu langt spilarinn má hreyfa músina mikið upp og niður  
    public float minVert = -90.0f;
    public float maxVert = 90.0f;

    // hraði á músinni
    public float sensHorizontal = 10.0f; 
    public float sensVertical = 10.0f;

    public float rotationX = 0;

    // Update is called once per frame
    void Update()
    {
        if (axes == RotationAxis.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensHorizontal, 0); // snýr skjáinn þegar spilarinn hreyfir músina til hægri og vinstri
        }
        else if (axes == RotationAxis.MouseY)
        {
            rotationX -= Input.GetAxis("Mouse Y") * sensVertical; // snýr skjáinn þegar spilarinn hreyfir músina til hægri og vinstri
            rotationX = Mathf.Clamp(rotationX, minVert, maxVert); // stoppar hreyfinguna á skjánum þegar að skjárinn er búinn að snúast ákveðið langt up og niður

            float rotationY = transform.localEulerAngles.y; // heldur snúningnum þannig að það er ekki láréttur snúningur 

            transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);
        }
    }
}
