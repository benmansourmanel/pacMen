using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{
    [SerializeField] Text CoinsText;
    [SerializeField] Text ScoreText;
    [SerializeField] Text EndText;
    [SerializeField] GameObject openPanel;

    Pacman pacman;

    void Start()
    {
        GameObject pacmanObject = GameObject.Find("Chomp_Mesh");
        if (pacmanObject != null)
        {
            pacman = pacmanObject.GetComponent<Pacman>();
        }
    }

    void Update()
    {
        if (pacman != null)
        {
            CoinsText.text = "Coins: " + pacman.coins.ToString() + "/300";
            ScoreText.text = "Score: " + pacman.score.ToString();
            if (pacman.hearts == 0)
            {
                EndText.color = Color.red;
                EndText.text = "Game Over!";
                openPanel.SetActive(true);
            }
            else if (pacman.coins == 300)
            {
                EndText.color = Color.green;
                EndText.text = "Congratulations!";
                pacman.GetComponent<SkinnedMeshRenderer>().enabled = false;
                openPanel.SetActive(true);
            }

        }
    }

}
