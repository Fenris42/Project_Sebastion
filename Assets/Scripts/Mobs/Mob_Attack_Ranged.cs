using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob_Attack_Ranged : MonoBehaviour
{
    //public variables

    //private variables
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject arrowPrefab;
    private Wall_Health wallHealth;
    private Mob_Movement mobMovement;
    private float timer = 0;
    private Mob_Health mobHealth;

    //stats
    [SerializeField] private int attackDamage;
    [SerializeField] private float attackSpeed;
    [SerializeField] private int arrowSpeed;



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
            RangedAttack();
        }
    }

    private void RangedAttack()
    {
        //convert ticks to seconds
        if (timer >= attackSpeed)
        {
            //play animation
            animator.SetTrigger("Attack");

            //fire arrow
            float delay = 0.5f;
            Invoke("SpawnArrow", delay);

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

    private void SpawnArrow()
    {
        //spawn on players position and offset slightly for visual effect
        float xCoord = (float)(transform.position.x + 0f); //offset arrow to be not centered on mob
        float yCoord = (float)(transform.position.y + 0.5f); //offset arrow to be towards hands

        //preset arrow stats
        var arrow = arrowPrefab.GetComponent<Arrow>();
        arrow.ArrowSpeed = arrowSpeed;
        arrow.ArrowDamage = attackDamage;
        arrow.ArrowDirection = -1;

        //spawn arrow
        Instantiate(arrowPrefab, new Vector3(xCoord, yCoord), transform.rotation);
    }
}
