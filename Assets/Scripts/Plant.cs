using UnityEngine;

public class Plant : MonoBehaviour {
    public GameObject[] growthStages; // Assign in Inspector
    public float timeBetweenStages = 5f;

    private int currentStage = 0;
    private float timer;
    private bool isGrowing = false;

    public bool IsFullyGrown => currentStage >= growthStages.Length - 1;

    public void StartGrowing() {
        currentStage = 0;
        timer = timeBetweenStages;
        isGrowing = true;
        ShowStage(0);
    }

    void Update() {
        if (!isGrowing || IsFullyGrown) return;

        timer -= Time.deltaTime;
        if (timer <= 0f) {
            currentStage++;
            ShowStage(currentStage);
            timer = timeBetweenStages;
        }
    }

    void ShowStage(int index) {
        for (int i = 0; i < growthStages.Length; i++) {
            growthStages[i].SetActive(i == index);
        }
    }

    public void Harvest() {
        Destroy(gameObject);
    }
}

