using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private GameInput gameInput;
    private bool isWalking;
    private void Update()
    {

        Vector2 inputVector = gameInput.GetMovementVectorNormalized();
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        float playerSize = 0.7f;
        bool can Move = !Physics.Raycast(transform.position, moveDir, playerSize);

        if (canMove)
        {
            transform.position += moveDir * Time.deltaTime * moveSpeed;
        }


        isWalking = moveDir != Vector3.zero;
        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);


    }

    public bool IsWalking()
    {
        return isWalking;
    }
}
