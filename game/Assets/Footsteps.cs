using UnityEngine;

public class Footsteps : MonoBehaviour
{
    [Header("Audio Settings")]
    public AudioSource audioSource;  // Источник звука
    public AudioClip[] footstepSounds;  // Массив звуков шагов

    [Header("Movement Settings")]
    public Rigidbody rb;  // Rigidbody персонажа
    public float stepInterval = 0.5f;  // Интервал между шагами
    public LayerMask groundLayer;  // Слой земли

    private float stepTimer;

    void Update()
    {
        if (IsMoving())
        {
            stepTimer += Time.deltaTime;
            if (stepTimer > stepInterval)
            {
                PlayFootstep();
                stepTimer = 0f;
            }
        }
        else
        {
            stepTimer = 0f;
        }
    }

    bool IsMoving()
    {
        return rb.linearVelocity.sqrMagnitude > 0.1f && IsGrounded();
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.1f, groundLayer);
    }

    void PlayFootstep()
    {
        if (footstepSounds.Length > 0 && audioSource != null)
        {
            int index = Random.Range(0, footstepSounds.Length);
            audioSource.PlayOneShot(footstepSounds[index]);
        }
    }
}
