using PlasticBand.Devices;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.InputSystem;


public class Disc : MonoBehaviour
{
    PlasticBand.Devices.Turntable turntable;

    void OnEnable()
    {
        turntable = Turntable.current;
    }

    void Awake()
    {
    }
    // Update is called once per frame
    void Update()
    {
        //move disc
        this.transform.rotation *= Quaternion.Euler(0, 0, turntable.rightTableVelocity.ReadValue());
    }
}
