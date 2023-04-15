using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class BPMManager : MonoBehaviour
{
//constants / magic numbers
    [SerializeField]
    float BPM = 192;

    private const float SecondsInMinute = 60;

    //Instance of class.
    public static BPMManager instance;
    public static UnityEvent<GameObject> BeatTimerEvent;
    public static UnityEvent<GameObject, int> SpawnEnemyEvent;

    //Unity dislikes getters, so I made my own.
    public float GetBPM()
    {
        return 1 / (BPM / SecondsInMinute);
    }

    
    void Awake()
    {
        //Instance trick, allow only one instance.
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        //Register global time event.
        BeatTimerEvent ??= new UnityEvent<GameObject>();
        SpawnEnemyEvent ??= new UnityEvent<GameObject, int>();

        //Start the timer.
        StartCoroutine(GlobalTimer(GetBPM()));
        StartCoroutine(GlobalEnemySpawnTimer());
    }


    IEnumerator GlobalEnemySpawnTimer()
    {
        float startTime = Time.time;
        float nextTick = 0f;
        float interval = 2 / 3f;
        
        while (true)
        {
            if (Time.time - startTime + interval > nextTick)
            {
                nextTick += interval;
                SpawnEnemyEvent.Invoke(gameObject, 1);
            }
            yield return new WaitForEndOfFrame();
        }
    }

    /// <summary>
    /// Sends out a global event on every beat through the GlobalTimerEvent.
    /// </summary>
    /// <param name="inputBPM">beat length in real time (seconds)</param>
    /// <returns></returns>
    IEnumerator GlobalTimer(float inputBPM)
    {
        float startTime = Time.time;
        float nextTick = 0f;

        while (true)
        {
            if (Time.time - startTime + inputBPM > nextTick)
            {
                nextTick += inputBPM;
                BeatTimerEvent.Invoke(gameObject);
            }

            yield return new WaitForEndOfFrame();
        }
    }
}
