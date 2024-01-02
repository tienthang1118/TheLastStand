using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    [Header("Enemy max health point")]
    [SerializeField]
    private int maxHealthPoint;
    [SerializeField]
    private int currentHealthPoint;

    private void OnEnable()
    {
        currentHealthPoint = maxHealthPoint;
    }
    // Start is called before the first frame update
    void Start()
    {

    }
    
    // Update is called once per frame
    void Update()
    {

    }
    public void TakeDamage(int damage)
    {
        currentHealthPoint -= damage;
        if(currentHealthPoint <= 0)
        {
            ObjectPoolManager.ReturnObjectToPool(gameObject);
        }
    }
}
