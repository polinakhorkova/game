using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    public GameObject hintUI; // UI с подсказкой "Нажмите F для диалога"
    public bool isSecondDialogue = false; // Флаг: это триггер второго диалога?

    void Start()
    {
        if (hintUI != null)
            hintUI.SetActive(false); // Скрываем подсказку изначально
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Проверяем, что триггер активирован игроком
        {
            // Проверяем, можно ли запускать второй диалог
            if (isSecondDialogue && !DialogueSequenceControl.instance.CanStartSecondDialogue())
            {
                Debug.Log("Вы не можете начать второй диалог, пока не завершите первый!");
                return; // Если первый диалог не завершен, не показываем подсказку
            }

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
