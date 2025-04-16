using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private float health;
    public float maxHealth = 100f;
    public Image frontHealthBar;
    public Image backHealthBar;

    void Start()
    {
        health = maxHealth;
    }

    void Update()
    {
        health = Mathf.Clamp(health, 0, maxHealth);
        UpdateHealthUI();
    }

    public void UpdateHealthUI()
    {
        float fillF = frontHealthBar.fillAmount;
        float fillB = backHealthBar.fillAmount;
        float hFraction = health / maxHealth;

        if (fillB > hFraction)
        {
            frontHealthBar.fillAmount = hFraction;
            backHealthBar.color = Color.red;
            backHealthBar.fillAmount = Mathf.Lerp(fillB, hFraction, Time.deltaTime * 2f);
        }

        if (fillF < hFraction)
        {
            backHealthBar.color = Color.green;
            backHealthBar.fillAmount = hFraction;
            frontHealthBar.fillAmount = Mathf.Lerp(fillF, backHealthBar.fillAmount, Time.deltaTime * 2f);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    public void RestoreHealth(float healAmount)
    {
        health += healAmount;
    }
}
