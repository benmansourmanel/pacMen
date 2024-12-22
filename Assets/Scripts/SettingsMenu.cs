using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;  
    }
    /*public void OnBackButtonPressed()
    {
        // Retourne à la scène précédente dans la pile de chargement des scènes
        if (SceneManager.sceneCount > 1)
        {
            // Chargement de la scène précédente
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        else
        {
            Debug.LogWarning("No previous scene in the build settings or this is the first scene.");
        }
    }*/
}
