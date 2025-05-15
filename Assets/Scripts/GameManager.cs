using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {
    public void StartGame() {
        SceneManager.LoadScene("Intro");
    }

    public void ExitGame() {
        Application.Quit(GetHashCode());
    }
}
