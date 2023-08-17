using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour
{
    public void Change(int _sceneIndex)
    {
        SceneManager.LoadScene( _sceneIndex );
    }

    public void SelectedLanguage(string _language)
    {
        StaticData.language = _language;
    }
}
