using UnityEngine;

public class TimeManager : MonoBehaviour
{
    // Зупиняє час
    public void PauseTime()
    {
        Time.timeScale = 0f;
    }

    // Відновлює час
    public void ResumeTime()
    {
        Time.timeScale = 1f;
    }
}
