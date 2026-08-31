using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private float stopAt = 2.75f;
    [SerializeField] private float startAt = 1.25f;
    [SerializeField] private bool loop;

    private void Awake()
    {
        audioSource.loop = loop;
        audioSource.time = startAt;
    }
    private void Update()
    {
        if (audioSource.isPlaying && audioSource.time >= stopAt)
        {
            audioSource.Stop();
        }
    }

    public void Play()
    {
        audioSource.Stop();
        audioSource.time = startAt;
        audioSource.Play();
    }

    public void Stop()
    {
        audioSource.Stop();
    }

    public bool IsPlaying()
    {
        return audioSource.isPlaying;
    }
}
