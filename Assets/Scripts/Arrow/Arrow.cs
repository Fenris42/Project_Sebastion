using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    //public variables

    //private variables
    private Player_Attack playerAttack;
    private int moveSpeed;
    private int arrowDamage;

    //stats



    // Start is called before the first frame update
    void Start()
    {
        //get players attack script and initialize values
        playerAttack = GameObject.Find("Player").GetComponent<Player_Attack>();
        moveSpeed = playerAttack.GetArrowSpeed();
        arrowDamage = playerAttack.GetArrowDamage();


    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {//arrows flight pattern

        transform.position += (Vector3.right * moveSpeed) * Time.deltaTime;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {//Collision handling

        if (collision.tag == "Kill Zone")
        {//arrow has gone out of bounds

            //delete arrow
            Destroy(gameObject);
        }

        if (collision.tag == "Mob")
        {//arrow hit a mob. apply damage

            //get mobs health scrib
            Mob_Health mob = collision.GetComponent<Mob_Health>();

            //apply damage
            mob.Damage(arrowDamage);

            //delete arrow
            Destroy(gameObject);

        }
    }
}
