using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _healthbarSprite;
    [SerializeField] private float reduceSpeed = 2;
    private float target = 1;

    public void Start()
    {
        _healthbarSprite = GetComponent<Image>();
    }

    public void UpdateHealthBar(float maxHealth, float currentHealth)//called when the player takes damage
    {
        target = currentHealth / maxHealth;
    }
    private void Update()//this makes a small animation effect just to make it look a little cleaner
    {
        _healthbarSprite.fillAmount = Mathf.MoveTowards(_healthbarSprite.fillAmount, target, reduceSpeed * Time.deltaTime);
    }
}
