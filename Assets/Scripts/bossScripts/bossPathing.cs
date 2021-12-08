using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossPathing : MonoBehaviour
{
    // Start is called before the first frame update
    public int movementDirection = 1;
    public int movingTo = 0;
    public Transform[] pathSequence;
    public void OnDrawGizmos()
    {
        if (pathSequence == null || pathSequence.Length <2)
            return;
        for(var i = 1; i < pathSequence.Length; i++)
        {
            Gizmos.DrawLine(pathSequence[0].position, pathSequence[i].position);
            Gizmos.DrawLine(pathSequence[i].position, pathSequence[pathSequence.Length-1].position);
        }
    }
    public IEnumerator<Transform> GetNextPathPoint(){
        if(pathSequence ==null || pathSequence.Length <2)
            yield break;
        while(true){
            yield return(pathSequence[movingTo]);
            if(pathSequence.Length == 1)
                continue;
            if(movingTo <= 0)
                movementDirection = 1;
            if(movingTo >= pathSequence.Length-1)
                movementDirection = -1;
            movingTo = movingTo + movementDirection;
        }
    }
}
