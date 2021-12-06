using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MadKevinProjectileFire : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource audioSrc;
    public static AudioClip explosionSound;
    public float speed;
    private Transform player;
    private Vector2 target;
    private Collider2D collision;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector3(player.position.x, player.position.y);
        explosionSound = Resources.Load<AudioClip>("explosion03");
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position  = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if(transform.position.x == target.x && transform.position.y == target.y){
            Destroy(gameObject, 5);
        }   
    }
    void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == ("Player")){
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
            DestroyProjectile();
        }
        if(collision.tag == ("Ground")){
            DestroyProjectile();
        }
        if(collision.tag == ("QuestionBlock")){
            DestroyProjectile();
        }
        if(collision.tag == ("Block")){
            DestroyProjectile();
        }
    }
    void DestroyProjectile(){
        Destroy(gameObject);
    }
}
