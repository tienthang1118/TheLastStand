using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject[] charactersPrefab;

    private Transform playerTransform;

    private void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag(GameTags.PLAYER).transform;
    }
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < charactersPrefab.Length; i++)
        {
            if (i == PlayerPrefs.GetInt("CurrentCharacterIndex"))
            {
                Instantiate(charactersPrefab[i], playerTransform.position, charactersPrefab[i].transform.rotation).transform.SetParent(playerTransform);
                break;
            }
        }
    }
}
