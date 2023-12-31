using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Resource_Manager : MonoBehaviour
{
    //public variables

    //private variables
    [SerializeField] TMP_Text woodCounter;
    [SerializeField] TMP_Text stoneCounter;
    [SerializeField] TMP_Text goldCounter;
    private int wood;
    private int stone;
    private int gold;


    // Start is called before the first frame update
    void Start()
    {
        //initialize resources
        wood = 0;
        stone = 0;
        gold = 0;

        //Refresh UI
        UpdateCounters();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Add(string resource, int quantity)
    {// add a resource

        if (resource.ToLower() == "wood")
        {
            wood += quantity;
        }
        else if (resource.ToLower() == "stone")
        {
            stone += quantity;
        }
        else if (resource.ToLower() == "gold")
        {
            gold += quantity;
        }

        UpdateCounters();
    }

    public void Remove(string resource, int quantity)
    {//remove a resource

        if (resource.ToLower() == "wood")
        {
            wood -= quantity;
        }
        else if (resource.ToLower() == "stone")
        {
            stone -= quantity;
        }
        else if (resource.ToLower() == "gold")
        {
            gold -= quantity;
        }

        UpdateCounters();
    }

    private void UpdateCounters()
    {//refresh UI counters
        woodCounter.text = wood.ToString();
        stoneCounter.text = stone.ToString();
        goldCounter.text = gold.ToString();
    }
}
