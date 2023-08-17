using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
public class Manager : MonoBehaviour
{
    public static Manager instance;
    public AudioSource source;
    public AudioClip alarmClip;
    public MeshRenderer alarm;
    public Material breakedGlass;
    public GameObject[] largeFire;
    public GameObject sparks;
    public Transform firePoint;
    private GameObject player;
    private bool warningSend = false;
    public float fireWarningDistance = 2.5f;
    public GameObject fireWarningMessage;
    public GameObject fireWarningMessageHindi;
    public GameObject fireExtinguishedMessage;
    public GameObject[] arrowIndication;
    public GameObject[] blinkLights;

    public Image backGroundImage;
    public Sprite[] hindi;
    public Sprite[] english;

    public bool checkForDistance = true;
    public UnityEvent eventOnStart;
    public GameObject sceneSelectionScreen;
    public Transform exitPoint;
    public Transform startPoint;
    private bool isFireDeactivated = false;
    public UnityEvent stopFireAction;
    void Start()
    {
        isFireDeactivated = false;
        player = GameObject.FindWithTag("Player");
        eventOnStart.Invoke();
        if (SceneManager.GetActiveScene().name == "ElectricFire" || SceneManager.GetActiveScene().name == "SolidFire")
        {
            instance = this;
            sparks.SetActive(true);
            Debug.Log("Spark");
            Invoke("StartFire", 7f);
            warningSend = true;
            StaticData.ResetData();
            player.transform.position = startPoint.position;
            player.transform.rotation = startPoint.rotation;
        }
    }
    void Update()
    {
        if (checkForDistance)
        {
            CheckDistance();
        }
    }

    public void PlayAlarmSound()
    {
        source.clip = alarmClip;
        source.Play();
        alarm.material = breakedGlass;
        StartCoroutine(ArrowIndicator());
    }

    void StartFire()
    {
        for (int i = 0; i < largeFire.Length; i++)
        {
            largeFire[i].SetActive(true);
        }
    }
    public void DeactivateFire()
    {
        for (int i = 0; i < largeFire.Length; i++)
        {
            largeFire[i].SetActive(false);
        }
        source.Stop();
        isFireDeactivated = true;
        WarningPopUp(false);
        sparks.SetActive(false);
        fireExtinguishedMessage.SetActive(true);
        SoundManager.instance.PlayMultipleAudio(10, 11);
        sceneSelectionScreen.SetActive(true);
        stopFireAction.Invoke();
    }

    private void CheckDistance()
    {
        if (!isFireDeactivated)
        {
            if (!warningSend)
            {
                float distance = Vector3.Distance(player.transform.position, firePoint.position);
                if (distance <= fireWarningDistance)
                {
                    WarningPopUp(true);
                    warningSend = true;
                }
            }
            else
            {
                float distance = Vector3.Distance(player.transform.position, firePoint.position);
                if (distance > fireWarningDistance)
                {
                    warningSend = false;
                    WarningPopUp(false);
                }
            }
        }
    }
    public void WarningPopUp(bool _condition)
    {
        if (StaticData.language == "English")
        {
            fireWarningMessage.SetActive(_condition);
        }
        else
        {
            fireWarningMessageHindi.SetActive(_condition);
        }
    }
    IEnumerator ArrowIndicator()
    {
        yield return new WaitForSecondsRealtime(0.2f);
        for (int i = 0; i < arrowIndication.Length; i++)
        {
            arrowIndication[i].SetActive(true);
        }
        for (int i = 0; i < blinkLights.Length; i++)
        {
            blinkLights[i].SetActive(true);
        }
        yield return new WaitForSecondsRealtime(0.2f);
        for (int i = 0; i < arrowIndication.Length; i++)
        {
            arrowIndication[i].SetActive(false);
        }
        for (int i = 0; i < blinkLights.Length; i++)
        {
            blinkLights[i].SetActive(false);
        }
        StartCoroutine(ArrowIndicator());
    }
    public void ChangeScreen(int indexNumber)
    {
        if (StaticData.language == "English")
        {
                backGroundImage.sprite = english[indexNumber];
        }
        else
        {
            backGroundImage.sprite = hindi[indexNumber];
        }
    }
    public void ChangeScene(int _indexNumber)
    {
        SceneManager.LoadScene(_indexNumber);
    }
    public void TeleportToExit()
    {
        player.transform.position = exitPoint.transform.position;
        player.transform.rotation = exitPoint.transform.rotation;

    }
}
