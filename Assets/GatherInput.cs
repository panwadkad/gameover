using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GatherInput : MonoBehaviour
{

    public Control control;
    public float valueX;
    public bool jumpInput;
    public bool tryAttack; // for check attack status
 
    public void Awake()
    {
        control = new Control();
    } 
    private void OnEnable() 
    {
        control.Player.Move.performed += StartMOve;
        control.Player.Move.canceled += StopMove;
        control.Player.Jump.performed += JumpStart;
        control.Player.Jump.canceled += JumpStop;

        control.Player.Attack.performed += TryToAttack;
        control.Player.Attack.canceled += StopTryToAttack;
        control.Player.Enable();
    }

    private void OnDisable()
    {
        control.Player.Move.performed -= StartMOve;
        control.Player.Move.canceled -= StopMove;
        control.Player.Jump.performed -= JumpStart;
        control.Player.Jump.canceled -= JumpStop;

        control.Player.Attack.performed -= TryToAttack;
        control.Player.Attack.canceled -= StopTryToAttack;
        control.Player.Disable();

    }

    public void OnDisableControl()
    {
        control.Player.Move.performed -= StartMOve;
        control.Player.Move.canceled -= StopMove;
        control.Player.Jump.performed -= JumpStart;
        control.Player.Jump.canceled -= JumpStop;
        control.Player.Disable();

    }



    private void StartMOve(InputAction.CallbackContext ctx) 
    {
        valueX = ctx.ReadValue<float>();
    }

    private void StopMove(InputAction.CallbackContext ctx)
    {
        valueX = 0; Debug.Log(valueX);
    }

    private void JumpStart(InputAction.CallbackContext ctx)
    {
        jumpInput =true;
    }

    private void JumpStop(InputAction.CallbackContext ctx)
    {
        jumpInput =false;

    }

    private void TryToAttack(InputAction.CallbackContext ctx){
        tryAttack = true;
    }
    private void StopTryToAttack(InputAction.CallbackContext ctx){
        tryAttack = false;
    }

}
