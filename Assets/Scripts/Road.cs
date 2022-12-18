
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    [SerializeField] private List<GameObject> positions;
    [SerializeField] private List<GameObject> cars;
    [SerializeField] private GameObject elf;
    [SerializeField] private GameObject devil;
    [SerializeField] private float timeBetweenWaves;
    private List<GameObject> _road1 = new();
    private List<GameObject> _road2 = new();
    private List<GameObject> _road3 = new();
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
        if (obsitcle1 != 0)
        {
            Instantiate(GetRandomObsticle(), positions[obsitcle1 -1].gameObject.transform);
        }

        if (obsitcle2 != 0)
        {
            Instantiate(GetRandomObsticle(), positions[obsitcle2 -1].gameObject.transform);
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
