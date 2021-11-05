using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileFire : MonoBehaviour
{
    public float lifeSpan = 2f;
    private Collider2D collision;
    // Start is called before the first frame update
    private void Start(){
        Destroy(gameObject, lifeSpan);
    }
    private void OnTriggerEnter2D(Collider2D collision){
        Debug.Log(collision.name);
        if (collision.tag == "Enemy"){
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if (collision.gameObject.layer == 0){
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

    }
}
