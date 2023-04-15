using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class Beat
{
    public BeatInput hitNote;
    public int hitBeat;
}

public class MiniGameManager : MonoBehaviour
{
    public List<Beat> beats = new();
    public AudioClip song;
    public NoteSpawner[] noteSpawners;
    
    private List<int> _noteBuffer;
    private AudioSource audioSource;
    private int _songBeatIndex;
    private int _currBeat;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = song;
        audioSource.Play();
    }
}
