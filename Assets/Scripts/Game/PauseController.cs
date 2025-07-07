using UnityEngine;

public class PauseController : MonoBehaviour
{
    public static bool isGamePaused { get; private set; } = false;
    public static void SetPause(bool pause)
    {
        isGamePaused = pause;
    }
}
