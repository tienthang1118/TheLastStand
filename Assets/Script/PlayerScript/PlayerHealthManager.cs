using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : HumanoidHealthManager
{
    public override void Die()
    {
        Debug.Log("GAME OVER");
        Time.timeScale = 0f;
        FindObjectOfType<GameManager>().ShowResult();
    }
}
