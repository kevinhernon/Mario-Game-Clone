using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileFire : MonoBehaviour
{
    public float lifeSpan = 2f;
    private Collider2D collision;
    public GameObject explosion;
    public GameObject explosion2;
    // Start is called before the first frame update
    private void Start(){
        int a = Random.Range(0,100);
        if (a % 2 == 0)
           explosion = explosion2;
        Destroy(gameObject, lifeSpan);

    }
    private void OnTriggerEnter2D(Collider2D collision){
        Debug.Log(collision.name);
        if (collision.tag == "Enemy"){
            float x = transform.position.x;
            float y = transform.position.y;
            explosion = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);
            Destroy(explosion, 1); 
        }
        if (collision.tag == "Block"){
            float x = transform.position.x;
            float y = transform.position.y;
            explosion = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);
            Destroy(explosion, 1); 
        }
        if (collision.gameObject.layer == 0){
            float x = transform.position.x;
            float y = transform.position.y;
            explosion = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(explosion, 1);
        }

    }
}
