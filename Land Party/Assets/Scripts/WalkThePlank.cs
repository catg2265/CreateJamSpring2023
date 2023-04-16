using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;
using Debug = UnityEngine.Debug;

public class WalkThePlank : MonoBehaviour
{
    private GameManager gm;
    
    public float minTime = 1f;
    public float maxTime = 5f;
    private int _plankWalkerPostion;
    private bool plankWalkerDead;
    public int MiniGameTime = 60;
    private bool time = true;

    [SerializeField] private Transform plankWalker;
    private float timer;
    private float currentTime;
    private bool isTimerRunning = false;
    private Stopwatch _stopwatch;
    private int playerPoint;
    private int playerID = 0;

    [SerializeField] private PlayerInput _playerInput;


    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
        GameObject[] goArr = GameObject.FindGameObjectsWithTag("Player");
        playerID = goArr.Length-1;
        plankWalkerDead = false;
        _stopwatch = new Stopwatch();
        playerPoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (time)
        {
            if (_stopwatch.ElapsedMilliseconds / 1000f > 1) ;
            {
                _stopwatch.Stop();
                plankWalkerDead = false;
                _plankWalkerPostion = 0;
                _stopwatch.Reset();
                Debug.Log(_stopwatch);
            }
            if (plankWalkerDead == false)
            {
                if (!isTimerRunning)
                {
                    timer = Random.Range(minTime, maxTime);
                    currentTime = Time.time;
                    isTimerRunning = true;
                }

                if (Time.time - currentTime > timer)
                {
                    _plankWalkerPostion = Random.Range(0, 3);
                    isTimerRunning = false;
                }

                if (_plankWalkerPostion == 0 && _playerInput.actions["DDR"].ReadValue<Vector2>().x != 0)
                {
                    playerPoint++;
                    _stopwatch.Start();
                    plankWalkerDead = true;
                }
                else if (_plankWalkerPostion == 1 && _playerInput.actions["DDR"].ReadValue<Vector2>().y > 0)
                {
                    playerPoint++;
                    _stopwatch.Start();
                    plankWalkerDead = true;
                }
                else if (_plankWalkerPostion == 2 && _playerInput.actions["DDR"].ReadValue<Vector2>().y < 0)
                {
                    playerPoint++;
                    _stopwatch.Start();
                    plankWalkerDead = true;
                }
            }

        }

        StartCoroutine(GameTimer());
    }

    IEnumerator GameTimer()
    {
        yield return new WaitForSeconds(MiniGameTime);
        time = false;
        gm.playersPartialScore[playerID] = playerPoint;
    }
}
