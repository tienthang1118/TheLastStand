using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private AudioManager audioManager;

    public GameObject ScreenResult;

    private void Awake()
    {
        audioManager = FindAnyObjectByType<AudioManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        audioManager.PlayMusic();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowResult()
    {
        ScreenResult.SetActive(true);
    }
}
