using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour {
    /*
    [SerializeField] private float delayBeforeStart = 5f; // seconds

    private void Start() {
        StartCoroutine(LoadMainGameAfterDelay());
    }

    private IEnumerator LoadMainGameAfterDelay() {
        yield return new WaitForSeconds(delayBeforeStart);
        SceneManager.LoadScene("MainGame"); // Make sure this matches your scene name
    }*/

    void Update() {
        if (Input.anyKeyDown) {
            SceneManager.LoadScene("MainGame");
        }
    }

}

