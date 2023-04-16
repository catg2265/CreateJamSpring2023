using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

public class PlayerController : MonoBehaviour
{
    private GameManager gm;
    
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
    
    private float JumpTime;
    [SerializeField] private float StartJumpTime;
    private bool isJumping = false;

    private float score = 0f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
        GameObject[] goArr = GameObject.FindGameObjectsWithTag("Player");
        playerID = goArr.Length-1;
        if (activateSpriteSelec)
        {
            _spriteRenderer.sprite = _playersprites[playerID];
        }
        
        gameObject.transform.position = gm.playerSpawnPoint[playerID];
        
        /*if (playerID == 1)
        {
            input.SwitchCurrentActionMap("Player");
            input.SwitchCurrentControlScheme();
        }
        else if (playerID == 2)
        {
            input.SwitchCurrentActionMap("Player1");
            input.SwitchCurrentControlScheme();
        }
        else if (playerID == 3)
        {
            input.SwitchCurrentActionMap("Player2");
            input.SwitchCurrentControlScheme();
            
        }
        else if (playerID == 4)
        {
            input.SwitchCurrentActionMap("Player3");
            input.SwitchCurrentControlScheme();
        }
*/
    }

    // Update is called once per frame
    void Update()
    {
        score += Mathf.Lerp(0, 10, Time.deltaTime);
        
        if (horizontal > 0)
        {
            _spriteRenderer.flipX = false;
        }
        else
        {
            _spriteRenderer.flipX = true;
        }

        if (input.actions["Jump"].IsPressed() && IsGrounded())
        {
            isJumping = true;
            JumpTime = StartJumpTime;
            rb.velocity = Vector2.up * jumpPower;
            print( "My Player ID is: " + playerID.ToString());
        }
        if (input.actions["Jump"].IsPressed() && isJumping)
        {
            if (JumpTime > 0)
            {
                rb.velocity = Vector2.up * jumpPower;
                JumpTime -= Time.deltaTime;
                print( "My Player ID is: " + playerID.ToString());
            }
            else
            {
                isJumping = false;
            }
        }
        if (input.actions["Jump"].WasReleasedThisFrame())
        {
            isJumping = false;
        }

    }

    private void OnMove(InputValue VALUE)
    {
        Vector2 movementVector = VALUE.Get<Vector2>();
        horizontal = Mathf.RoundToInt(movementVector.x);
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
