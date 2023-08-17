using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource source;
    public AudioClip[] eglishAudio;
    public AudioClip[] hindiAudio;

    public GameObject[] englisPopUps;
    public GameObject[] hindiPopUps;


    public static SoundManager instance;
    void Start()
    {
        instance = this;
        //PlayAudio(0);
        StartCoroutine(Play(0, 4));
    }
    public void PlayAudio( int _index )
    {
        if (StaticData.language == "English")
        {
            source.clip = eglishAudio[_index];
            ManagePopUps(englisPopUps, _index);
        }
        else
        {
            source.clip = hindiAudio[_index];
            ManagePopUps(hindiPopUps, _index);
        }
        source.Play( );
        //StartCoroutine( Play( 1, 4 ) );
    }
    IEnumerator Play( int _minIndex, int _maxIndex )
    {
        for ( int i = _minIndex; i < _maxIndex; i++ )
        {
            PlayAudio( i );
            yield return new WaitForSecondsRealtime( 9 );
        }
    }

    public void PlayMultipleAudio(int _minIndex,int _maxIndex)
    {
        StartCoroutine( Play( _minIndex, _maxIndex ) );
    }

    void ManagePopUps(GameObject[] popups, int _indexToActivatePopup)
    {
        for (int i = 0; i < popups.Length; i++)
        {
            popups[i].SetActive(false);
        }
        popups[_indexToActivatePopup].SetActive(true);
    }
}

