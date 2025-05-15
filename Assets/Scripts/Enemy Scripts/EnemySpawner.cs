using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    [SerializeField] private GameObject[] enemyReference;
    [SerializeField] private Transform[] spawnPoints;

    private int randomIndex;
    private int spawnPointIndex;

    private void Start() {
        StartCoroutine(SpawnMonsters());
    }

    IEnumerator SpawnMonsters() {
        while (true) {
            yield return new WaitForSeconds(Random.Range(5, 11));

            randomIndex = Random.Range(0, enemyReference.Length);
            spawnPointIndex = Random.Range(0, spawnPoints.Length);

            Instantiate(enemyReference[randomIndex], spawnPoints[spawnPointIndex].position, Quaternion.identity);
        }
    }
}
