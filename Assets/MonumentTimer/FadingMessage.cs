using UnityEngine;
using TMPro;

public class FadingMessage : MonoBehaviour
{
    public TextMeshProUGUI messageText; // The message that will fade out
    public float fadeDuration = 2f; // Duration of the fade in seconds
    private float fadeTimer = 0f; // Timer for fading out the message

    void Start()
    {
        // Display the message at the start of the game
        messageText.text = "ENTER to reset, UP & DOWN arrow to adjust volume. Enjoy (UwU)/";
        messageText.alpha = 1f; // Fully visible
    }

    void Update()
    {
        // Fade out the message over time
        if (fadeTimer < fadeDuration)
        {
            fadeTimer += Time.deltaTime; // Increment the timer
            float alpha = 1f - (fadeTimer / fadeDuration); // Gradually decrease alpha
            messageText.alpha = alpha; // Apply the alpha to the text
        }
        else
        {
            messageText.alpha = 0f; // Make sure the text is fully faded out after the duration
        }
    }
}
