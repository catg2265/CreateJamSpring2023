using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<Vector3> playerSpawnPoint = new();

    [SerializeField] private PlayerInputManager _playerInputManager;
    // Start is called before the first frame update
    void Awake()
    {
       DontDestroyOnLoad(gameObject);
       if(SceneManager.GetActiveScene().buildIndex >= 2)
           _playerInputManager.DisableJoining();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
