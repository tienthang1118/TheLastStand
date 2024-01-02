using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterZomieAnimationManager : MonoBehaviour
{
    private Animator animator;
    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void PlayShootAnimation(bool isShooting)
    {
        animator.SetBool("IsShooting", isShooting);
    }
    public void PlayRunAnimation(bool isRunning)
    {
        animator.SetBool("IsRunning", isRunning);
    }
    public bool IsShootingAnimation()
    {
        return animator.GetBool("IsShooting");
    }
}
