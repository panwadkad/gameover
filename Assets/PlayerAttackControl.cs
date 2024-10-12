using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackControl : MonoBehaviour
{
    private PlayerMoveControl playerMoveControl;
    private GatherInput gatherInput;
    private Animator animator;
    public bool attackStarted = false;
    public PolygonCollider2D attackCollider;
    // Start is called before the first frame update
    void Start()
    {
        playerMoveControl = GetComponent<PlayerMoveControl>();
        animator = GetComponent<Animator>();
        gatherInput = GetComponent<GatherInput>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    private void Attack(){
        if(gatherInput.tryAttack){
            animator.SetBool("Attack",true);
            attackStarted = true;
        }
    }

    public void ActivateAttack(){
        attackCollider.enabled = true;
    }

    public void StopAttack(){
        animator.SetBool("Attack", false);
        gatherInput.tryAttack = false;
        attackStarted = false;
        attackCollider.enabled = false;
    }
}
