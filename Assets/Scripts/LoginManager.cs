using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginManager : MonoBehaviour
{
    public InputField Name;  // Référence au champ d'entrée pour le nom d'utilisateur

    public void OnStartButtonPressed()
    {
        // Vérifie si le champ d'entrée pour le nom d'utilisateur est vide
        if (string.IsNullOrEmpty(Name.text))
        {
            // Affiche un message ou une alerte à l'utilisateur
            Debug.Log("Please enter a username before starting the game.");
        }
        else
        {
            // Charge la scène suivante
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
