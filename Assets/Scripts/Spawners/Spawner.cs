using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //public variables

    //private variables



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnMob(GameObject mob)
    {//spawn a mob prefab into current spawners coordinates

        //spawn coordinates
        float xCoord = transform.position.x;
        float yCoord = transform.position.y - 0.5f;
        quaternion zCoord = transform.rotation;

        //spawn mob
        Instantiate(mob, new Vector3(xCoord, yCoord), zCoord);

    }

    private void OnDrawGizmosSelected()
    {//draw spawn zone in inspector
        Gizmos.DrawWireSphere(transform.position, 0.5f);
    }
}
