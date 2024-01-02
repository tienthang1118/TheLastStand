using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private EnemyStats enemyStats;
    private Transform playerTransform;
    private void Awake()
    {
        enemyStats = GetComponent<EnemyStats>();
        playerTransform = GameObject.FindGameObjectWithTag(GameTags.PLAYER).transform;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovement();
        UpdateRotation();
    }
    void UpdateMovement()
    {
        Vector3 direction = (playerTransform.position - transform.position).normalized; 
        transform.position += direction * enemyStats.MovementSpeed * Time.deltaTime;
    }
    void UpdateRotation()
    {
        transform.LookAt(playerTransform);
    }
    private void OnCollisionEnter(Collision collision)
    {
        DealDamage(collision.gameObject);
    }
    void DealDamage(GameObject target)
    {
        if (target.tag == GameTags.PLAYER)
        {
            target.GetComponent<PlayerHealthManager>().TakeDamage(enemyStats.Damage);
        }
    }
}
