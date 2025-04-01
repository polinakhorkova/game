using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 80f;
    public Rigidbody rb;
    public Transform FreeCamera;
    public Animator animator;
    
    public bool canMove = true; // Флаг, можно ли двигаться

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (!canMove) return; // Если canMove = false, персонаж не двигается

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 cameraForward = FreeCamera.forward;
        Vector3 cameraRight = FreeCamera.right;
        cameraForward.y = 0;
        cameraRight.y = 0;
        cameraForward.Normalize();
        cameraRight.Normalize();

        Vector3 movement = (cameraForward * moveZ + cameraRight * moveX).normalized;

        if (movement.magnitude > 0.1f)
        {
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, 0.1f);
        }

        animator.SetFloat("Speed", movement.magnitude);
        rb.MovePosition(transform.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
