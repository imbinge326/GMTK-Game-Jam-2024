using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource audioSource;

    [Header("List of Sounds")]
    public List<AudioClip> soundEffects;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void EmitSound(int audioClipNum, Transform emitFromObject)
    {
        AudioClip clipToPlay = soundEffects[audioClipNum];
        audioSource.clip = clipToPlay;
        audioSource.transform.position = emitFromObject.position;
        audioSource.Play();
    }
}
