using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SendTo2ndLevel : MonoBehaviour
{
    private Collider2D collision;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == ("Player")){
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene("Level 2");
        }
    }
}