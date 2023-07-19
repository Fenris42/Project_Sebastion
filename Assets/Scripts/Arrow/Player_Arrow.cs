using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Player_Arrow : MonoBehaviour
{
    //public variables

    //private variables
    private Player_Attack playerAttack;


    //stats
    public int MoveSpeed;
    public int ArrowDamage;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {//arrows flight pattern

        transform.position += (Vector3.right * MoveSpeed) * Time.deltaTime;

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
            mob.Damage(ArrowDamage);

            //delete arrow
            Destroy(gameObject);

        }
    }
}
