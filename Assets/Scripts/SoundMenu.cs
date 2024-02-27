using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMenu : MonoBehaviour
{
    public AudioSource menuSound;
    public AudioClip sound;

    public void PlaySound()
    {
        menuSound.PlayOneShot(sound, 1.0f);
    }
}
