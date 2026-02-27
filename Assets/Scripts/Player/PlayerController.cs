using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] Vector2 verticalPadding;
    [SerializeField] Vector2 horizontalPadding;

    InputAction moveAction;

    Vector3 moveVector;
    Vector2 minBounds;
    Vector2 maxBounds;

    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        moveAction.Enable();

        InitBounds();
    }

    void Update()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        moveVector = moveAction.ReadValue<Vector2>();
        Vector3 newPos = transform.position + moveVector * moveSpeed * Time.deltaTime;
        print(moveVector);

        newPos.x = Mathf.Clamp(newPos.x, minBounds.x + horizontalPadding.x, maxBounds.x - horizontalPadding.y);
        newPos.y = Mathf.Clamp(newPos.y, minBounds.y + verticalPadding.x, maxBounds.y - verticalPadding.y);

        transform.position = newPos;
    }

    void InitBounds()
    {
        Camera cam = Camera.main;
        minBounds = cam.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = cam.ViewportToWorldPoint(new Vector2(1, 1));
    }
}
