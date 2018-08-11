using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour {


    [SerializeField]  List<Transform> spawnPoints;
    [SerializeField]  List<Transform> enemies;

    static int spawnDelay = 2;
    Transform enemyToSpawn;
    static int enemiesAlive;
    static int wave = 1;
    static bool canSpawn = true;

    [SerializeField]static int enemiesToSpawn = 5;
	// Use this for initialization
	void Start () {
        PopulateSpawnPoints();
	}

    private void PopulateSpawnPoints() {
        int children = transform.childCount;
        for (int i = 0; i < children; i++) {
            spawnPoints.Add (transform.GetChild(i));
        }
    }

    private void Update() {
    if (Input.GetMouseButtonDown(1)) {
            Spawn(6);
    }
        if (canSpawn) {
            canSpawn = false;
            
            StartCoroutine("SpawnDelay");
        }
    }

    public void Spawn(int toSpawn) {

        for (int i = 0; i < toSpawn; i++) {
            int randomSpawn = GetRandomSpawnPoint();
            int randomEnemy = GetRandomEnemy();
            Instantiate(enemies[randomEnemy], spawnPoints[randomSpawn].position, Quaternion.identity);
            enemiesAlive++;
        }
    }

    private  int GetRandomSpawnPoint() {
        int index = UnityEngine.Random.Range(0, spawnPoints.Count);
        return index;
    }

    private  int GetRandomEnemy() {
        int index;
        Debug.Log(enemies.Count);
        if(wave < enemies.Count) {
            index = UnityEngine.Random.Range(0, wave);
        }
        else {
            index = UnityEngine.Random.Range(0, enemies.Count);
        }

            
        return index;
    }

    public static void UpdateKills() {
        enemiesAlive--;
        if (enemiesAlive <= 0) {
            enemiesAlive = 0; // TO be safe
            wave++;
            canSpawn = true;
        }
    }

    IEnumerator SpawnDelay() {
        yield return new WaitForSeconds(spawnDelay);
        Spawn(enemiesToSpawn + wave);
    }
}
