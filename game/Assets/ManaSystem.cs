using UnityEngine;
using UnityEngine.UI;

public class ManaSystem : MonoBehaviour
{
    public float maxMana = 100f;
    public float currentMana = 0f; // По умолчанию мана 0, можно изменить в инспекторе
    public Image manaBar; // Ссылка на UI Image

    void Start()
    {
        UpdateManaUI(); // Обновляем UI сразу при старте, без изменения currentMana
    }

    public void RestoreMana(float amount)
    {
        currentMana = Mathf.Min(currentMana + amount, maxMana);
        UpdateManaUI();
    }

    public void UseMana(float amount)
    {
        currentMana = Mathf.Max(currentMana - amount, 20);
        UpdateManaUI();
    }

    void UpdateManaUI()
    {
        if (manaBar != null)
        {
            manaBar.fillAmount = currentMana / maxMana; // Обновляем UI
        }
    }
}
