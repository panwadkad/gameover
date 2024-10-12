using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PleyerStats : MonoBehaviour
{
    public float maxHealth;
    public float health;
    private Animator animator;
    private bool canTakeDamage = true;
    private bool isDead;
    public GameManagerScript gameManager;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInParent<Animator>();
        health = maxHealth;
        
        
    }

     void Update()
    {
        if (health <= 0 && !isDead)
        {
            isDead =true;
            gameManager.gameOver();
            Debug.Log("dead");
            //GameOver();
        }
    }
    void GameOver()
    {
        
    }

    public void TakeDamage(float damage)
    {
        if (!canTakeDamage) { return; }

        health -= damage;
        animator.SetBool("Damage" , true);
        Debug.Log("Player health" + health);
        if (health <= 0 )
        {
            GetComponentInParent<GatherInput>().OnDisableControl();
            Debug.Log("Player is dead");
        }
        StartCoroutine(DamagePrevention());
    }

    private IEnumerator DamagePrevention()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(0.15f);

        
        if(health > 0)
        {
            canTakeDamage = true;
            animator.SetBool("Damage" , false);
        }
        else{
            animator.SetBool("dead" , true);
        }
    }
}
