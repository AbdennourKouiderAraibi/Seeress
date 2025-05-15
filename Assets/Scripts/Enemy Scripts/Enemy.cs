using UnityEngine;

public class Enemy : MonoBehaviour {
    public float moveSpeed = 5f;
    public float detectionRange = 1f;

    private Rigidbody2D myBody;
    private bool isPlayerDetected = false;
    private Transform player;

    private void Awake() {
        myBody = GetComponent<Rigidbody2D>();
    }

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void FixedUpdate() {
        if (player == null) return;

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRange) {
            isPlayerDetected = true;
        }

        if (isPlayerDetected) {
            float direction = Mathf.Sign(player.position.x - transform.position.x);
            myBody.linearVelocity = new Vector2(direction * moveSpeed, myBody.linearVelocity.y);
        }
        else {
            myBody.linearVelocity = new Vector2(0f, myBody.linearVelocity.y);
        }

        myBody.linearVelocity = new Vector2(moveSpeed, myBody.linearVelocity.y);
    }
}
