using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerInput input;

    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private SpriteRenderer _spriteRenderer;
    
    [SerializeField] private List<Sprite> _playersprites = new List<Sprite>();

    [SerializeField] private float speed = 5f;

    private float horizontal;

    public bool activateSpriteSelec = false;
    // Start is called before the first frame update
    void Start()
    {
        if (activateSpriteSelec)
        {
            GameObject[] goArr = GameObject.FindGameObjectsWithTag("Player");
            _spriteRenderer.sprite = _playersprites[goArr.Length];
        }
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = input.actions["Move"].ReadValue<Vector2>().x;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + new Vector2(horizontal, rb.velocity.y) * (speed*Time.fixedDeltaTime));
    }
}
