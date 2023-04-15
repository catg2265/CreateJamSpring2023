using System;
using UnityEngine;

public class ScrollingNoteInstance : MonoBehaviour
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
        if (other.CompareTag("EnemyShip") )
            return;
        
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<DDRPlayerController>().Kill();
        }

        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector2.down * speed;
    }
}
