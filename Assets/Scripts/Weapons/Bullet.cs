using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Weapon
{
    public float speed;
    public float pierce = 1;
    
    void Update()
    {
        this.transform.position -=new Vector3(0f, speed * Time.deltaTime,0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        { 
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy.health > 0)
            {
                enemy.takeDamage(damage);

                pierce--;
                if (pierce <= 0)
                    Destroy(this.gameObject);
            }

        }
    }
}
