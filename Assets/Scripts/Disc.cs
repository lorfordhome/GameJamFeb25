using PlasticBand.Devices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Disc : MonoBehaviour
{
    PlasticBand.Devices.Turntable turntable;
    public float spinSpeed = 9;

    void OnEnable()
    {
        turntable = Turntable.current;
    }

   
    // Update is called once per frame
    void Update()
    {
        //move disc
        this.transform.rotation *= Quaternion.Euler(0, 0, turntable.rightTableVelocity.ReadValue()*spinSpeed*Time.deltaTime);
    }
}
