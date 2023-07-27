using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob_Attack_Melee : MonoBehaviour
{
    //public variables

    //private variables
    [SerializeField] private Animator animator;
    private Wall_Health wallHealth;
    private Mob_Movement mobMovement;
    private float timer = 0;
    private Mob_Health mobHealth;
    [SerializeField] private Transform meleeAttackRangeGO;

    //stats
    [SerializeField] private int attackDamage;
    [SerializeField] private float attackSpeed;
    [SerializeField] private float meleeAttackRange;



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
        if (mobMovement.inAttackRange == true && mobHealth.alive == true)
        {
            //attack if in range
            MeleeAttack();
        }
    }

    private void MeleeAttack()
    {
        //convert ticks to seconds
        if (timer >= attackSpeed)
        {
            //play animation
            animator.SetTrigger("Attack");

            //Get targets in melee range
            Collider2D[] targets = Physics2D.OverlapCircleAll(meleeAttackRangeGO.position, meleeAttackRange);

            foreach(Collider2D target in targets)
            {
                if (target.tag == "Wall")
                {
                    //delay damage to sync with animation
                    float delay = 0.5f;
                    Invoke("DamageWall", delay);
                }
            }

            //reset timer
            timer = 0;
        }
        else
        {
            //increment timer
            timer += Time.deltaTime;
        }
    }

    private void DamageWall()
    {
        //apply damage to wall
        wallHealth.Damage(attackDamage);
    }

    private void OnDrawGizmosSelected()
    {//draw spawn zone in inspector

        Gizmos.DrawWireSphere(meleeAttackRangeGO.position, meleeAttackRange);
    }
}
