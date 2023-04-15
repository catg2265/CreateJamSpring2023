using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingNoteInstance : MonoBehaviour
{
    [SerializeField]
    private GameObject[] noteCircles;

    private int _beatOffset = 1;

    private float _speed = 3;
    // Start is called before the first frame update

    private void Start()
    {
        BPMManager.BeatTimerEvent.AddListener(OnBeat);
    }

    void OnBeat(GameObject o)
    {
        _beatOffset -= 1;
        if(_beatOffset <= -2)
            Destroy(gameObject);
    }

    public void enableNotes(BeatInput note)
    {
        /*
         * Child Indexes:
         * 0 - Left
         * 1 - Up
         * 2 - Down
         * 3 - Right
        */
        switch (note)
        {
            case BeatInput.LEFT:
                noteCircles[0].SetActive(true);
            break;
            case BeatInput.UP:
                noteCircles[1].SetActive(true);
            break;
            case BeatInput.RIGHT:
                noteCircles[3].SetActive(true);
            break;
            case BeatInput.DOWN:
                noteCircles[2].SetActive(true);
            break;
            case BeatInput.UPLEFT:
                noteCircles[0].SetActive(true);
                noteCircles[1].SetActive(true);
            break;
            case BeatInput.UPRIGHT:
                noteCircles[1].SetActive(true);
                noteCircles[3].SetActive(true);
            break;
            case BeatInput.DOWNLEFT:
                noteCircles[0].SetActive(true);
                noteCircles[2].SetActive(true);
            break;
            case BeatInput.DOWNRIGHT:
                noteCircles[2].SetActive(true);
                noteCircles[3].SetActive(true);
            break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Vector3.up, Time.deltaTime * _speed);
    }
}
