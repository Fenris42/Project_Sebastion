using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Stat_Bar : MonoBehaviour
{
    //public variables

    //private variables
    [SerializeField] private Slider fillSlider;
    [SerializeField] private Slider changeSlider;
    [SerializeField] private int current;
    [SerializeField] private int max;



    void Start()
    {// Start is called before the first frame update

    }

    void Update()
    {// Update is called once per frame
        
    }

    public void SetCurrent(int amount)
    {//initialize bars current value
        current = amount;
    }

    public void SetMax(int amount)
    {//initialize bars max value
        max = amount;
    }

    private void Sanitize()
    {//ensure values stay in range

        if (current < 0)
        {
            current = 0;
        }
        if (current > max)
        {
            current = max;
        }
    }

    private void UpdateFillBar()
    {//set slider to percentage of current and max values

        //get bar fill ratio
        float percentage = (float)current / (float)max;

        //scale health bar fill
        fillSlider.value = percentage;

    }

    private void UpdateChangeBar()
    {//set slider to percentage of current and max values

        //get bar fill ratio
        float percentage = (float)current / (float)max;

        //scale health bar fill
        changeSlider.value = percentage;

    }

    public void Add(int amount)
    {//increase stat bar and play animation

        //add amount from bar
        current += amount;

        //keep values in range
        Sanitize();

        //apply updates to secondary bar
        UpdateChangeBar();

        //delay updating the main bar for 1 sec
        Invoke("UpdateFillBar", 1);

    }

    public void Remove(int amount)
    {//reduce stat bar and play animation

        //remove amount from bar
        current -= amount;

        //keep values in range
        Sanitize();

        //apply updates to main bar
        UpdateFillBar();

        //delay updating the secondary bar for 1 sec
        Invoke("UpdateChangeBar", 1);
    }
    
    public void SetFill(int amount)
    {
        //set current fill bar ammount
        current = amount;

        //keep values in range
        Sanitize();

        //apply updates to main bar
        UpdateFillBar();
    }

}
