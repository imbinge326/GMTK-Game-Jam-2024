using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("List of Sounds")]
    public List<AudioClip> soundEffects;

    public void EmitSound(int audioClipNum, Transform emitFromObject)
    {
        if (audioClipNum < 0 || audioClipNum >= soundEffects.Count)
        {
            Debug.LogWarning("Sound index out of range");
            return;
        }

        if (audioClipNum == 3 || audioClipNum == 5)
        {
            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.clip = soundEffects[audioClipNum];
            audioSource.Play();
        }
        else
        {
            GameObject soundObject = new GameObject("SoundObject");
            soundObject.transform.position = emitFromObject.position;

            AudioSource audioSource = soundObject.AddComponent<AudioSource>();
            audioSource.clip = soundEffects[audioClipNum];
            audioSource.Play();

            Destroy(soundObject, audioSource.clip.length);
        }
    }
}
