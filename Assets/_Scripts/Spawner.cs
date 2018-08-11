using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour {


    [SerializeField] List<Transform> spawnPoints;
    [SerializeField] List<Transform> enemies;
    Transform enemyToSpawn;
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
            //TODO: Do this in waves, perhaps increasing with difficulty
            Spawn(6);
        }
    }

    public void Spawn(int toSpawn) {
        //TODO we might want to add a delay between spawning for later
        for (int i = 0; i < toSpawn; i++) {
            int randomSpawn = GetRandomSpawnPoint();
            int randomEnemy = GetRandomEnemy();
            Instantiate(enemies[randomEnemy], spawnPoints[randomSpawn].position, Quaternion.identity);
        }
    }

    private int GetRandomSpawnPoint() {
        int index = UnityEngine.Random.Range(0, spawnPoints.Count);
        return index;
    }

    private int GetRandomEnemy() {
        int index = UnityEngine.Random.Range(0, enemies.Count);
        return index;
    }
}
