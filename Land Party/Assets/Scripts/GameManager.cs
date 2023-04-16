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

    public int totalPeople;

    private int player1TotalScore = 0;
    private int player2TotalScore = 0;
    private int player3TotalScore = 0;
    private int player4TotalScore = 0;

    public List<float> playersPartialScore = new();
    // Start is called before the first frame update
    void Awake()
    {
       DontDestroyOnLoad(gameObject);
       playersPartialScore.Add(0f);
       playersPartialScore.Add(0f);
       playersPartialScore.Add(0f);
       playersPartialScore.Add(0f);
      // if(SceneManager.GetActiveScene().buildIndex >= 2)
        //   _playerInputManager.DisableJoining();
       if (SceneManager.GetActiveScene().buildIndex >= 3)
           _playerInputManager.playerPrefab = _playerPrefabs[2];
       totalPeople = _playerInputManager.playerCount;
    }

    // Update is called once per frame
    void Update()
    {
        if (totalPeople == 0)
        {
            //Find only active player or find longest survivof or smthng
            int currLargestIndex = 0;
            int numOfPlayers = playersPartialScore.Count;
            
            for (int i = 1; i < numOfPlayers; i++)
            {
                if (playersPartialScore[i] > playersPartialScore[currLargestIndex])
                    currLargestIndex = i;
            }
            //Do something for the winner

            for (int i = 0; i < numOfPlayers; i++)
            {
                playersPartialScore[i] = 0f;
            }
        }
    }
}
