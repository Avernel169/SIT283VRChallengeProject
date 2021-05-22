using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using DG.Tweening;
public class GameController : MonoBehaviour
{
    public static GameController instance;

    public static float TimeScale=1.0f;//Control the time gap of the scale update
    public static float HeartSpeed = 1.0f;//Control the pulse speed
    public static float CardiogramScale = 1.0f;//Control the scale of ECG
    public GameObject[] Cardiogram;

    public Button[] Buttons;
    public GameObject Notice;
    public Text NoticeText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void IncreaseCardiogram()
    {
        if (Mathf.Abs(CardiogramScale-1.2f)<0.1f)
        {
            SoundManager.instance.PlayQuick();
            Debug.Log("play quick");
        }
        else if (Mathf.Abs(CardiogramScale-0.8f)<0.1f)
        {
            SoundManager.instance.PlayNormal();
            Debug.Log("play normal");

        }
        if (Mathf.Abs(CardiogramScale - 1.4f) < 0.1f)
        {
            Notice.SetActive(true);
            StartCoroutine(CloseNotice());
            NoticeText.text = "Heart Beat Too High!";
        }
        CardiogramScale += 0.1f;
        Debug.Log("increase"+CardiogramScale);
    }
    public void DecreaseCardiogram()
    {
        if (Mathf.Abs(CardiogramScale - 1.2f) < 0.1f)
        {
            SoundManager.instance.PlayNormal();
            Debug.Log("play normal");

        }
        else if (Mathf.Abs(CardiogramScale - 0.8f) < 0.1f)
        {
            SoundManager.instance.PlayEmergency();
            Debug.Log("play emergency");

        }
        if (Mathf.Abs(CardiogramScale - 1.4f) < 0.1f)
        {
            Notice.SetActive(true);
            NoticeText.text = "Heart Beat Too High!";
            StartCoroutine(CloseNotice());
        }
        CardiogramScale -= 0.1f;
        Debug.Log("decrease"+CardiogramScale);
    }
    public void ShowNormal()
    {
        Buttons[1].gameObject.SetActive(false);
        Buttons[2].gameObject.SetActive(false);
        Buttons[3].gameObject.SetActive(true);
    }
    public void ShowEmergency()
    {
        Buttons[0].gameObject.SetActive(false);
        Buttons[2].gameObject.SetActive(false);
        Buttons[3].gameObject.SetActive(true);
        Buttons[4].gameObject.SetActive(true);
        Buttons[5].gameObject.SetActive(true);
        Buttons[6].gameObject.SetActive(true);
        CardiogramScale = 0.5f;
    }
    public void ResetButtons()
    {
        for (int i = 0; i < Buttons.Length; i++)
        {
            Buttons[i].gameObject.SetActive(false);
        }
        Buttons[0].gameObject.SetActive(true);
        Buttons[1].gameObject.SetActive(true);
        Buttons[2].gameObject.SetActive(true);
    }
    public void CheckValue()
    {
        if (CardiogramScale <= 0.9f)
        {
            Notice.SetActive(true);
            NoticeText.text = "Heart Beat Too Low!";
        }
        else if (CardiogramScale >= 1.1f)
        {
            Notice.SetActive(true);
            NoticeText.text = "Heart Beat Too High!";
        }
        else
        {
            Notice.SetActive(true);
            NoticeText.text = "Good Job!";
        }
        StartCoroutine(CloseNotice());
    }
    IEnumerator CloseNotice()
    {
        yield return new WaitForSeconds(2.0f);
        Notice.SetActive(false);
    }
}
