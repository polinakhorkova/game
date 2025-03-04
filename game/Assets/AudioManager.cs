using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header ("--Audio Source --")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("--Audio Clipp--")]
    public AudioClip background;


    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }
}
