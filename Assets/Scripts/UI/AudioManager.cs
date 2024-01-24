using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]

    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("SFX Clip")]
    public AudioClip background;
    public AudioClip enemydeath;
    public AudioClip towerplacement;

    private void Start(){
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    // In order to add sound effect
    // AudioManager audioManager;
    // private void Awake()
    // {
    //     AudioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    // }
    // In order to play sound effect, use following syntax
    // audioManager.PlaySFX(audioManager.thesoundeffectyouwanttoplay); 
    // replace soundeffectyouwanttoplay with enemydeath or towerplacement
}
