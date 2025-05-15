using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float minX = -8f;
    [SerializeField] private float maxX = 8f;
    [SerializeField] private float minY = -4f;
    [SerializeField] private float maxY = 4f;

    private Rigidbody2D rb;
    private Vector2 movement;

    // Crop data
    [SerializeField] private GameObject[] seedPrefabs;
    [SerializeField] private float interactRange = 1.5f;
    [SerializeField] private LayerMask soilLayer;
    [SerializeField] private LayerMask plantLayer;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (Input.GetMouseButtonDown(0)) {
            HandleInteractions();
        }

        if (Input.GetMouseButtonDown(1)) {
            Attack();
        }
    }

    private void FixedUpdate() {
        rb.linearVelocity = movement.normalized * moveSpeed;
    }

    // Handles attacking logic
    private void Attack() {
        Debug.Log("Attack!");
    }

    // Handles the player's different interactions
    private void HandleInteractions() {
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        RaycastHit2D plantHit = Physics2D.Raycast(worldPos, Vector2.zero, 0f, plantLayer);
        if (plantHit.collider != null) {
            Plant plant = plantHit.collider.GetComponentInParent<Plant>();
            if (plant != null && plant.IsFullyGrown) {
                SoilTile soil = FindFirstObjectByType<SoilTile>(); // You might want a better reference
                plant.Harvest();
                soil.ClearSoil();
                return;
            }
        }

        RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector2.zero, 0f, soilLayer);

        if (hit.collider != null) {
            SoilTile soil = hit.collider.GetComponent<SoilTile>();
            if (soil != null && !soil.IsOccupied) {
                int selectedSeedIndex = Random.Range(0, seedPrefabs.Length);
                soil.PlantSeed(seedPrefabs[selectedSeedIndex]);
            }
        }
    }
}
