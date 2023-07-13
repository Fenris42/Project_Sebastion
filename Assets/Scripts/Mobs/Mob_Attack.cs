using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob_Attack : MonoBehaviour
{
    //public variables

    //private variables
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject WallHealthBarObject;
    private StatBar wallHealthBar;
    private Mob_Movement mob_movement;
    private float timer = 0;

    //stats
    [SerializeField] private int attackDamage;
    [SerializeField] private float attackSpeed;



    // Start is called before the first frame update
    void Start()
    {
        //get mobs movement script
        mob_movement = GetComponent<Mob_Movement>();

        //get wall health bar script
        wallHealthBar = WallHealthBarObject.GetComponent<StatBar>();
    }

    // Update is called once per frame
    void Update()
    {
        //attack if in range
        Attack();
    }

    private void Attack()
    {
        if (mob_movement.inAttackRange == true) 
        {
            //convert ticks to seconds
            if (timer >= attackSpeed)
            {
                //play animation
                animator.SetTrigger("Attack");

                

                //apply damage to wall
                wallHealthBar.Remove(attackDamage);

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
}
