using UnityEngine;

public class Laser : MonoBehaviour
{
    public float disableAfterSeconds = 3f;
    public float enableAfterSeconds = 1f;

    void OnEnable()
    {
        Invoke(nameof(DisableLaser), disableAfterSeconds);
    }

    void OnDisable()
    {
        CancelInvoke();
        Invoke(nameof(EnableLaser), enableAfterSeconds);
    }

    private void DisableLaser()
    {
        gameObject.SetActive(false);
    }

    private void EnableLaser()
    {
        gameObject.SetActive(true);
    }
}
