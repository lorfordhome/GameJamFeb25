using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    public float speed = 1;
    public float rotationSpeed = 1;
    private Transform playerTarget;

    // Start is called before the first frame update
    void Start()
    {
        playerTarget = FindObjectOfType<Player>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        //move towards player
        var step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector2.MoveTowards(transform.position, playerTarget.position, step);
        //rotate towards player
        transform.rotation = Quaternion.LookRotation(Vector3.forward, (playerTarget.position - transform.position).normalized);

    }
}
