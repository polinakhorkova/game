using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    public GameObject hintUI; // Ссылка на объект подсказки (UI)

    void Start()
    {
        if (hintUI != null)
            hintUI.SetActive(false); // Скрываем подсказку изначально
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Проверяем, что триггер активирован игроком
        {
            if (hintUI != null)
                hintUI.SetActive(true); // Показываем подсказку
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (hintUI != null)
                hintUI.SetActive(false); // Скрываем подсказку
        }
    }
}
