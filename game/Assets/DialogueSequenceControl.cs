using UnityEngine;

public class DialogueSequenceControl : MonoBehaviour
{
    public static DialogueSequenceControl instance;

    private bool firstDialogueFinished = false; // Флаг завершения первого диалога

    void Awake()
    {
        if (instance == null)
        {
            instance = this; // Создаем синглтон
        }
    }

    // Метод, который вызывается, когда первый диалог завершен
    public void FinishFirstDialogue()
    {
        firstDialogueFinished = true;
        Debug.Log("Первый диалог завершен!");
    }

    // Проверка, можно ли начать второй диалог
    public bool CanStartSecondDialogue()
    {
        return firstDialogueFinished; // Разрешаем второй диалог только после первого
    }
}
