using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    // Build Settings'te 1. sıradaki sahne (MainScene)
    public int gameSceneIndex = 1;

    public void StartGame()
    {
        Time.timeScale = 1f;

        Debug.Log("Loading scene with index: " + gameSceneIndex);
        SceneManager.LoadScene(gameSceneIndex);
    }
}

