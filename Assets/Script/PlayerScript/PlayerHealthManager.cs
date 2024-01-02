using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    private PlayerStats playerStats;
    
    private int currentHealthPoint;

    private void Awake()
    {
        playerStats = GetComponent<PlayerStats>();
    }
    private void OnEnable()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        currentHealthPoint = playerStats.MaxHealthPoint;
    }

    public void TakeDamage(int damage)
    {
        currentHealthPoint -= damage;
        if (currentHealthPoint <= 0)
        {
            Debug.Log("GAME OVER");
            Time.timeScale = 0f;
            FindObjectOfType<GameManager>().ShowResult();
        }
    }
}
