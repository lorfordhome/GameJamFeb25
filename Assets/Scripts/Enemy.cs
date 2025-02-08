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
    public int expGiven = 1;
    private Player playerTarget;

    // Start is called before the first frame update
    void Start()
    {
        playerTarget = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        //move towards player
        var step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector2.MoveTowards(transform.position, playerTarget.transform.position, step);
        //rotate towards player
        transform.rotation = Quaternion.LookRotation(Vector3.forward, (playerTarget.transform.position - transform.position).normalized) * Quaternion.Euler(0, 0, 90);

    }

    public void takeDamage(float damageTaken)
    {
        health -= damageTaken;
        if (health <= 0)
        {
            playerTarget.RecieveEXP(expGiven);
            Destroy(this.gameObject);
        }
    }
}
