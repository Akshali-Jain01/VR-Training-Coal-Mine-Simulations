using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateLanguageSelection : MonoBehaviour
{
    public GameObject introPanel;
    public GameObject Help;
    public GameObject Okay;
   public void ActivateLanguageScreen()
    {
        StartCoroutine(ChangeScreen() );
    }

    IEnumerator ChangeScreen()
    {
        yield return new WaitForSecondsRealtime(5 );
        introPanel.SetActive( false );
        Help.SetActive( true);
       
    }

    public void ActivateLanguage()
    {
        Okay.SetActive(true);
    }

    public void DeActivateLanguage()
    {
        Help.SetActive(false);
    }
}
