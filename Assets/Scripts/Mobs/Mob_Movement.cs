using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob_Movement : MonoBehaviour
{
    //public variables
    public bool inAttackRange = false;

    //private variables
    [SerializeField] private Animator animator;
    private bool inMeleeAttackRange = false;
    private bool inRangedAttackRange = false;

    //stats
    [SerializeField] private int moveSpeed;
    [SerializeField] private bool isMelee;
    [SerializeField] private bool isRanged;



    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        //check if in attack range
        RangeCheck();

        //move forward
        Movement();

    }

    private void RangeCheck()
    {
        //ranged attack range check
        if (isRanged == true)
        {
            if (inRangedAttackRange == true)
            {
                inAttackRange = true;
            }
            else
            {
                inAttackRange = false;
            }
        }

        //melee attack range check
        if (isMelee == true)
        {
            if (inMeleeAttackRange == true)
            {
                inAttackRange = true;
            }
            else
            {
                inAttackRange = false;
            }
        }
    }
    private void Movement()
    {
        if (inAttackRange == false)
        {
            //move left until reaching attack range for mob type
            transform.position = transform.position + ((Vector3.left * moveSpeed) * Time.deltaTime);

            //play running animation
            animator.SetBool("Running", true);
        }
        else
        {
            //return to idle animation
            animator.SetBool("Running", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //mob has entered ranged attack range
        if (collision.gameObject.name == "Ranged Trigger")
        {
            inRangedAttackRange = true;
        }

        //mob has entered melee attack range
        if (collision.gameObject.name == "Melee Trigger")
        {
            inMeleeAttackRange = true;
        }
    }
}
