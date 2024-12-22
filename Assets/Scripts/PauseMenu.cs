using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public Button pauseButton; // Assign your PauseButton here in the Inspector

    // Start is called before the first frame update
    void Start()
    {
        // Add a listener to the pause button to trigger the TogglePause method
        pauseButton.onClick.AddListener(TogglePause);

        // Ensure the pause menu is initially hidden
        pauseMenuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    void TogglePause()
    {
        if (GameIsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

    void OnDestroy()
    {
        // Remove the listener when the object is destroyed to avoid potential memory leaks
        pauseButton.onClick.RemoveListener(TogglePause);
    }
    public void Back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
