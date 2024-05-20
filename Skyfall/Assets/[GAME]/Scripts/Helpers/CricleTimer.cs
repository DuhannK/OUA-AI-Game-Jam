using UnityEngine;
using UnityEngine.UI;

public class CircularTimer : MonoBehaviour
{
    public Image timerImage; // Daire �ekilli timer referans�
    public float duration = 10f; // Timer'�n tamamen dolmas� i�in ge�en s�re
    public float decreaseSpeed = 4f; // Timer'�n azalma h�z� (y�ksek de�er = h�zl� azalma)
    public float increaseSpeed = 1f; // Timer'�n artma h�z� (d���k de�er = yava� artma)

    private bool isSpacePressed = false; // Space tu�unun bas�l� olup olmad���n� kontrol eder
    private float currentValue; // Mevcut timer de�eri

    void Start()
    {
        if (timerImage == null)
        {
            timerImage = GetComponent<Image>();
        }

        // Timer'�n ba�lang��ta tamamen dolu olmas�n� sa�la
        currentValue = duration;
        timerImage.fillAmount = 1f;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Time.timeScale = 0.2f;
            decreaseSpeed = 15f;
            isSpacePressed = true;
        }
        else
        {
            Time.timeScale = 1;
            isSpacePressed = false;
        }

        if (isSpacePressed)
        {
            currentValue -= Time.deltaTime * decreaseSpeed;
            if (currentValue <= 0)
            {
                currentValue = 0;
                Time.timeScale = 1;
            }
        }
        else
        {
            currentValue += Time.deltaTime * increaseSpeed;
            if (currentValue >= duration)
            {
                currentValue = duration;
            }
        }

        // Fill amount de�erini g�ncelle
        timerImage.fillAmount = currentValue / duration;
    }
}
