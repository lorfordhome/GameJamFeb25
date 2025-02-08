using PlasticBand.Devices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public float shotsBeforeReload = 1;
    public float shotsLeft = 0;
    public GameObject bulletPrefab;
    public float bulletDamage=1;
    public float bulletSpeed = 1;
    //controller
    Turntable turntable;

    void Start()
    {
        turntable = Turntable.current;
    }

    void Shoot()
    {
        GameObject bullet=Instantiate(bulletPrefab);
        bullet.GetComponent<Bullet>().damage = bulletDamage;
        bullet.GetComponent<Bullet>().speed = bulletSpeed;
        shotsLeft--;
    }

    // Update is called once per frame
    void Update()
    {
        //shoot
        if (turntable.crossfader.ReadValue() == -1) 
        {
            if (shotsLeft > 0)
            {
                Shoot();
            }
        }
        //reload
        if (turntable.crossfader.ReadValue() == 1)
        {
            shotsLeft = shotsBeforeReload;
        }
    }
}
