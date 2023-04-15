using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DDRPlayerController : MonoBehaviour
{
    [SerializeField] private PlayerInput input;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (input.actions["DDR"].WasPressedThisFrame())
        {
            Debug.Log(input.actions["DDR"].ReadValue<Vector2>());
        }
        
    }
}
