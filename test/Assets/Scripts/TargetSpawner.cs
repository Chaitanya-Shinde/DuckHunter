using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public GameObject objectPrefab;  

    public int numObjectsToSpawn = 999; 
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
        for (int i = 0; i < numObjectsToSpawn; i++)
        {
            spawnDelay = Random.Range(1, 5);
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

            yield return new WaitForSeconds(spawnDelay);
        }
    }


}
