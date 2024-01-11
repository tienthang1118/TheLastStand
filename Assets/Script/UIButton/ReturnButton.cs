using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnButton : BaseButton
{
    public GameObject charactersContainer;
    public GameObject screenCharacterSelect;
    public GameObject mainMenu;
    private AudioManager audioManager;
    protected override void Start()
    {
        base.Start();
        audioManager = FindAnyObjectByType<AudioManager>();
    }

    protected override void OnClick()
    {
        audioManager.PlayUIButtonSound();
        charactersContainer.SetActive(false);
        screenCharacterSelect.SetActive(false);
        mainMenu.SetActive(true);
    }
}
