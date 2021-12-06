using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MadKevin : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Player;
    private float timedShots;
    public float startTimedShots;
    public GameObject projectile;
    public Transform firePosition;
    public Transform firePosition2;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        timedShots = startTimedShots;
    }

    // Update is called once per frame
    void Update()
    {
        if(timedShots <= 0){
            GameObject r = Instantiate(projectile, firePosition.position, firePosition.transform.rotation);
            GameObject r2 = Instantiate(projectile, firePosition2.position, firePosition2.transform.rotation);
            timedShots = startTimedShots;
        }
        else{
            timedShots -= Time.deltaTime;
        }
    }
}
