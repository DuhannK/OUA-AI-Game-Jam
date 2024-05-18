using UnityEngine;
using UnityEngine.UI;

public class SliderTimer : MonoBehaviour
{
    public Slider deTimer; // Slider referans�
    public float duration = 10f; // Slider'�n tamamen dolmas� i�in ge�en s�re
    public float decreaseSpeed = 4f; // Slider'�n azalma h�z� (y�ksek de�er = h�zl� azalma)
    public float increaseSpeed = 1f; // Slider'�n artma h�z� (d���k de�er = yava� artma)

    private bool isSpacePressed = false; // Space tu�unun bas�l� olup olmad���n� kontrol eder

    void Start()
    {
        if (deTimer == null)
        {
            deTimer = GetComponent<Slider>();
        }

        // Slider'�n ba�lang��ta tamamen dolu olmas�n� sa�la
        deTimer.maxValue = duration;
        deTimer.value = duration;
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
            deTimer.value -= Time.deltaTime * decreaseSpeed;
            if (deTimer.value <= 0)
            {
                deTimer.value = 0;
                Time.timeScale = 1;
            }
        }
        else
        {
            deTimer.value += Time.deltaTime * increaseSpeed;
            if (deTimer.value >= duration)
            {
                deTimer.value = duration;
            }
        }
    }
}