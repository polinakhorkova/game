using UnityEngine;

public class PlantTrigger : MonoBehaviour
{
    public GameObject plant; // Это публичное поле для объекта растения
    private bool playerNearby = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
            Debug.Log("Press E to restore the plant.");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
        }
    }

    void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.E))
        {
            RestorePlant();
        }
    }

    private void RestorePlant()
    {
        // Изменяем цвет растения на зеленый
        if (plant != null)
        {
            Renderer renderer = plant.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material.color = new Color(0.5f, 0.7f, 0.2f);
                Debug.Log("The plant has been restored!");
            }
            else
            {
                Debug.LogWarning("No Renderer found on the plant!");
            }
        }

        // Отключаем триггер после выполнения действия
        gameObject.SetActive(false);
    }
}
