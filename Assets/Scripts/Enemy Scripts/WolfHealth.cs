using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfHealth : MonoBehaviour
{
    [SerializeField]private GameObject healthUi;

    private float scale;

    [SerializeField] private int maxHealth = 150;

    private int currentHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        scale = (float)currentHealth / maxHealth;
        healthUi.transform.localScale = new Vector3(scale,healthUi.transform.localScale.y,1f);

        if (currentHealth <= 0)
            Destroy(gameObject);
    }








}//class
























