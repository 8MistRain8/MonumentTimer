using UnityEngine;

public class FPSLimiter : MonoBehaviour
{
    void Start()
    {
        Application.targetFrameRate = 30; // Set FPS cap to 30
    }
}
