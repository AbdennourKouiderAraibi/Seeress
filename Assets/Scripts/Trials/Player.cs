using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] Vector2 speed = new Vector2(50, 50);

    private void Update() {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(speed.x * inputX, speed.y * inputY, 0);

        movement *= Time.deltaTime;

        transform.Translate(movement);
    }
}
