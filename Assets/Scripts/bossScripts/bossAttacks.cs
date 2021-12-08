using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossAttacks : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource audiosrc;
    public Transform Player;
    private float timedShots;
    public float startTimedShots;
    public GameObject projectile;
    public Transform firePosition;
    public HealthBar healthBar;
    private bool phase2 = false;
    private bool phase3 = false;
    private bool phase4 = false;
    public SpriteRenderer spriteRenderer;
    public int flashes;
    public float flashDuration;
    public Color flashColor;
    public Color normalColor;
    public Collider2D triggerCollider;
    public Collider2D triggerCollider2;
    public Transform deathPosition;
    public GameObject explosion;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        timedShots = startTimedShots;
    }
    private IEnumerator flash(){
        int i = 0;
        triggerCollider.enabled = false;
        triggerCollider2.enabled = false;
        while(i < flashes){
            spriteRenderer.color = flashColor;
            yield return new WaitForSeconds(flashDuration);
            spriteRenderer.color = normalColor;
            yield return new WaitForSeconds(flashDuration);
            i++;
        }
        triggerCollider.enabled = true;
        triggerCollider2.enabled = true;
    }
    private IEnumerator onDeath(){
            Destroy(gameObject);        
            GameObject r = Instantiate(explosion, deathPosition.position, deathPosition.transform.rotation);
            yield return new WaitForSeconds(3);
            Destroy(r);
    }
    // Update is called once per frame
    void Update()
    {
        if (healthBar.GetCurrentHealth() <= 15 && phase2 == false){
            startTimedShots = 1.5f;
            phase2 = true;
            StartCoroutine(flash());
            audiosrc.pitch = 1.15f;
        }
        if (healthBar.GetCurrentHealth() <= 10 && phase3 == false){
            startTimedShots = .8f;
            flashes = 5;
            StartCoroutine(flash());
            phase3 = true;
            audiosrc.pitch = 1.3f;
        }
        if (healthBar.GetCurrentHealth() <= 5 && phase4 == false){
            startTimedShots = .4f;
            flashes = 7;
            StartCoroutine(flash());
            phase4 = true;
            audiosrc.pitch = 1.5f;
        }
        if (healthBar.GetCurrentHealth() == 0){
            StartCoroutine(onDeath());
        }
        if(timedShots <= 0){
            GameObject r = Instantiate(projectile, firePosition.position, firePosition.transform.rotation);
            timedShots = startTimedShots;
        }
        else{
            timedShots -= Time.deltaTime;
        }
    }
}
