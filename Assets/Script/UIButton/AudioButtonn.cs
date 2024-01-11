using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioButtonn : BaseButton
{
    public Sprite soundOnImg;
    public Sprite soundOffImg;

    protected override void Start()
    {
        base.Start();
        UpdateButtonImage();
    }
    protected override void OnClick()
    {
        ChangeButtonImage();
        AudioListener.pause = !AudioListener.pause;
    }
    void ChangeButtonImage()
    {
        if (AudioListener.pause)
        {
            gameObject.GetComponent<Image>().sprite = soundOnImg;

        }
        else
        {
            gameObject.GetComponent<Image>().sprite = soundOffImg;
        }
    }
    void UpdateButtonImage()
    {
        if (!AudioListener.pause)
        {
            gameObject.GetComponent<Image>().sprite = soundOnImg;

        }
        else
        {
            gameObject.GetComponent<Image>().sprite = soundOffImg;
        }
    }
}
