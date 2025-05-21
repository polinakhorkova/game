using UnityEngine;

public class MiniGameTrigger : MonoBehaviour
{
    public GameObject MemoryGame;
    public GameObject hintUI;
    public float requiredMana = 20f; // Сколько нужно маны для запуска мини-игры
    public float manaCostOnEnd = 20f; // Сколько маны тратится после завершения игры
    public AudioClip endGameSound; // Звук для окончания игры
    public GameObject cubeToDisappear; // Добавляем публичную переменную для куба


    private PlayerMovement playerMovement;
    private ManaSystem playerMana;
    private AudioSource audioSource; // Ссылка на AudioSource
    private Animator playerAnimator; // Добавляем ссылку на Animator
    private bool isGameCompleted = false;
    private bool isPlayerInTrigger = false;

    private void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        playerMana = FindObjectOfType<ManaSystem>();
        playerAnimator = FindObjectOfType<PlayerMovement>().GetComponent<Animator>(); // Получаем Animator
        
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        if (MemoryGame != null) MemoryGame.SetActive(false);
        if (hintUI != null) hintUI.SetActive(false);
        cubeToDisappear = GameObject.Find("Cube.012");
    if (cubeToDisappear == null) 
    {
        Debug.LogError("Не найден Cube.012 в сцене!");
    }
    }

    private void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.F) && !isGameCompleted)
        {
            if (playerMana != null && playerMana.currentMana >= requiredMana)
            {
                Debug.Log("Достаточно маны, запуск мини-игры...");
                StartMiniGame();
            }
            else
            {
                Debug.Log("Недостаточно маны для запуска мини-игры!");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isGameCompleted)
        {
            isPlayerInTrigger = true;
            if (hintUI != null) hintUI.SetActive(true);
            
            // Замораживаем игрока и останавливаем анимацию
            if (playerMovement != null) 
            {
                playerMovement.canMove = false;
            }
            
            if (playerAnimator != null)
            {
                playerAnimator.SetFloat("Speed", 0f); // Останавливаем анимацию ходьбы
                // Или можно использовать playerAnimator.enabled = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
            if (hintUI != null) hintUI.SetActive(false);
            
            // Размораживаем игрока и возобновляем анимацию
            if (playerMovement != null) 
            {
                playerMovement.canMove = true;
            }
            
            if (playerAnimator != null)
            {
                playerAnimator.SetFloat("Speed", 1f); // Возобновляем анимацию
                // Или playerAnimator.enabled = true;
            }
        }
    }

    public void StartMiniGame()
    {
        if (MemoryGame == null)
        {
            Debug.LogError("MemoryGame не назначен!");
            return;
        }

        MemoryGame.SetActive(true);
        if (playerMovement != null) playerMovement.canMove = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        var miniGame = MemoryGame.GetComponent<IMiniGame>();
        if (miniGame != null) miniGame.OnGameEnded += EndMiniGame;
    }

    public void EndMiniGame(bool isWin)
    {
        if (MemoryGame != null) MemoryGame.SetActive(false);
        if (playerMovement != null) playerMovement.canMove = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (isWin) 
        {
            isGameCompleted = true;
            
            // Удаление куба при победе
            if (cubeToDisappear != null)
            {
                Destroy(cubeToDisappear); // Полное удаление объекта
                // Или, если хотите просто скрыть:
                // cubeToDisappear.SetActive(false);
            }
            else
            {
                Debug.LogWarning("Cube to disappear not assigned!");
            }
        }

        if (playerMana != null)
        {
            playerMana.UseMana(manaCostOnEnd); // Уменьшаем ману после игры
        }

        var miniGame = MemoryGame.GetComponent<IMiniGame>();
        if (miniGame != null) miniGame.OnGameEnded -= EndMiniGame;

        if (hintUI != null) hintUI.SetActive(false);

        // Воспроизведение звука после завершения игры
        if (endGameSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(endGameSound);
        }

    }
}

public interface IMiniGame
{
    event System.Action<bool> OnGameEnded;
}
