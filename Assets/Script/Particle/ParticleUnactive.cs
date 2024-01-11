using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleUnactive : MonoBehaviour
{
    [Header("Particle life time")]
    [SerializeField]
    private float lifetime;

    void OnEnable()
    {
        StartCoroutine(DisableAfterTime());
    }

    IEnumerator DisableAfterTime()
    {
        yield return new WaitForSeconds(lifetime);
        ObjectPoolManager.ReturnObjectToPool(gameObject);
    }
}
