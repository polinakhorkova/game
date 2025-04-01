using System.Collections;
using System.Collections.Generic;
using DialogueEditor;
using UnityEngine;

public class ConversationStarter : MonoBehaviour
{
    [SerializeField] private NPCConversation myConversation;
    private PlayerMovement playerMovement;

    void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>(); // Ищем PlayerMovement
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                ConversationManager.Instance.StartConversation(myConversation);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                playerMovement.canMove = false; // Отключаем передвижение через canMove
                ConversationManager.OnConversationEnded += conversationEnded;
            }
        }
    }

    private void conversationEnded()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        playerMovement.canMove = true; // Включаем передвижение
        ConversationManager.OnConversationEnded -= conversationEnded;
    }
}
