using UnityEditor.Rendering;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private float stopAt = 2.75f;
    [SerializeField] private float startAt = 1.25f;
    [SerializeField] private bool loop;

    [SerializeField] private float speed;



    private void Awake()
    {
        audioSource.loop = loop;
        audioSource.pitch = speed;
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

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
        audioSource.pitch = speed;
    }

    public float getSpeed()
    {
        return speed;
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
