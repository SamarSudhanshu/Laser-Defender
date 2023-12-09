using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    [SerializeField] float transitionDelay = 1.0f;

    public void LoadGame() {
        SceneManager.LoadScene("Game");
    }

    public void LoadMenu() {
        SceneManager.LoadScene("Main Menu");
    }

    public void LoadGameOver() {
        StartCoroutine(LoadAndWait("Game Over", transitionDelay));
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private IEnumerator LoadAndWait(string sceneName, float delay) {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Game Over");
    }
}
