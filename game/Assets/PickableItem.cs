using UnityEngine;

public class PickableItem : MonoBehaviour
{
    public float manaRestoreAmount = 20f;
    private bool playerInRange = false;
    private ManaSystem playerMana;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            playerMana = other.GetComponent<ManaSystem>(); // Получаем систему маны
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            playerMana = null;
        }
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (playerMana != null)
            {
                playerMana.RestoreMana(manaRestoreAmount);
                Destroy(gameObject); // Удаляем яблоко
            }
        }
    }
}
