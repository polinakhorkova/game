using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CaveEnter : MonoBehaviour
{
    public GameObject pressFHint; // Ссылка на Canvas/UI элемент с текстом "Нажмите F..."
    public string sceneName = "cave"; // Имя сцены для загрузки
    public KeyCode interactionKey = KeyCode.E;

    private bool isPlayerInTrigger = false;

    private void Start()
    {
        // Скрываем подсказку при старте
        if (pressFHint != null)
        {
            pressFHint.SetActive(false);
        }
    }

    private void Update()
    {
        // Если игрок в триггере и нажал F
        if (isPlayerInTrigger && Input.GetKeyDown(interactionKey))
        {
            LoadCaveScene();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = true;
            
            // Показываем подсказку
            if (pressFHint != null)
            {
                pressFHint.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
            
            // Скрываем подсказку
            if (pressFHint != null)
            {
                pressFHint.SetActive(false);
            }
        }
    }

    private void LoadCaveScene()
    {
        // Загружаем сцену
        SceneManager.LoadScene(sceneName);
        
        // Можно добавить эффект перехода или проверку перед загрузкой
        Debug.Log("Загрузка сцены: " + sceneName);
    }
}