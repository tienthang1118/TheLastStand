using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCharacterButton : BaseButton
{
    private CharacterSelection characterSelection;
    private AudioManager audioManager;
    
    private enum ButtonType
    {
        CHANGE_LEFT,
        CHANGE_RIGHT
    }
    [SerializeField]
    private ButtonType buttonType;
    protected override void Start()
    {
        base.Start();
        characterSelection = FindAnyObjectByType<CharacterSelection>();
        audioManager = FindAnyObjectByType<AudioManager>();
    }
    protected override void OnClick()
    {
        audioManager.PlayUIButtonSound();
        if(buttonType == ButtonType.CHANGE_LEFT)
        {
            characterSelection.ChangeCharacter(-1);
        }
        else
        {
            characterSelection.ChangeCharacter(1);
        }
    }
}
