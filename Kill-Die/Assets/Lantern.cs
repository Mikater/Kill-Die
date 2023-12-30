using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Lantern : MonoBehaviour

{
    public Light2D lanternLight;
    public float activationTime = 30f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Припустимо, що об'єкт, який активує світло, має тег "Player".
        {
            StartCoroutine(ActivateLight());
        }
    }

    private IEnumerator ActivateLight()
    {
        lanternLight.enabled = true; // Увімкнути світло.

        yield return new WaitForSeconds(activationTime);

        lanternLight.enabled = false; // Вимкнути світло після закінчення часу активації.
    }
}