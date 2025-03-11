using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputRouter : MonoBehaviour
{
    PlayerMover playerMover;
    PlayerAttacker playerAttacker;

    private void Start()
    {
        playerMover = GetComponent<PlayerMover>();
        playerAttacker = GetComponent<PlayerAttacker>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (!context.started)
            return;

        Vector2 direction = context.ReadValue<Vector2>();

        playerMover.Move(direction);
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (!context.started)
            return;

        bool isAttacking = context.ReadValueAsButton();

        if(isAttacking)
            playerAttacker.Attack();    
    }
}
