using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StatBar : MonoBehaviour
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
    {
        current = amount;
    }

    public void SetMax(int amount)
    {
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

        current += amount;
        Sanitize();

        UpdateChangeBar();

        //delay updating the fill bar for 1 sec
        Invoke("UpdateFillBar", 1);

    }

    public void Remove(int amount)
    {//reduce stat bar and play animation

        current -= amount;
        Sanitize();

        UpdateFillBar();

        //delay updating the change bar for 1 sec
        Invoke("UpdateChangeBar", 1);
    }

}
