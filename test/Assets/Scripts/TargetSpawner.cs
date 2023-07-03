using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject[] spawnPoints;  // Array of spawn point GameObjects
    public GameObject objectPrefab;  // The object prefab to be instantiated

    public int numObjectsToSpawn = 999;  // Number of objects to spawn
    public int spawnDelay =3;
    private GameObject spawnPoint;
    public GameObject BlueDuck;
    public GameObject BlackDuck;
    public GameObject RedDuck;
    void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    IEnumerator SpawnObjects()
    {
        // Iterate for the desired number of objects to spawn
        for (int i = 0; i < numObjectsToSpawn; i++)
        {
            spawnDelay = Random.Range(1, 5);
            // Get a random spawn point from the array
            int randomNum = Random.Range(0, spawnPoints.Length);
            spawnPoint = spawnPoints[randomNum];

            switch (randomNum)
            {
                case 0:
                    GameObject target1 = Instantiate(objectPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
                    GameObject spawnedBlueDuck = Instantiate(BlueDuck,spawnPoint.transform.position, spawnPoint.transform.rotation,target1.transform);
                    break;
                case 1:
                    GameObject target2 = Instantiate(objectPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
                    GameObject spawnedRedDuck = Instantiate(RedDuck, spawnPoint.transform.position, spawnPoint.transform.rotation, target2.transform);
                    break;
                case 2:
                    GameObject target3 = Instantiate(objectPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
                    GameObject spawnedBlackDuck = Instantiate(BlackDuck, spawnPoint.transform.position, spawnPoint.transform.rotation, target3.transform);
                    break;

            }
            // Instantiate the object at the spawn point's position and rotation
            
            
            // Optionally, you can do something with the spawned object here
            yield return new WaitForSeconds(spawnDelay);
        }
    }


}
