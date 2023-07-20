using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    //public variables

    //private variables
    [SerializeField] GameObject arrowPrefab;
    [SerializeField] Animator animator;

    //stats
    [SerializeField] private int arrowDamage;
    [SerializeField] private int arrowSpeed;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();
    }

    private void PlayerInput()
    {
        if (Input.GetMouseButtonDown(1))
        {//right mouse button pressed. fire arrow

            ArrowAttack();
        }
    }

    private void ArrowAttack()
    {
        //play animation
        animator.SetTrigger("Attack");

        //spawn arrow in sync with animation
        float delay = 0.5f;
        Invoke("SpawnArrow", delay);
    }

    private void SpawnArrow()
    {
        //spawn on players position and offset slightly for visual effect
        float xCoord = (float)(transform.position.x - 0.5); //offset arrow to be not centered on player
        float yCoord = (float)(transform.position.y + 1); //offset arrow to be towards hands

        var arrow = arrowPrefab.GetComponent<Arrow>();
        arrow.ArrowSpeed = arrowSpeed;
        arrow.ArrowDamage = arrowDamage;
        arrow.ArrowDirection = 1;

        //spawn arrow
        Instantiate(arrowPrefab, new Vector3(xCoord, yCoord), transform.rotation);
    }
}
