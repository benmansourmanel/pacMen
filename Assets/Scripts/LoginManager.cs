using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginManager : MonoBehaviour
{
    public InputField Name;  // R�f�rence au champ d'entr�e pour le nom d'utilisateur

    public void OnStartButtonPressed()
    {
        // V�rifie si le champ d'entr�e pour le nom d'utilisateur est vide
        if (string.IsNullOrEmpty(Name.text))
        {
            // Affiche un message ou une alerte � l'utilisateur
            Debug.Log("Please enter a username before starting the game.");
        }
        else
        {
            // Charge la sc�ne suivante
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
