using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public InputField PutName;  // R�f�rence au champ d'entr�e pour le nom d'utilisateur
    public Text AlertText;      // R�f�rence au champ de texte pour afficher les alertes

    public void OnStartButtonPressed()
    {
        // V�rifie si le champ d'entr�e pour le nom d'utilisateur est vide
        if (string.IsNullOrEmpty(PutName.text))
        {
            // Affiche un message ou une alerte � l'utilisateur
            AlertText.text = "Please enter a username...";
        }
        else
        {
            // Efface le message d'alerte (si pr�sent)
            AlertText.text = "";

            // Charge la sc�ne suivante
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
