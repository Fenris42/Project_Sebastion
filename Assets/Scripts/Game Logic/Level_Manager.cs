using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class Level_Manager : MonoBehaviour
{
    //public variables

    //private variables
    [SerializeField] private TMP_Text levelNumber;
    [SerializeField] private GameObject Lane1_Spawner;
    [SerializeField] private GameObject Lane2_Spawner;
    [SerializeField] private GameObject Lane3_Spawner;
    [SerializeField] private GameObject Lane4_Spawner;
    [SerializeField] private GameObject Lane5_Spawner;
    private Spawner Lane1;
    private Spawner Lane2;
    private Spawner Lane3;
    private Spawner Lane4;
    private Spawner Lane5;

    private float timer;
    private int wave;
    private int level;



    // Start is called before the first frame update
    void Start()
    {
        //initialize spawners
        Lane1 = Lane1_Spawner.GetComponent<Spawner>();
        Lane2 = Lane2_Spawner.GetComponent<Spawner>();
        Lane3 = Lane3_Spawner.GetComponent<Spawner>();
        Lane4 = Lane4_Spawner.GetComponent<Spawner>();
        Lane5 = Lane5_Spawner.GetComponent<Spawner>();

        //initialize level and wave numbers
        level = 1;
        wave = 1;

        //start running level 1
        SpawnWave(level);

    }

    // Update is called once per frame
    void Update()
    {
        //increment timer
        timer += Time.deltaTime;


        if (timer >= 5)
        {
            //reset timer
            timer = 0;

            //increment current wave
            wave += 1;

            SpawnWave(level);
        }   
    }

    private void SpawnWave(int level)
    {
        if (level == 1)
        {
            Level1();
        }
    }

    private void Level1()
    {
        levelNumber.text = "1";

        if (wave == 1)
        {
            Lane1.SpawnMob("knight");
            Lane3.SpawnMob("knight");
            Lane5.SpawnMob("knight");
        }
        else if (wave == 2)
        {
            Lane2.SpawnMob("knight");
            Lane4.SpawnMob("knight");
        }
        else if (wave == 3)
        {
            Lane1.SpawnMob("knight");
            Lane3.SpawnMob("knight");
            Lane5.SpawnMob("knight");
        }
        else if (wave == 4)
        {
            Lane1.SpawnMob("knight");
            Lane2.SpawnMob("knight");
        }
        else if (wave == 5)
        {
            Lane4.SpawnMob("knight");
            Lane5.SpawnMob("knight");
        }
        else if (wave == 6)
        {
            Lane1.SpawnMob("knight");
            Lane2.SpawnMob("knight");
            Lane3.SpawnMob("knight");
            Lane4.SpawnMob("knight");
            Lane5.SpawnMob("knight");
        }
    }
}
