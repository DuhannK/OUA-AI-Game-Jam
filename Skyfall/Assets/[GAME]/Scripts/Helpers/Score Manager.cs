using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // Oyundaki mevcut skoru g�steren Text UI eleman�
    public Text scoreText;
    public Text yourScore;

    // Y�ksek skoru g�steren Text UI eleman�
    public Text highScoreText;

    // Mevcut skor de�i�keni
    private int score = 0;

    // Y�ksek skor de�i�keni
    private int highScore = 0;

    private void Start()
    {
        // Oyunun ba�lad���nda PlayerPrefs'ten y�ksek skoru al ve ekranda g�ster
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "High Score: " + highScore;
    }

    private void OnEnable()
    {
        // MeteorManager'dan MeteorDestroy eventini dinle
        MeteorManager.OnMeteorDestroy.AddListener(UpdateScore);
        GameManager.OnLevelFail += UpdateYourScore;
    }

    private void OnDisable()
    {
        MeteorManager.OnMeteorDestroy.RemoveListener(UpdateScore);
        GameManager.OnLevelFail -= UpdateYourScore;
    }

    private void UpdateScore()
    {
        // Meteor yok edildi�inde skoru art�r
        score++;
        scoreText.text = "Score: " + score;

        // Y�ksek skoru g�ncelle ve kaydet
        if (score > highScore)
        {
            highScore = score;
            highScoreText.text = "High Score: " + highScore;
            PlayerPrefs.SetInt("HighScore", highScore); // Y�ksek skoru kaydet
        }
    }

    private void UpdateYourScore()
    {
        yourScore.text = "Your Score: " + score;
    }
}
