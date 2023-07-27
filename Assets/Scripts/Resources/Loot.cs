using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    //public variables

    //private variables
    private Resource_Manager resourceManager;

    //stats
    [SerializeField] private string item;
    public int quantity;

    // Start is called before the first frame update
    void Start()
    {
     //initialize scripts
     resourceManager = GameObject.Find("Game Logic").GetComponent<Resource_Manager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickUp()
    {
        //add resource to UI
        resourceManager.Add(item, quantity);

        //delete item
        Destroy(gameObject);
    }
}
