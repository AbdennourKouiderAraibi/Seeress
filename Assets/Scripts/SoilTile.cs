using UnityEngine;

public class SoilTile : MonoBehaviour {
    public GameObject plantedSeed;
    public bool IsOccupied => plantedSeed != null;

    public void PlantSeed(GameObject seedPrefab) {
        if (IsOccupied) return;

        Vector3 spawnPos = transform.position;
        plantedSeed = Instantiate(seedPrefab, spawnPos, Quaternion.identity);
        plantedSeed.GetComponent<Plant>().StartGrowing();
    }
    public void ClearSoil() {
        plantedSeed = null;
    }
}
