using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class bossFollowsPath : MonoBehaviour
{
    // Start is called before the first frame update
   
    public bossPathing MyPath;
    private IEnumerator<Transform> pointInPath;
    public float speed = 1;
    public float MaxDistanceToGoal = .1f;
    void Start()
    {
        pointInPath = MyPath.GetNextPathPoint();
        pointInPath.MoveNext();
        transform.position = pointInPath.Current.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, pointInPath.Current.position, Time.deltaTime * speed);
        var distanceSquared = (transform.position - pointInPath.Current.position).sqrMagnitude;
        
        if(distanceSquared< MaxDistanceToGoal*MaxDistanceToGoal)
            pointInPath.MoveNext();
    }
}
