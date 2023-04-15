using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;
using Debug = UnityEngine.Debug;

public class WalkThePlank : MonoBehaviour
{    
    public float minTime = 1f;
    public float maxTime = 5f;
    private int _plankWalkerPostion;
    private bool plankWalkerDead;
    private float timer;
    private float currentTime;
    private bool isTimerRunning = false;
    private Stopwatch _stopwatch;
    private int playerPoint;

    [SerializeField] private PlayerInput _playerInput;


    // Start is called before the first frame update
    void Start()
    {
        plankWalkerDead = false;
        _stopwatch = new Stopwatch();
    }

    // Update is called once per frame
    void Update()
    {
        if (_stopwatch.ElapsedMilliseconds / 1000f > 1);
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

            if (_plankWalkerPostion == 0 && _playerInput.actions["PokeThePlank"].WasPressedThisFrame())
            {
                playerPoint++;
                _stopwatch.Start();
                plankWalkerDead = true;
            }
            else if (_plankWalkerPostion == 1 && _playerInput.actions["PokeThePlank"].WasPressedThisFrame())
            {
                playerPoint++;
                _stopwatch.Start();
                plankWalkerDead = true;
            }
            else if (_plankWalkerPostion == 2 && _playerInput.actions["PokeThePlank"].WasPressedThisFrame())
            {
                playerPoint++;
                _stopwatch.Restart();
                plankWalkerDead = true;
            }
        }
    }
}
