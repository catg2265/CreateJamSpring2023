using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleMove : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    [SerializeField] private Rigidbody2D rb;

    public float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = Vector2.left * speed;
        timer += Time.fixedDeltaTime;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            col.GetComponent<PlayerController>().Kill();
        }

        if (col.CompareTag("Wall") && timer > 1f)
        {
            Destroy(gameObject);
        }
    }
}
