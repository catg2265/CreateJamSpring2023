using System;
using UnityEngine;

public class ScrollingNoteInstance : MonoBehaviour
{
    //[SerializeField]
    //private GameObject[] noteCircles;
    public Vector3 targetPosition;
    public float speed;
    
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            other.gameObject.GetComponent<DDRPlayerController>().Kill();
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector2.down * speed;
    }
}
