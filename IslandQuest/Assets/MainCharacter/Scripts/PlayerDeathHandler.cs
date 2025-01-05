using UnityEngine;

public class PlayerDeathHandler : MonoBehaviour
{
    public Animator animator;          // Référence à l'Animator pour lancer l'animation de mort
    public Transform respawnPoint;     // Point de réapparition

    void Start()
    {
       
    }

    void OnTriggerEnter(Collider other)
    {
        // Vérifie si le joueur touche un objet tagué "Water"
        if (other.CompareTag("Water"))
        {
            Debug.Log("Le personnage est tombé dans l'eau !");
            Die(); // Appelle la méthode Die
        }
    }

    void Die()
    {
        // Lance l'animation de mort
        if (animator != null)
        {
            animator.SetTrigger("Die");
        }

        // Réapparaît après un délai de 2 secondes (pour laisser jouer l'animation)
        Invoke(nameof(Respawn), 2f);
    }

    void Respawn()
    {
        if (respawnPoint != null)
        {
            Debug.Log("Le personnage réapparaît.");
            transform.position = respawnPoint.position; // Déplace le personnage au point de réapparition
        }
        else
        {
            Debug.LogError("Le point de réapparition (RespawnPoint) n'est pas assigné !");
        }
    }
}