using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBallScript : MonoBehaviour
{
    //[SerializeField]
    //private GameObject[] noteCircles;
    public float speed;
    
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") )
            return;
        
        if (other.CompareTag("EnemyShip"))
        {
            other.GetComponent<EnemyShipScript>().OnDamage();
        }
        
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector2.up * speed;
    }
}
