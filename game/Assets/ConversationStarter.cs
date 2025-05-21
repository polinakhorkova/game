using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class ConversationStarter : MonoBehaviour
{
    [SerializeField]  private NPCConversation myConversation;

<<<<<<< Updated upstream
=======
    void Start()
    {
        playerMovement = FindAnyObjectByType<PlayerMovement>(); // Ищем PlayerMovement
    }
    
>>>>>>> Stashed changes
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                ConversationManager.Instance.StartConversation(myConversation);
            }
        }
    }
}