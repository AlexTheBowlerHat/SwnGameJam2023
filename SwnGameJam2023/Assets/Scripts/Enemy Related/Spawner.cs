using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyHolder;
    public float spawnInterval;
    public float distanceFromSpawner;
    public GameObject enemyPrefab;
    [SerializeField] float timeSinceLastSpawn = 0;
    public float maxSize;
    public float minScale;
    public float minHealth;
    public float maxSpeed;
    public float timeAlive;
    public float speedDecreasePerSecond;

    public void spawnEnemy(GameObject enemy){
        //Set enemy position
        Vector3 dir = new Vector3(Random.value - 0.5f, Random.value - 0.5f, 0);
        Vector3 posititonOffset = Vector3.Normalize(dir) * distanceFromSpawner;
        Vector3 position = transform.position + posititonOffset;

        //Set enemy rotation
        Quaternion rotation = transform.rotation;
        GameObject NewEnemy = Instantiate(enemy, position, rotation, enemyHolder.transform);


        //Set enemy size
        float size = Random.Range(1, maxSize);
        NewEnemy.transform.localScale = new Vector3(minScale * size, minScale * size, 1);
        NewEnemy.GetComponent<HealthScript>().healthPoints = minHealth * size;
        NewEnemy.GetComponent<DefaltEnemyMovement>().speed = maxSpeed/size;
        NewEnemy.GetComponent<DefaltEnemyMovement>().maxSpeed = maxSpeed/size;
        Color enemyColour = NewEnemy.GetComponentInChildren<SpriteRenderer>().color;
        enemyColour = new Color(r: (Random.Range(0f, 256f)) / 255, g: (Random.Range(0f, 256f)) / 255, b: (Random.Range(0f, 256f))/255, enemyColour.a);
        //Debug.Log(enemyColour);

    }
    // Update is called once per frame
    void Update()
    {
        timeAlive += Time.deltaTime;
        spawnInterval -= Time.deltaTime*speedDecreasePerSecond;
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn > spawnInterval){
            spawnEnemy(enemyPrefab);
            timeSinceLastSpawn = 0f;
        }
    }
}