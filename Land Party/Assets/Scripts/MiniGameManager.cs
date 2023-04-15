using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class Beat
{
    public bool[] hitNotes = { false, false, false, false };
    private bool[] _playerPressed = { false, false, false, false };
    public int hitBeat;
}

public class MiniGameManager : MonoBehaviour
{
    public List<Beat> beats = new();
    public AudioSource song;

    private int _songBeatIndex;
    private int _currBeat;

    
    // Start is called before the first frame update
    void Start()
    {
        BPMManager.instance.beatTimerEvent.AddListener(NewBeat);
    }


    private void NewBeat(GameObject o)
    {
        _currBeat += 1;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
