using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    //public variables

    //private variables

    //stats
    public int ArrowSpeed;
    public int ArrowDamage;
    public int ArrowDirection; //Left = -1, Right = 1


    // Start is called before the first frame update
    void Start()
    {
        //set sprites orientation
        SetDirection();
    }

    // Update is called once per frame
    void Update()
    {
        //move arrow across screen
        Move();
    }

    private void Move()
    {//arrows flight pattern

        //Left
        if (ArrowDirection == -1) 
        {
            transform.position += (Vector3.left * ArrowSpeed) * Time.deltaTime;
        }
        //right
        else if (ArrowDirection == 1)
        {
            transform.position += (Vector3.right * ArrowSpeed) * Time.deltaTime;
        }
        

    }

    private void SetDirection()
    {//set sprite direction of arrow

        //set arrow rotation coords
        float x = transform.rotation.x;
        float y = transform.rotation.y;
        float z = 90 * ArrowDirection;

        //set arrows rotation
        transform.Rotate(x, y, z);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {//Collision handling

        if (collision.tag == "Kill Zone")
        {//arrow has gone out of bounds

            //delete arrow
            Destroy(gameObject);
        }

        //arrow fired by player
        if (ArrowDirection == 1)
        {
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
        //arrow fired by mob
        else if (ArrowDirection == -1)
        {
            if (collision.tag == "Wall")
            {//arrow hit the wall. apply damage

                //get mobs health scrib
                Wall_Health wall = GameObject.Find("Game Logic").GetComponent<Wall_Health>();

                //apply damage
                wall.Damage(ArrowDamage);

                //delete arrow
                Destroy(gameObject);

            }
        }
        
        
    }
}
