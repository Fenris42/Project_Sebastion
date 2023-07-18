using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_Health : MonoBehaviour
{
    //public variables

    //private variables
    [SerializeField] private GameObject healthBarObject;
    private Stat_Bar healthBar;

    //stats
    [SerializeField] private int currentHealth;
    [SerializeField] private int maxHealth;


    // Start is called before the first frame update
    void Start()
    {
        healthBar = healthBarObject.GetComponent<Stat_Bar>();
        healthBar.SetCurrent(maxHealth);
        healthBar.SetMax(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Heal(int healing)
    {//apply healing

    }

    public void Damage(int damage)
    {//apply damage

        currentHealth -= damage;
        Sanitize();

        healthBar.Remove(damage);

    }

    private void Sanitize()
    {//keep values in range

        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}
