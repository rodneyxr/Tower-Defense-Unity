using UnityEngine;
using System.Collections;

public class SFX : MonoBehaviour {

    public static SFX sfx;

    private static AudioSource audioSource;

    public AudioClip laserShot; // when towers shoot
    public AudioClip levelUp;
    public AudioClip purchase;
    public AudioClip drill;
    public AudioClip gameOver;
    public AudioClip error;

    void Start() {
        sfx = this;
        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(AudioClip clip) {
        audioSource.PlayOneShot(clip);
    }

}
