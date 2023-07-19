using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Mob_Arrow : MonoBehaviour
{
    //public variables

    //private variables

    //stats
    public int moveSpeed;



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

        transform.position += (Vector3.left * moveSpeed) * Time.deltaTime;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {//Collision handling

        if (collision.tag == "Kill Zone")
        {//arrow has gone out of bounds

            //delete arrow
            Destroy(gameObject);
        }

        if (collision.tag == "Wall")
        {//arrow hit the wall

            //delete arrow
            Destroy(gameObject);

        }
    }
}
