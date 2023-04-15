using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerInput input;

    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private SpriteRenderer _spriteRenderer;
    
    [SerializeField] private List<Sprite> _playersprites = new List<Sprite>();

    public int playerID = 0;

    [SerializeField] private float speed = 5f;

    private float horizontal;

    public bool activateSpriteSelec = false;


    public LayerMask LayerMask;

    private bool touchGround = false;
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        if (activateSpriteSelec)
        {
            GameObject[] goArr = GameObject.FindGameObjectsWithTag("Player");
            _spriteRenderer.sprite = _playersprites[goArr.Length];
            playerID = goArr.Length;
        }
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = input.actions["Move"].ReadValue<Vector2>().x;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y); 
    }
}
