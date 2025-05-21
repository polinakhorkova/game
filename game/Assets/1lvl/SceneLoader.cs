using UnityEngine;
using UnityEngine.SceneManagement;  // Не забудьте эту строку!

public class SceneLoader : MonoBehaviour
{
    // Загрузка по имени сцены
    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // ИЛИ загрузка по индексу сцены (указанному в Build Settings)
    public void LoadSceneByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}