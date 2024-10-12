using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public float damage = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerStats")) {
            Debug.Log("Player hit a spike");
            collision.GetComponent<PleyerStats>().TakeDamage(damage);
        }
    }

}
