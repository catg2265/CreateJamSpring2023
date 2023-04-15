using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using Object = UnityEngine.Object;

[Serializable]
public class Beat
{
    public BeatInput hitNote;
    public int hitBeat;
}

public class MiniGameManager : MonoBehaviour
{
    public List<Beat> beats = new();
    public Object NotePrefab;
    
    public AudioSource song;

    private List<int> _noteBuffer;
    private int _songBeatIndex;
    private int _currBeat;

    // Start is called before the first frame update
    void Start()
    {
        BPMManager.BeatTimerEvent.AddListener(NewBeat);
        _noteBuffer = beats.Select(b => b.hitBeat).ToList();
    }

    public void HitBeat(DDRPlayerController player, BeatInput input)
    {
        if(beats[0].hitNote == input)
            player.pointCount += CalculateScore();
        beats.RemoveAt(0);
    }

    private int CalculateScore()
    {
        int beatDelta = Math.Abs(beats[0].hitBeat - _currBeat);

        if (beatDelta == 0)
            return 10;
        if (beatDelta < 2)
            return 5;
        if (beatDelta < 5)
            return 2;
        return 0;
    }
    
    private void NewBeat(GameObject o)
    {
        _currBeat += 1;
        if (_noteBuffer.Remove(_currBeat + 1))
        {
            Object newObject = Instantiate(NotePrefab);
            newObject.GameObject().transform.position -= new Vector3(0,3, 0);
            newObject.GetComponent<ScrollingNoteInstance>().enableNotes(beats.Find(b => b.hitBeat == _currBeat+1).hitNote);
        }
    }
}
