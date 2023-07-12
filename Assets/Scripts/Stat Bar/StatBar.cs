using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class StatBar : MonoBehaviour
{
    //public variables
    public int value;
    public int max;

    //private variables
    [SerializeField] private Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Sanitize();
        UpdateBar();
    }

    //ensure values stay in range
    private void Sanitize()
    {
        if (value < 0)
        {
            value = 0;
        }
        if (value > max)
        {
            value = max;
        }
    }

    //set slider to percentage of current and max values
    private void UpdateBar()
    {
        //get bar fill ratio
        float percentage = (float)value / (float)max;

        //scale health bar fill
        slider.value = percentage;
    }
}
