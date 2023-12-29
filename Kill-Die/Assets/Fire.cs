using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public float delayInSeconds = 5f; // Час затримки перед знищенням

    void Start()
    {
        // Викликаємо метод DestroyObject через зазначений час
        Invoke("DestroyObject", delayInSeconds);
    }

    void DestroyObject()
    {
        // Знищення об'єкта
        Destroy(gameObject);
    }
}