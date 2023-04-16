using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<Vector3> playerSpawnPoint = new();

    [SerializeField] private List<GameObject> _playerPrefabs = new();

    [SerializeField] private PlayerInputManager _playerInputManager;
    // Start is called before the first frame update
    void Awake()
    {
       DontDestroyOnLoad(gameObject);
      // if(SceneManager.GetActiveScene().buildIndex >= 2)
        //   _playerInputManager.DisableJoining();
       if (SceneManager.GetActiveScene().buildIndex >= 3)
           _playerInputManager.playerPrefab = _playerPrefabs[2];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
