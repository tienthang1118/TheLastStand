using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    private AudioManager audioManager;
    private WaveManager waveManager;
    public TextMeshProUGUI resultText;
    public GameObject ScreenResult;
    private float waitTime;
    private void Awake()
    {
        waveManager = FindAnyObjectByType<WaveManager>();
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
        if (waitTime > 10f)
        {
            ScreenResult.SetActive(true);
            resultText.text = "YOU WIN";
            ShowResult();
        }
        if (waveManager.EnemyNumbers == 0)
        {
            waitTime += Time.deltaTime;
        }
        else
        {
            waitTime = 0;
        }
    }
    public void ShowResult()
    {
        ScreenResult.SetActive(true);
    }
}
