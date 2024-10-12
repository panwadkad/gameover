using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRedDog : Enemy
{
    public float speed = 1.0f;
    private int direction = -1;
    public Transform groundChecker;
    public Transform wallChecker;
    public LayerMask layerToCheck;

    private bool detectedGround;
    private bool detectedWall;
    public float radius;

    PlayerMoveControl playerMoveControl;


    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    private void FixedUpdate() 
    {
        flip();
        rb.velocity = new Vector2(direction*speed, rb.velocity.y);
    }
    
    private void flip(){
        detectedGround = Physics2D.OverlapCircle(
            groundChecker.position , radius,layerToCheck);
        detectedWall = Physics2D.OverlapCircle(
            wallChecker.position , radius,layerToCheck);

        if(detectedWall || !detectedGround) {
            direction *= -1;
            transform.localScale = new Vector3(-transform.localScale.x, 1, 1);
        }
    }

  
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundChecker.position, radius); 
        Gizmos.DrawWireSphere(wallChecker.position, radius);
    }
}
