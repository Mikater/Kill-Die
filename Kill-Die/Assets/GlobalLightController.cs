using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GlobalLightController : MonoBehaviour
{
    public float dayDuration = 10.0f; // Тривалість дня в секундах
    public Light2D globalLight; // Посилання на об'єкт глобального світла 2D

    private float currentTime = 0.0f;
    private bool isDay = true;

    void Update()
    {
        // Збільшуємо час
        currentTime += Time.deltaTime;

        // Перевіряємо, чи настав новий день
        if (currentTime >= dayDuration)
        {
            currentTime = 0.0f;
            isDay = !isDay;
        }

        // Встановлюємо інтенсивність світла відповідно до часу дня
        float intensity = Mathf.Clamp01(currentTime / (dayDuration / 2.0f));
        globalLight.intensity = isDay ? intensity : 1.0f - intensity;

        // Швидкість проходження дня (можна змінювати за допомогою клавіш у вигляді прикладу)
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            dayDuration -= 1.0f;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            dayDuration += 1.0f;
        }
    }
}
