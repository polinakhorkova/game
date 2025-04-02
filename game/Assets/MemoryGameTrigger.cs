using UnityEngine;

public class MiniGameTrigger : MonoBehaviour
{
    public GameObject MemoryGame;
    public GameObject hintUI;
    private PlayerMovement playerMovement;
    private bool isGameCompleted = false;
    private bool isPlayerInTrigger = false;

    private void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        if (MemoryGame != null) MemoryGame.SetActive(false);
        if (hintUI != null) hintUI.SetActive(false);
    }

    private void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.F) && !isGameCompleted)
        {
            Debug.Log("F нажата, запуск мини-игры...");
            StartMiniGame();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isGameCompleted)
        {
            Debug.Log("Игрок в триггере!");
            isPlayerInTrigger = true;
            if (hintUI != null) hintUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Игрок вышел из триггера!");
            isPlayerInTrigger = false;
            if (hintUI != null) hintUI.SetActive(false);
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
        
        if (isWin) isGameCompleted = true;
        
        var miniGame = MemoryGame.GetComponent<IMiniGame>();
        if (miniGame != null) miniGame.OnGameEnded -= EndMiniGame;
        Destroy(gameObject);
        
    } 
    
}

public interface IMiniGame
{
    event System.Action<bool> OnGameEnded;
}