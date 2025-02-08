using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int maxHealth=5;
    public float currentHealth;
    public int level = 1;
    public float currentEXP = 0;
    public float EXPIncrement = 1.2f; //how much exptolevel increases each level
    public float expToLevel = 3;

    //health bars
    public HealthBar healthBar;
    public HealthBar ExperienceBar;


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

    void TakeDamage(float damageToTake)
    {
        currentHealth-= damageToTake;
        healthBar.UpdateHealthBar(maxHealth, currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Update()
    {

    }

    void LevelUp()
    {
        Debug.Log("Level up");
        //check for excess exp
        float excessEXP = expToLevel - currentEXP;
        currentEXP = 0;
        expToLevel *= EXPIncrement;
        ExperienceBar.UpdateHealthBar(expToLevel,currentEXP);
        if (excessEXP > 0)
        {
            RecieveEXP(excessEXP);
        }

    }
    public void RecieveEXP(float expGain)
    {
        currentEXP += expGain;
        ExperienceBar.UpdateHealthBar(expToLevel, currentEXP);
        if (currentEXP >= expToLevel)
        {
            LevelUp();
         
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            TakeDamage(1);
        }
    }

}
