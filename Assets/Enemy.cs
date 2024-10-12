using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float helth;
    protected Rigidbody2D rb;
    protected Animator animator;

      private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        
    }

    public void TakeDamage(float damage){
        helth -= damage;
        //animator => Enemy hurt
        if(helth < 0){
          //animator => Enemy dead
          Destroy(gameObject);
        }
    }
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
