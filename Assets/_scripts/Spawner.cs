using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform spawnSpots;
    public List<GameObject> spawnables;
    // Start is called before the first frame update
    void Start()
    {
        SpawnObjects();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnObjects()
    {
        int count = 0;
        foreach (Transform go in spawnSpots)
        {
            Instantiate(spawnables[count],go.position,go.rotation);
            count++;
        }
    }
}
