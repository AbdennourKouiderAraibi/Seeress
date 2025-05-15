using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    [SerializeField] private GameObject[] enemyReference;
    [SerializeField] private Transform pointA, pointB;

    private GameObject spawnedEnemy;
    private int randomIndex;
    private int randomSide;

    private void Start() {
        StartCoroutine(SpawnMonsters());
    }

    IEnumerator SpawnMonsters() {
        while (true) {
            yield return new WaitForSeconds(Random.Range(1, 5));

            randomIndex = Random.Range(0, enemyReference.Length);
            randomSide = Random.Range(0, 2);

            spawnedEnemy = Instantiate(enemyReference[randomIndex]);

            if (randomSide == 0) {
                spawnedEnemy.transform.position = pointA.position;
                spawnedEnemy.GetComponent<Enemy>().moveSpeed = Random.Range(4, 10);
            }
            else {
                spawnedEnemy.transform.position = pointB.position;
                spawnedEnemy.GetComponent<Enemy>().moveSpeed = -Random.Range(4, 10);
                spawnedEnemy.transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }
    }
}
