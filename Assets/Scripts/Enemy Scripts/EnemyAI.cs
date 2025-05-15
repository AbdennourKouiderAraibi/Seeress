using UnityEngine;

public class EnemyAI : MonoBehaviour {
    public Transform[] patrolPoints;
    private int currentPointIndex = 0;

    public float moveSpeed = 2f;
    public float detectionRange = 5f;

    private Transform player;
    private bool chasingPlayer = false;

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update() {
        if (chasingPlayer) {
            ChasePlayer();
        }
        else {
            Patrol();
            DetectPlayer();
        }
    }

    void Patrol() {
        Transform targetPoint = patrolPoints[currentPointIndex];
        transform.position = Vector2.MoveTowards(transform.position, targetPoint.position, moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetPoint.position) < 0.1f) {
            currentPointIndex = (currentPointIndex + 1) % patrolPoints.Length;
        }
    }

    void DetectPlayer() {
        float distance = Vector2.Distance(transform.position, player.position);

        if (distance < detectionRange) {
            chasingPlayer = true;
        }
    }

    void ChasePlayer() {
        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, player.position) < 0.5f) {
            Debug.Log("Enemy is attacking player!");
        }
    }
}
