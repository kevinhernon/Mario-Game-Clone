using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerOrEnemyHealth : MonoBehaviour

{
    public AudioSource audiosrc;
    public int maxHealth;
    public int currentHealth;
    public HealthBar healthBar;
    public SpriteRenderer spriteRenderer;
    public int flashes;
    public float flashDuration;
    public Color flashColor;
    public Color normalColor;
    public Collider2D triggerCollider;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {   
          if (gameObject.tag == "Player"){
            if(currentHealth == 0){
                Scene scene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(scene.name);
            }
        }
        if (other.tag == "bullet" && gameObject.tag != "Player"){
            currentHealth -= 1;
            healthBar.SetCurrentHealth(currentHealth);
        }
        if (other.tag == "Boss" && gameObject.tag != "Boss"){
            StartCoroutine(flash());
            currentHealth -= 1; 
            healthBar.SetCurrentHealth(currentHealth);
        }
        Debug.Log(currentHealth);
    }
    private IEnumerator flash(){
        int i = 0;
        Debug.Log("flashing");
        triggerCollider.enabled = false;
        while(i < flashes){
            spriteRenderer.color = flashColor;
            yield return new WaitForSeconds(flashDuration);
            spriteRenderer.color = normalColor;
            yield return new WaitForSeconds(flashDuration);
            i++;
        }
        triggerCollider.enabled = true;
    }
}
