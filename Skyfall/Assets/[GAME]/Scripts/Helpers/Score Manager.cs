using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText; // Text eleman�

    private int score = 0;

    void Update()
    {
        // Fare sol t�kland���nda
        if (Input.GetMouseButtonDown(0))
        {
            // Skoru art�r
            score++;
            // Skoru ekranda g�ncelle
            scoreText.text = "Score: " + score;
        }
    }
}
