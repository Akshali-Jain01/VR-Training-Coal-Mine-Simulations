using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerOnSecondScreen : MonoBehaviour
{
    public AudioClip[] hindiClips;
    public AudioClip[] englishClips;

    public AudioSource source;
    private void Start()
    {
        PlayAudio(0);
    }
    public void PlayAudio(int _index)
    {
        source.Stop();
        if (StaticData.language == "English")
        {
            source.clip = englishClips[_index];
        }
        else
        {
            source.clip = hindiClips[_index];
        }
        source.Play();
    }
}
