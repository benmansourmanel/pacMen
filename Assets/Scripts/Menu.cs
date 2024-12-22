using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    private float originalTimeScale;
    public Pacman pacman;
    public AudioSource optionAudioSource;


    private void Start()
    {
        originalTimeScale = Time.timeScale;
    }
    public void StartGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void StartMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void PauseGame()
    {
        Time.timeScale = 0; 
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void ExitGame()
    {
        Debug.Log("Exit button clicked."); 
        Application.Quit();
    }

    public GameObject closePanel;

    public void ClosePanel()
    {
        closePanel.SetActive(false);
    }

    public GameObject openPanel;

    public void OpenPanel()
    {
        openPanel.SetActive(true);
    }
    public void ToggleAudio()
    {
        // Toggle the audio in the Pacman script
        pacman.ToggleAudio();

        // Toggle additional audio sources in the option panel
        optionAudioSource.mute = !optionAudioSource.mute;
    
    }



}
