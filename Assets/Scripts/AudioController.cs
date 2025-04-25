using UnityEngine;

public class AudioController : MonoBehaviour
{

    public AudioClip menu;
    public AudioClip floresta;
    public AudioClip caverna;
    public AudioClip batalha;
    public AudioClip Lanca;
    public AudioClip fogo;

    private AudioSource audioSource;

    public static AudioController current;

    void Start()
    {
        current = this;

        audioSource = GetComponent<AudioSource>();
    }

    public void PlayMusic(AudioClip sound)
    {
        audioSource.PlayOneShot(sound);
    }
}
