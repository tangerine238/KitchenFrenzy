using UnityEngine;
using System;

public class GameInput : MonoBehaviour
{

    private PlayerInputActions playerInputActions;
    public event EventHandler OnInteractAction;
    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();

        playerInputActions.Player.Interact.performed += Interact_performed;
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        /* Same as 
        if (OnInteractAction != null){
        OnInteractAction(this, EventArgs.Empty);
        }
        */
        OnInteractAction?.Invoke(this, EventArgs.Empty);
    }
    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();

        inputVector = inputVector.normalized;

        return inputVector;
    }
}
