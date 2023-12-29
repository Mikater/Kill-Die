using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MolotovV2 : MonoBehaviour
{
    public GameObject prefabToSpawn; // Префаб об'єкта, який з'явиться в новому місці

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Гравець доторкнувся до об'єкта

            // Створення нового об'єкта на місці об'єкта Molotov
            SpawnNewObject();

            // Знищення поточного об'єкта
            Destroy(gameObject);
        }
    }

    private void SpawnNewObject()
    {
        if (prefabToSpawn != null)
        {
            // Створення нового об'єкта на тому самому місці, де розташований об'єкт Molotov
            Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
        }
    }
}