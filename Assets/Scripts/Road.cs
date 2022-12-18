using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class Road : MonoBehaviour
{
    [SerializeField] private List<GameObject> positions;
    [SerializeField] private List<GameObject> cars;
    [SerializeField] private GameObject elf;
    [SerializeField] private GameObject devil;
    [SerializeField] private float timeBetweenWaves;
    private List<GameObject> _road1 = new();
    private int _road1HasACar;
    private List<GameObject> _road2 = new();
    private int _road2HasACar;
    private List<GameObject> _road3 = new();
    private int _road3HasACar;

    private void Start()
    {
        StartCoroutine("WaveSpawningTimer");
    }

    IEnumerator WaveSpawningTimer()
    {
        yield return new WaitForSeconds(timeBetweenWaves);
        SpawnWave();
        StartCoroutine("WaveSpawningTimer");
    }
    private void SpawnWave()
    {
        int obsitcle1 = Random.Range(0, positions.Count +1);
        int obsitcle2 = Random.Range(0, positions.Count +1);
        GameObject spawnedObject1 = GetRandomObsticle();
        if (obsitcle1 == obsitcle2)
        {
            obsitcle2 = 0;
            
        }
        if (obsitcle1 != 0)
        {
            switch (obsitcle1)
            {
                case 1:
                    _road1.Add(spawnedObject1);
                    break;
                case 2:
                    _road2.Add(spawnedObject1);
                    break;
                case 3:
                    _road3.Add(spawnedObject1);
                    break;
            }
            Instantiate(spawnedObject1, positions[obsitcle1 -1].gameObject.transform);
        }
        
        GameObject spawnedObject2 = GetRandomObsticle();
        if (obsitcle2 != 0)
        {
            switch (obsitcle2)
            {
                case 1:
                    _road1.Add(spawnedObject2);
                    break;
                case 2:
                    _road2.Add(spawnedObject2);
                    break;
                case 3:
                    _road3.Add(spawnedObject2);
                    break;
            }
            Instantiate(spawnedObject2, positions[obsitcle2 -1].gameObject.transform);
        }
    }

    private GameObject GetRandomObsticle()
    {
        switch (Random.Range(1, 4))
        {
            case 1:
                return elf;
            case 2:
                return devil;
            case 3:
                return cars[Random.Range(0, cars.Count)];
        }

        return null;
    }
}