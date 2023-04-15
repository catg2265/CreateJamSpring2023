using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class BPMManager : MonoBehaviour
{
//constants / magic numbers
    [SerializeField]
    float BPM = 192;
    const float SecondsInMinute = 60;

    //Instance of class.
    public static BPMManager instance;
    public UnityEvent<GameObject> beatTimerEvent;

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
        beatTimerEvent ??= new UnityEvent<GameObject>();

        //Start the timer.
        StartCoroutine(GlobalTimer(GetBPM()));
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
            if ((Time.time - startTime) + (inputBPM) > nextTick)
            {
                nextTick += inputBPM;
                beatTimerEvent.Invoke(gameObject);
            }

            yield return new WaitForEndOfFrame();
        }
    }
}
