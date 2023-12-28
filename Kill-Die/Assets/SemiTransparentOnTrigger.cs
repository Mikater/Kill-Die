using UnityEngine;

public class SemiTransparentOnTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Перевіряємо, чи об'єкт, який торкнувся тригера, має тег "Player"
        if (other.CompareTag("Player"))
        {
            // Змінюємо прозорість об'єкта
            ChangeTransparency(0.5f); // Встановіть відповідне значення прозорості (від 0.0 до 1.0)
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Перевіряємо, чи об'єкт, який вийшов з тригера, має тег "Player"
        if (other.CompareTag("Player"))
        {
            // Змінюємо прозорість об'єкта назад до початкового значення
            ChangeTransparency(1.0f);
        }
    }

    private void ChangeTransparency(float transparency)
    {
        // Отримуємо компонент SpriteRenderer (або інший відповідний компонент)
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        // Перевіряємо, чи отримали компонент
        if (spriteRenderer != null)
        {
            // Встановлюємо нове значення прозорості
            Color newColor = spriteRenderer.color;
            newColor.a = transparency;
            spriteRenderer.color = newColor;
        }
        else
        {
            // Якщо об'єкт не має компонента SpriteRenderer, можна використовувати інші методи для зміни прозорості.
            // Наприклад, якщо у вас є компонент MeshRenderer, використайте код аналогічно до SpriteRenderer.
            // Або ви можете використовувати Material з методом SetColor для зміни прозорості.
        }
    }
}
