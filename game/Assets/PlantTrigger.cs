using UnityEngine;
using System.Collections;

public class FlowerColorChange : MonoBehaviour
{
    public Renderer flowerRenderer;  
    public Color targetColor = Color.red;  
    public float duration = 2f;  
    public AudioClip changeSound;  

    private Color startColor;  
    private bool isChanging = false;  
    private Material flowerMaterial;
    private AudioSource audioSource;
    private bool playerInRange = false; 
    private ManaSystem playerMana; // 👈 Добавлено для проверки маны

    void Start()
    {
        if (flowerRenderer == null)
        {
            flowerRenderer = GetComponent<Renderer>();
        }
        flowerMaterial = flowerRenderer.material;

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        startColor = flowerMaterial.color;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            playerMana = other.GetComponent<ManaSystem>(); // 👈 Получаем ссылку на систему маны
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
        if (playerInRange && Input.GetKeyDown(KeyCode.E) && !isChanging) 
        {
            if (playerMana != null && playerMana.currentMana >= 15) // 👈 Проверка маны
            {
                StartCoroutine(ChangeColor());
            }
            else
            {
                Debug.Log("Недостаточно маны для взаимодействия с цветком!");
            }
        }
    }

    IEnumerator ChangeColor()
    {
        isChanging = true;
        float timeElapsed = 0f;
        Color currentColor = flowerMaterial.color;

        flowerMaterial.EnableKeyword("_EMISSION");

        if (changeSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(changeSound);
        }

        while (timeElapsed < duration)
        {
            Color lerpedColor = Color.Lerp(currentColor, targetColor, timeElapsed / duration);
            flowerMaterial.color = lerpedColor;
            flowerMaterial.SetColor("_EmissionColor", lerpedColor * 2f);

            timeElapsed += Time.deltaTime;
            yield return null;
        }

        flowerMaterial.color = targetColor;
        flowerMaterial.SetColor("_EmissionColor", targetColor * 3f);

        isChanging = false;
    }
}
