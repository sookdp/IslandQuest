using UnityEngine;

public class RamasserObjet : MonoBehaviour
{
    // Référence au composant AudioSource de l'objet
    private AudioSource audioSource;

    // Lorsque l'objet entre en collision avec un autre objet ayant un collider marqué comme "trigger"
    private void Start()
    {
        // Récupérer le composant AudioSource attaché à l'objet
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Vérifier si l'objet qui entre en collision est le joueur
        if (other.CompareTag("Player"))
        {


            // Rendre l'objet invisible (il ne sera pas détruit immédiatement)
            Renderer renderer = GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.enabled = false;
            }

            // Jouer le son de ramassage
            audioSource.Play();

            // Attendre la fin du son (en secondes) avant de détruire l'objet
            Destroy(gameObject, audioSource.clip.length);
        }
    }
}