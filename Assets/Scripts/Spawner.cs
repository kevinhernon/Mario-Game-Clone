using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawnee;
    public Transform SpawnPostion;
    public float delay;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawner", delay, delay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawner(){
        GameObject r = Instantiate(spawnee, SpawnPostion.position, SpawnPostion.transform.rotation);

    }
    
}
