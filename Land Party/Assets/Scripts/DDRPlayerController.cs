using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DDRPlayerController : MonoBehaviour
{
    public int playerNumber;
    public int pointCount;
    public GameObject[] inputSpheres;
    public MiniGameManager miniGameManager;

    private bool _hasPressedThisBeat;
    [SerializeField] private PlayerInput input;

    // Start is called before the first frame update

    void Start()
    {
        Debug.Log(BPMManager.instance.GetBPM());
        BPMManager.BeatTimerEvent.AddListener(OnBeatUpdate);
    }

    void OnBeatUpdate(GameObject o)
    {
        _hasPressedThisBeat = false;
    }
    
    void Update()
    {
        if (!input.actions["DDR"].WasPressedThisFrame())
            return;
        
        Vector2 curr = input.actions["DDR"].ReadValue<Vector2>();
        if (_hasPressedThisBeat || curr is { x: 0f, y: 0 })
            return;
        _hasPressedThisBeat = true;

        switch (curr)
        {
            case {x:1,y:0}:
                miniGameManager.HitBeat(this,BeatInput.LEFT);
                return;
            case {x:-1,y:0}:
                miniGameManager.HitBeat(this,BeatInput.RIGHT);
                return;
            case {x:0,y:1}:
                miniGameManager.HitBeat(this,BeatInput.UP);
                return;
            case {x:0,y:-1}:
                miniGameManager.HitBeat(this,BeatInput.DOWN);
                return;
        }

        bool pressedRight = curr.x > 0;
        bool pressedUp = curr.y > 0;

        if (pressedRight && pressedUp)
            miniGameManager.HitBeat(this, BeatInput.UPRIGHT);
        else if (pressedUp)
            miniGameManager.HitBeat(this, BeatInput.UPLEFT);
        else if (pressedRight)
            miniGameManager.HitBeat(this, BeatInput.DOWNRIGHT);
        else
            miniGameManager.HitBeat(this, BeatInput.DOWNLEFT);
    }
}
