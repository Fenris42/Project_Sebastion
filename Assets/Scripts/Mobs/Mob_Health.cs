using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob_Health : MonoBehaviour
{
    //public varaibles

    //private variables
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject healthBarObject;
    private StatBar healthBar;

    //stats
    [SerializeField] private int currentHealth;
    [SerializeField] private int maxHealth;


    
    void Start()
    {// Start is called before the first frame update

        //import healthbars script and initialize stats
        healthBar = healthBarObject.GetComponent<StatBar>();
        healthBar.SetCurrent(maxHealth);
        healthBar.SetMax(maxHealth);

    }

    
    void Update()
    {// Update is called once per frame


    }

    public void Heal(int healing)
    {//apply healing to mob



    }

    public void Damage(int damage)
    {//apply damage to mob


        //play hurt animation
        animator.SetTrigger("Hurt");
    }

    private void Die()
    {//

    }

    private void UpdateHealthBar()
    {//update mobs health bar


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
