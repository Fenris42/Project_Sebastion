using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    //public variables


    //private variables
    [SerializeField] private Animator animator;
    [SerializeField] private int moveSpeed;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //check for player inputs
        PlayerInput();
    }

    private void PlayerInput()
    {
        //both up and down held at same time
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S))
        {
            //force idle animation
            animator.SetBool("Running", false);
        }
        //move up
        else if (Input.GetKey(KeyCode.W))
        {
            transform.position = transform.position + ((Vector3.up * moveSpeed) * Time.deltaTime);

            //play animation
            animator.SetBool("Running", true);
        }
        //move down
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position = transform.position + ((Vector3.down * moveSpeed) * Time.deltaTime);

            //play animation
            animator.SetBool("Running", true);
        }
        //return to idle
        else
        {
            animator.SetBool("Running", false);
        }
    }
}
