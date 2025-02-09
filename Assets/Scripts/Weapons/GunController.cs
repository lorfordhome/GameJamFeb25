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
    public float bulletScale = 1;
    public float fireRate = 0.8f;
    float timer = 0;
    bool waitingToFire = false;
    bool increaseScale = false;
    bool decreaseScale = false;
    Transform player;
    //controller
    Turntable turntable;
    public Vector3 playerDefaultScale = new Vector3(0.37f, 0.37f, 0.37f);
    public Vector3 shootScaleIncrease=new Vector3(0.4f,0.4f,0.4f);
    public float scaleSpeed = 0.25f;

    void Start()
    {
        turntable = Turntable.current;
        player = this.transform.parent;
    }

    void Shoot()
    {
        GameObject bullet=Instantiate(bulletPrefab);
        bullet.transform.localScale *= bulletScale;
        bullet.GetComponent<Bullet>().damage = bulletDamage;
        bullet.GetComponent<Bullet>().speed = bulletSpeed;
        shotsLeft--;
        increaseScale = true;
        if (shotsLeft != 0)
        {
            waitingToFire = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (increaseScale)
        {
            player.localScale = Vector3.Lerp(player.localScale, shootScaleIncrease, scaleSpeed * Time.deltaTime);
            if (player.localScale == shootScaleIncrease)
            {
                Debug.Log("Finished increasing scale");
                increaseScale =false;
                decreaseScale = true;
            }
        }
        if (decreaseScale) {

            player.localScale = Vector3.Lerp(player.localScale, playerDefaultScale, scaleSpeed * Time.deltaTime);
            if (player.localScale == playerDefaultScale)
            {
                Debug.Log("Finished decreasing scale");
                decreaseScale=false;
            }
        }
        if (waitingToFire)
        {
            timer += Time.deltaTime;
            if (timer >= fireRate)
            {
                timer = 0;
                waitingToFire=false;
            }
        }
        //shoot
        if (turntable.crossfader.ReadValue() == -1) 
        {
            if (shotsLeft > 0&&!waitingToFire)
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
