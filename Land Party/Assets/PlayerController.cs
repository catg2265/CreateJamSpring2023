using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerInput input;

    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private List<Sprite> _playersprites = new List<Sprite>();

    public bool activateSpriteSelec = false;
    // Start is called before the first frame update
    void Start()
    {
        if (activateSpriteSelec)
        {
            GameObject[] goArr = GameObject.FindGameObjectsWithTag("Player");
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
