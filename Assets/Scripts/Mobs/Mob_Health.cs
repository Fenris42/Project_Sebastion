using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob_Health : MonoBehaviour
{
    //public varaibles

    //private variables
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject healthBarObject;
    private StatBar statbar;

    //stats
    [SerializeField] private int health;
    [SerializeField] private int maxHealth;


    // Start is called before the first frame update
    void Start()
    {
        //import statbar script from health bar
        statbar = healthBarObject.GetComponent<StatBar>();

        //set health bar max amount
        statbar.max = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //call health bar meter to update
        UpdateHealthBar();

    }

    public void Damage(int damage)
    {
        //apply damage
        health -= damage;

        //keep values in range
        Sanitize();

        //check if dead
        if (health <= 0)
        {
            Die();
        }
        else
        {
            PlayHurtAnimation();
        }
    }

    public void Heal(int healing)
    {
        //apply healing
        health += healing;

        //keep values in range
        Sanitize();

    }

    private void Die()
    {

    }

    private void UpdateHealthBar()
    {
        //update health bar
        statbar.value = health;
    }

    private void Sanitize()
    {
        if (health < 0)
        {
            health = 0;
        }
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    private void PlayHurtAnimation()
    {
        //play hurt animation
        animator.SetTrigger("Hurt");
    }
}
