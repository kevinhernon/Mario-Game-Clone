using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private Transform player;
    private Vector2 target;
    private Collider2D collision;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector3(player.position.x, player.position.y);
        Destroy(gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position  += (player.position - transform.position).normalized * speed * Time.deltaTime;
    }
    void OnTriggerEnter2D(Collider2D collision){
        Debug.Log(collision.tag);
        if(collision.tag == ("Player")){
            DestroyProjectile();
        }
        if(collision.tag == ("Ground")){
            DestroyProjectile();
        }
        if(collision.tag == ("bullet")){
            DestroyProjectile();
        }
    }
    void DestroyProjectile(){
        Destroy(gameObject);
    }
}
