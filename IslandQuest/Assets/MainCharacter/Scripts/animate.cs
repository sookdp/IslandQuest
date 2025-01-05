using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate : MonoBehaviour
{
    Animator PlayerAnimator; // Référence à l'Animator
    AudioSource audioSource; // Référence à l'AudioSource

    // Clips audio pour chaque animation
    public AudioClip walkSound;
    public AudioClip jumpSound;

    void Awake()
    {
        // Associe l'Animator et l'AudioSource
        PlayerAnimator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Gérer l'animation de marche
        float walkInput = Input.GetAxis("Vertical");
        PlayerAnimator.SetFloat("walk", walkInput);

        if (walkInput != 0 && !audioSource.isPlaying)
        {
            PlaySound(walkSound); // Jouer le son de marche
        }

        // Gérer l'animation de saut
        bool isJumping = Input.GetButton("Jump");
        PlayerAnimator.SetBool("jump", isJumping);

        if (isJumping && !audioSource.isPlaying)
        {
            PlaySound(jumpSound); // Jouer le son de saut
        }

        // Arrêter le son si aucune action n'est en cours
        if (walkInput == 0 && !isJumping)
        {
            StopSound();
        }
    }

    // Fonction pour jouer un son
    void PlaySound(AudioClip clip)
    {
        if (clip != null)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
    }

    // Fonction pour arrêter le son
    void StopSound()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}
