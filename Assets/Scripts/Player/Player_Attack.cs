using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    //public variables

    //private variables
    [SerializeField] GameObject arrowPrefab;
    [SerializeField] Animator animator;
    [SerializeField] GameObject chargeBarObject;
    private Stat_Bar chargeBar;
    private float drawStrength;
    private bool chargeOnCooldDown;

    //stats
    [SerializeField] private int arrowDamage;
    [SerializeField] private int arrowSpeed;
    [SerializeField] private float drawSpeed;


    // Start is called before the first frame update
    void Start()
    { 
        //initialize charge bar
        chargeBar = chargeBarObject.GetComponent<Stat_Bar>();
        chargeBar.SetCurrent(0);
        chargeBar.SetMax(100);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();
    }

    private void PlayerInput()
    {
        //if (Input.GetMouseButtonDown(1))
        if (Input.GetMouseButton(1))
        {//right mouse button held. charge arrow shot

            ChargeShot();
        }
        else if (Input.GetMouseButtonUp(1))
        {//right mouse button released. fire arrow

            ArrowAttack();
        }
    }

    private void ChargeShot()
    {//charge bows strength

        //only allow charging if now on cooldown
        if (chargeOnCooldDown == false)
        {
            //unhide charge bar
            chargeBarObject.SetActive(true);

            if (drawStrength <= 100)
            {//increase bows charge level
                drawStrength += (float)drawSpeed * Time.deltaTime;
            }

            //update charge bars fill
            chargeBar.SetFill((int)drawStrength);
        }
        
    }

    private void ArrowAttack()
    {//fire arrow

        //temp disable charging while attack in progress
        chargeOnCooldDown = true;

        //fire arrow only if over min threshold 
        if (drawStrength >= 25)
        {
            //play animation
            animator.SetTrigger("Attack");

            //spawn arrow in sync with animation
            Invoke("SpawnArrow", 0.5f);
            Invoke("ResetCharge", 0.6f);
        }
        else
        {
            ResetCharge();
        }
    }

    private void ResetCharge()
    {
        //reset draw
        chargeOnCooldDown = false;
        drawStrength = 0;
        chargeBar.SetCurrent((int)drawStrength);

        //hide charge bar
        chargeBarObject.SetActive(false);
    }

    private void SpawnArrow()
    {

        //spawn on players position and offset slightly for visual effect
        float xCoord = (float)(transform.position.x - 0.5); //offset arrow to be not centered on player
        float yCoord = (float)(transform.position.y + 1); //offset arrow to be towards hands

        var arrow = arrowPrefab.GetComponent<Arrow>();
        arrow.ArrowSpeed = arrowSpeed;
        arrow.ArrowDamage = arrowDamage * (drawStrength / 100); //reduce max damage based on % of charge bar filled
        arrow.ArrowDirection = 1;

        //spawn arrow
        Instantiate(arrowPrefab, new Vector3(xCoord, yCoord), transform.rotation);
    }
}
