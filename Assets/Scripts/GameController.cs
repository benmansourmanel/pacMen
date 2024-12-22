using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public InputField PutName;  // Référence au champ d'entrée pour le nom d'utilisateur
    public Text AlertText;      // Référence au champ de texte pour afficher les alertes

    public void OnStartButtonPressed()
    {
        // Vérifie si le champ d'entrée pour le nom d'utilisateur est vide
        if (string.IsNullOrEmpty(PutName.text))
        {
            // Affiche un message ou une alerte à l'utilisateur
            AlertText.text = "Please enter a username...";
        }
        else
        {
            // Efface le message d'alerte (si présent)
            AlertText.text = "";

            // Charge la scène suivante
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
