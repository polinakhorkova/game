
using UnityEngine;
using UnityEngine.UI; // Подключаем работу с UI

public class MemoryGameTrigger : MonoBehaviour
{
    public GameObject PromptText; // Ссылка на текст
    public GameObject MemoryGame;
    private bool isPlayerNearby = false;

    void Start()
    {
        PromptText.SetActive(false); // Скрываем текст при старте
       MemoryGame.SetActive(false);
    }

    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.F))
        {
            StartMiniGame();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("TriggerEnter");
        if (other.CompareTag("Player")) // Если игрок входит в зону
        {
            PromptText.SetActive(true);
            isPlayerNearby = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Если игрок уходит
        {
            PromptText.SetActive(false);
            isPlayerNearby = false;
        }
    }

    public void StartMiniGame()
    {
        MemoryGame.SetActive(true);
        //Time.timeScale = 0f;
        PromptText.SetActive(false);
    }

    public void EndMiniGame()
    {
        MemoryGame.SetActive(false);
        Time.timeScale = 1f;
    }
}