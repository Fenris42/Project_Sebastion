using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob_Attack : MonoBehaviour
{
    //public variables

    //private variables
    [SerializeField] private Animator animator;
    [SerializeField] private Wall_Health wallHealth;
    private Mob_Movement mobMovement;
    private float timer = 0;
    private Mob_Health mobHealth;

    //stats
    [SerializeField] private int attackDamage;
    [SerializeField] private float attackSpeed;



    // Start is called before the first frame update
    void Start()
    {
        //get mobs movement script
        mobMovement = GetComponent<Mob_Movement>();

        //get mobs health script
        mobHealth = GetComponent<Mob_Health>();

        //get wall health script
        wallHealth = GameObject.Find("Game Logic").GetComponent<Wall_Health>();
    }

    // Update is called once per frame
    void Update()
    {
        //attack if in range
        Attack();
    }

    private void Attack()
    {
        if (mobMovement.inAttackRange == true && mobHealth.alive == true) 
        {
            //convert ticks to seconds
            if (timer >= attackSpeed)
            {
                //play animation
                animator.SetTrigger("Attack");

                //delay damage to sync with animation
                float delay = 0.5f;
                Invoke("DamageWall", delay);

                //reset timer
                timer = 0;
            }
            else
            {
                //increment timer
                timer += Time.deltaTime;
            }
        }
    }

    private void DamageWall()
    {
        //apply damage to wall
        wallHealth.Damage(attackDamage);
    }
}
