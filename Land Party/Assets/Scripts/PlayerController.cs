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

    [SerializeField] private Transform GroundCheck;
    
    public int playerID = 0;

    [SerializeField] private float speed = 5f;

    [SerializeField] private float jumpPower = 15f;

    private float horizontal;

    public bool activateSpriteSelec = false;

    public LayerMask groundLayer;

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
        if (horizontal > 0)
        {
            _spriteRenderer.flipX = false;
        }
        else
        {
            _spriteRenderer.flipX = true;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y); 
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(GroundCheck.position, 0.2f, groundLayer);
    }
}
