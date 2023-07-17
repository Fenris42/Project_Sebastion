using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob_Health : MonoBehaviour
{
    //public varaibles
    public bool alive = true;

    //private variables
    [SerializeField] private Animator animator;
    [SerializeField] private Collider2D boxCollider;
    [SerializeField] private GameObject healthBarObject;
    private StatBar healthBar;
    private Mob_Movement mobMovement;

    //stats
    [SerializeField] private int despawnTime;
    [SerializeField] private int currentHealth;
    [SerializeField] private int maxHealth;


    
    void Start()
    {// Start is called before the first frame update

        //import healthbars script and initialize stats
        healthBar = healthBarObject.GetComponent<StatBar>();
        healthBar.SetCurrent(maxHealth);
        healthBar.SetMax(maxHealth);

        //import mob movement script
        mobMovement = GetComponent<Mob_Movement>();
    }

    
    void Update()
    {// Update is called once per frame


    }

    public void Heal(int healing)
    {//apply healing to mob



    }

    public void Damage(int damage)
    {//apply damage to mob

        currentHealth -= damage;
        Sanitize();

        healthBar.Remove(damage);

        if (currentHealth > 0)
        {
            //play hurt animation
            animator.SetTrigger("Hurt");
        }
        else if (currentHealth <= 0)
        {
            Die();
        }
        
    }

    private void Die()
    {//mob has been killed

        //mob has died. stop movement and attack
        alive = false;

        //play animation
        animator.SetBool("Die", true);

        //disable mobs health bar
        healthBarObject.SetActive(false);

        //disable mobs hit box
        boxCollider.enabled = false;

        /*
        //spawn loot ------------
        //spawn position
        float xCoord = (float)(transform.position.x + 0);
        float yCoord = (float)(transform.position.y - 0);

        //set loot
        lootPrefab.InventoryItem = loot;
        lootPrefab.Quantity = 1;

        //spawn loot
        Instantiate(lootPrefab, new Vector3(xCoord, yCoord), transform.rotation);
        */

        //delete mob after 1 sec
        Invoke("DeleteMob", despawnTime);

    }

    private void DeleteMob()
    {//destroy mobs game object 
        Destroy(gameObject);
    }

    private void Sanitize()
    {//keep values in range

        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}
