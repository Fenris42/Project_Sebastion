using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob_Attack : MonoBehaviour
{
    //public variables

    //private variables
    [SerializeField] private Animator animator;
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
                animator.SetTrigger("Attack");

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
