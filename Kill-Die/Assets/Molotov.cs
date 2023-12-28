using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Molotov : MonoBehaviour
{
    public GameObject prefabToSpawn; // Префаб об'єкта, який з'явиться в новому місці
    public float spawnRadius = 5f; // Радіус для випадкового місця появи
   // public AudioClip touchSound; // Звук, який відтворюється при дотику

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Гравець доторкнувся до об'єкта
            //PlayTouchSound();

            // Створення нового об'єкта випадковим чином в радіусі
            SpawnNewObject();

            // Знищення поточного об'єкта
            Destroy(gameObject);

           
        }
    }

   /* private void PlayTouchSound()
    {
        if (touchSound != null)
        {
            //AudioSource.PlayClipAtPoint(touchSound, transform.position);
        }
    }*/

    private void SpawnNewObject()
    {
        if (prefabToSpawn != null)
        {
            // Генерація випадкового кута для нового об'єкта
            float randomAngle = Random.Range(0f, 360f);
            // Обчислення нової позиції в межах радіусу
            Vector2 spawnDirection = Quaternion.Euler(0f, 0f, randomAngle) * Vector2.right;
            Vector3 spawnPosition = transform.position + new Vector3(spawnDirection.x, spawnDirection.y, 0f) * spawnRadius;

            // Створення нового об'єкта
            Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
        }
    }
}
