using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
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
    public void PlayMovementAnimation()
    {
        if (!animator.GetBool("IsMoving"))
            animator.SetBool("IsMoving", true);
    }
    public void StopMovementAnimation()
    {
        animator.SetBool("IsMoving", false);
    }
    public bool IsShooting()
    {
        return animator.GetBool("IsShooting");
    }
}
