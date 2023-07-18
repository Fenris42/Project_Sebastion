using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //public variables

    //private variables
    [SerializeField] private GameObject mob_knight;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnMob(string mob)
    {//spawn a mob prefab into current spawners coordinates

        //spawn coordinates
        float xCoord = transform.position.x;
        float yCoord = transform.position.y - 1.5f;
        quaternion zCoord = transform.rotation;

        //spawn mob
        if (mob == "knight")
        {
            Instantiate(mob_knight, new Vector3(xCoord, yCoord), zCoord);
        }

    }

    private void OnDrawGizmosSelected()
    {//draw spawn zone in inspector
        Gizmos.DrawWireSphere(transform.position, 0.5f);
    }
}
