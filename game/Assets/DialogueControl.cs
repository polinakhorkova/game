using UnityEngine;

public class DialogueControl : MonoBehaviour
{
    public static DialogueControl instance; // Делаем скрипт синглтоном

    private bool isDialogueFinished = false; // Флаг завершения диалога

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void FinishDialogue()
    {
        isDialogueFinished = true; // Устанавливаем флаг в true, когда диалог окончен
        Debug.Log("Диалог завершен!");
    }

    public bool IsDialogueFinished()
    {
        return isDialogueFinished;
    }
}
