using UnityEngine;

public class ArrowController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Vector3 moveDirection;
    private PlayerController player;

    public void Initialize(Vector3 dir, PlayerController controller)
    {
        moveDirection = dir;
        player = controller;
    }

    private void OnMouseDown()
    {
        player.Move(moveDirection);
    }
}
