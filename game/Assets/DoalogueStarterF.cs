using UnityEngine;
using UnityEngine.UI;
public class DialogueStarter : MonoBehaviour
{
    public GameObject hintUI; // Ссылка на объект подсказки
    private bool isPlayerInRange = false;

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.F))
        {
            StartDialogue(); // Запускаем диалог
        }
    }

    private void StartDialogue()
    {
        // Здесь ваша логика для начала диалога
        Debug.Log("Начался диалог");

        // Скрываем подсказку
        if (hintUI != null)
        {
            hintUI.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;

            // Показываем подсказку
            if (hintUI != null)
            {
                hintUI.SetActive(true);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;

            // Скрываем подсказку
            if (hintUI != null)
            {
                hintUI.SetActive(false);
            }
        }
    }
}
