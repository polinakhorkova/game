using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody _rigidbody;
    [SerializeField] private float speed = 4f; // Скорость движения
    [SerializeField] private float rotationSpeed = 10f; // Скорость поворота
    private const float inputThreshold = 0.1f; // Порог ввода для движения

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Получение ввода от пользователя
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // Направление движения персонажа
        Vector3 directionVector = new Vector3(h, 0, v);

        // Проверяем, превышает ли ввод порог для движения
        bool isMoving = directionVector.magnitude > inputThreshold;

        // Устанавливаем параметр анимации
        _animator.SetBool("isMoving", isMoving);

        if (isMoving)
        {
            // Нормализуем вектор направления и устанавливаем его как целевой
            Vector3 lookDirection = directionVector.normalized;
            Quaternion targetRotation = Quaternion.LookRotation(lookDirection);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

            // Определяем максимальную скорость (с учётом бега)
            float maxSpeed = Input.GetKey(KeyCode.LeftShift) ? 4f : 2f;
            speed = maxSpeed;

            // Перемещение персонажа
            Vector3 moveDir = directionVector.normalized * speed * Time.deltaTime;
            transform.Translate(moveDir, Space.World);
        }
    }
}
