using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    private int currentCharacterIndex;
    [SerializeField]
    private Transform charactesContainer;

    private void Start()
    {
        if(!PlayerPrefs.HasKey("CurrentCharacterIndex"))
        {
            currentCharacterIndex = 0;
        }
        else
        {
            currentCharacterIndex = PlayerPrefs.GetInt("CurrentCharacterIndex");
        }
        SelectCharacter(currentCharacterIndex);
    }
    private void SelectCharacter(int _index)
    {
        for(int i = 0; i < charactesContainer.childCount; i++)
        {
            charactesContainer.GetChild(i).gameObject.SetActive(i == _index);
            /*if (i == _index)
            {
                charactesContainer.GetChild(i).gameObject.SetActive(true);
                break;
            }*/
        }
    }
    public void ChangeCharacter(int _change)
    {
        currentCharacterIndex += _change;
        currentCharacterIndex = currentCharacterIndex < 0 ? (charactesContainer.childCount - 1) : currentCharacterIndex;
        currentCharacterIndex = currentCharacterIndex > (charactesContainer.childCount - 1) ? 0 : currentCharacterIndex;
        PlayerPrefs.SetInt("CurrentCharacterIndex", currentCharacterIndex);
        SelectCharacter(currentCharacterIndex);
    }
}
