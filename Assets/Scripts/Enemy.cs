using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    public float health = 1;
    public float speed = 1;
    public float rotationSpeed = 1;
    public float expGiven = 1;
    private Player playerTarget;
    public float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerTarget = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health > 0)
        {
            //move towards player
            var step = speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector2.MoveTowards(transform.position, playerTarget.transform.position, step);
            //rotate towards player
            transform.rotation = Quaternion.LookRotation(Vector3.forward, (playerTarget.transform.position - transform.position).normalized) * Quaternion.Euler(0, 0, 90);
        }
        else
        {
            timer+= Time.deltaTime;
            if (timer > 0.5f)
            {
                Destroy(this.gameObject);
            }
        }

    }

    public void takeDamage(float damageTaken)
    {
        if (health > 0)
        {
            health -= damageTaken;
            if (health <= 0)
            {
                playerTarget.RecieveEXP(expGiven);
                this.GetComponent<SpriteRenderer>().enabled = false;
                this.GetComponent<ParticleSystem>().Play();
            }
        }
    }
}
