using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnpointController : MonoBehaviour
{
    [SerializeField] private List<Vector3> spawnPointList = new List<Vector3>();

    [SerializeField] private List<GameObject> prefabAirList = new List<GameObject>();

    [SerializeField] private List<GameObject> prefabWaterList = new List<GameObject>();

    [SerializeField] private float StandardStartTime = 3f;

    [SerializeField] private float StandardRespawnTime = 2f;

    private float startTimer;

    private float respawnTimer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        startTimer = StandardStartTime;
    }

    // Update is called once per frame
    void Update()
    {
        startTimer -= Time.deltaTime;
        if (startTimer <= 0)
        {
            if (StandardRespawnTime > 0.1f)
            {
                StandardRespawnTime -= Mathf.Lerp (0, 0.03f, Time.deltaTime);
            }
            else
            {
                StandardRespawnTime = 0.09f;
            }
            int pos = Random.Range(0, spawnPointList.Count);
            int airIndex = 0;
            //airIndex = Random.Range(0, prefabAirList.Count);
            //Only use if multiple different air objects
            int waterIndex = Random.Range(0, prefabWaterList.Count);
            respawnTimer -= Time.deltaTime;
            if (respawnTimer <= 0)
            {
                if (pos == 0)
                {
                    Instantiate(prefabAirList[airIndex], spawnPointList[pos], Quaternion.identity);
                }
                else if (pos == 1)
                {
                    Instantiate(prefabWaterList[waterIndex], spawnPointList[pos], Quaternion.identity);
                }
                respawnTimer = StandardRespawnTime;
            }
        }
    }
}
