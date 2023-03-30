using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSoundManager : MonoBehaviour
{
    public void PlaySound()
    {
        GetComponent<AudioSource>().Play();
    }
}
