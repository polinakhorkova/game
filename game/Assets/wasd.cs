using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 80f; // Скорость движения персонажа
    public Rigidbody rb; // Rigidbody персонажа
    public Transform FreeCamera; // Ссылка на камеру
    public Animator animator; // Ссылка на Animator

   

    private void Update()
    {
        // Получаем ввод с клавиатуры
        float moveX = Input.GetAxis("Horizontal"); // A/D или стрелки влево/вправо
        float moveZ = Input.GetAxis("Vertical");   // W/S или стрелки вверх/вниз

        // Направление относительно камеры
        Vector3 cameraForward = FreeCamera.forward; // Направление камеры вперед
        Vector3 cameraRight = FreeCamera.right;     // Направление камеры вправо
        cameraForward.y = 0; // Убираем наклон камеры
        cameraRight.y = 0;   // Убираем наклон камеры
        cameraForward.Normalize();
        cameraRight.Normalize();

        // Вычисляем итоговое направление движения
        Vector3 movement = (cameraForward * moveZ + cameraRight * moveX).normalized;

        // Поворачиваем персонажа в направлении движения
        if (movement.magnitude > 0.1f) // Если есть движение
        {
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, 0.1f);
        }

        // Передаем параметр Speed в Animator только если есть движение
        animator.SetFloat("Speed", movement.magnitude); // Убираем множитель на moveSpeed
        rb.MovePosition(transform.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
