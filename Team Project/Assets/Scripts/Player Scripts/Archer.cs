using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : PlayerManager
{
    [SerializeField] private GameObject arrow;
    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
    }

    public override void Attack()
    {
        //Activiate the shooting animation
        anim.SetBool("isShooting", true);
    }

    void Shoot()
    {
        //Spawn the arrow
        Instantiate(arrow, attackPos.position, transform.rotation);

    }

    void ChangeAnimation()
    {
        //Deactivate the shooting animation
        anim.SetBool("isShooting", false);
    }
}
