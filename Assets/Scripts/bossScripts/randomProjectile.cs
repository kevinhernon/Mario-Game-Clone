using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    private int rand;
    public Sprite[] SpriteSheet;
    void Start()
    {   
        rand = Random.Range(0, SpriteSheet.Length);
        GetComponent<SpriteRenderer>().sprite = SpriteSheet[rand];
        BoxCollider2D boxCollider = gameObject.AddComponent<BoxCollider2D>();
        boxCollider.isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
