using UnityEngine;
using TMPro;

public class TimerUI : MonoBehaviour
{
    public TextMeshProUGUI timer20MinText;
    public TextMeshProUGUI timer60MinText;
    public AudioSource sound20Min;
    public AudioSource sound60Min;

    [Range(0f, 1f)] public float volume20Min = 1f;
    [Range(0f, 1f)] public float volume60Min = 1f;

    private float timer20Min = 1200f; // 20 minutes
    private float timer60Min = 3600f; // 60 minutes

    void Update()
    {
        // Adjust Volume with Arrow Keys
        if (Input.GetKey(KeyCode.UpArrow))
        {
            volume20Min = Mathf.Clamp(volume20Min + 0.01f, 0f, 1f);
            volume60Min = Mathf.Clamp(volume60Min + 0.01f, 0f, 1f);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            volume20Min = Mathf.Clamp(volume20Min - 0.01f, 0f, 1f);
            volume60Min = Mathf.Clamp(volume60Min - 0.01f, 0f, 1f);
        }

        // Apply volume changes
        sound20Min.volume = volume20Min;
        sound60Min.volume = volume60Min;

        // Update timers
        timer20Min -= Time.deltaTime;
        timer60Min -= Time.deltaTime;

        // Update UI
        timer20MinText.text = "20 Min Timer: " + FormatTime(timer20Min);
        timer60MinText.text = "60 Min Timer: " + FormatTime(timer60Min);

        // Play sounds when timers reach 0
        if (timer20Min <= 0)
        {
            sound20Min.Play();
            timer20Min = 1200f; // Reset timer
        }

        if (timer60Min <= 0)
        {
            sound60Min.Play();
            timer60Min = 3600f; // Reset timer
        }

        // **RESET TIMERS WITH ENTER**
        if (Input.GetKeyDown(KeyCode.Return))
        {
            ResetTimers();
        }
    }

    void ResetTimers()
    {
        timer20Min = 1200f;
        timer60Min = 3600f;
        Debug.Log("Timers Reset!");
    }

    string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
