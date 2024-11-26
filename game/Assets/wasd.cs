using UnityEngine;
public class Wasd: MonoBehaviour
{
    public float moveSpeed = 5f; // Скорость движения персонажа

    void Update()
    {
        // Получаем ввод от пользователя
        float moveHorizontal = Input.GetAxis("Horizontal"); // A/D или стрелки влево/вправо
        float moveVertical = Input.GetAxis("Vertical"); // W/S или стрелки вверх/вниз

        // Создаём вектор направления движения
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Перемещаем персонажа
        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }
}

