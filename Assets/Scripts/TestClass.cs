using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class TestClass : MonoBehaviour {
     /*
      * The wanted length for the Raycast.
      */
     public float distance = 100f;
     void Update() {
         /*
          * Create the hit object.
          */
         RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.down, 0.6f);
         /*
          * Cast a Raycast.
          * If it hits something:
          */

         if(hit) {
             /*
              * Set the target location to the location of the hit.
              */
             Vector3 targetLocation = hit.point;
             /*
              * Modify the target location so that the object is being perfectly aligned with the ground (if it's flat).
              */
             targetLocation += new Vector3(0, transform.localScale.y / 2, 0);
             /*
              * Move the object to the target location.
              */
             transform.position = targetLocation;
         }
     }
    private void OnDrawGizmos(){
             Gizmos.color = Color.red;
             Gizmos.DrawLine(transform.position, transform.position + Vector3.down * 0.6f);
         }
 }
