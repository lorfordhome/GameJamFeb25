using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int maxHealth=5;
    public float currentHealth;
    public int level = 1;
    public int currentEXP = 0;
    public int expToLevel = 3;



    private void Awake()
    {
        currentHealth = maxHealth;
    }
    void Start()
    {

    }

    void Die()
    {
        Debug.Log("you died :(");
        SceneManager.LoadScene("GameOver");
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void LevelUp()
    {
        Debug.Log("Level up");
    }
    public void RecieveEXP(int expGain)
    {
        currentEXP += expGain;
        if (currentEXP >= expToLevel)
        {
            LevelUp();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            currentHealth -= 1;
        }
    }

}
