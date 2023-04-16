
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;


public class NoteSpawner : MonoBehaviour
{
    public List<Object> noteObjects = new();
    public List<Transform> spawnPointsTRansforms = new();
    public Object NotePrefab;
    public float projectileSpeed;
    private List<Vector3> spawnPoints = new();
    private void Start()
    {
        BPMManager.SpawnEnemyEvent.AddListener(SpawnEnemies);
        foreach (var VARIABLE in spawnPointsTRansforms)
        {
            spawnPoints.Add(VARIABLE.position);
        }
    }

    void SpawnEnemies(GameObject o, int count)
    {
        for (int i = 0; i < count; i++)
        {
            int track = Random.Range(0, spawnPoints.Count);
            Object newObject = Instantiate(NotePrefab, transform, true);
            newObject.GameObject().transform.position = spawnPoints[track];
            newObject.GameObject().GetComponent<ScrollingNoteInstance>().speed = projectileSpeed;
        }
    }
}
