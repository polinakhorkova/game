using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneWithoutPlayer : MonoBehaviour
{
    [SerializeField] private string sceneName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Удаляем игрока перед загрузкой сцены
            Destroy(other.gameObject); 
            
            // Активируем курсор
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            
            // Загружаем сцену
            SceneManager.LoadScene(sceneName);
        }
    }
}