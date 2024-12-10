using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target; // Персонаж, за которым следует камера
    public Vector3 offset = new Vector3(0, 2, -5); // Смещение камеры от персонажа
    public float followSpeed = 10f; // Скорость следования камеры за персонажем

    void LateUpdate()
    {
        if (target == null) return;

        // Вычисление позиции камеры за спиной персонажа
        Quaternion targetRotation = target.rotation; // Используем текущий поворот персонажа
        Vector3 desiredPosition = target.position + targetRotation * offset; // Смещение относительно поворота персонажа

        // Плавное следование камеры за персонажем
        transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);

        // Камера смотрит на персонажа
        transform.LookAt(target.position + Vector3.up * 1.5f); // Немного выше, чтобы фокус был на уровне головы
    }
}