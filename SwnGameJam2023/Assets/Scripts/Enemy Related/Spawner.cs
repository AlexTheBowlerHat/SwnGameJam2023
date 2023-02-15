using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public float spawnInterval;
    public float distanceFromSpawner;
    public GameObject enemyPrefab;
    [SerializeField] float timeSinceLastSpawn = 0;

     Quaternion calculateRotationToPlayer(Transform targetTransform){
        // Calculates the Vector 2 distance between the target and player
        Vector3 dir = (targetTransform.position) - (transform.position);
        // Turns this Vector 2 into an angle
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        // Turns this angle into a rotation value
        return Quaternion.AngleAxis(angle, Vector3.forward);
    }

    public void spawnEnemy(GameObject enemy){
        //Set enemy position
        Vector3 dir = new Vector3(Random.value - 0.5f, Random.value - 0.5f, 0);
        Vector3 posititonOffset = Vector3.Normalize(dir) * distanceFromSpawner;
        Vector3 position = transform.position + posititonOffset;

        //Set enemy rotation
        Quaternion rotation = calculateRotationToPlayer(transform);
        GameObject NewEnemy = Instantiate(enemy, position, rotation, transform);
        
    }
    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn > spawnInterval){
            spawnEnemy(enemyPrefab);
            timeSinceLastSpawn = 0f;
        }
    }
}