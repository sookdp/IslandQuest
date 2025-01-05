using UnityEngine;

public class RotationObjet : MonoBehaviour
{
    // Vitesse de rotation (en degrés par seconde)
    public float vitesseRotation = 50f;

    // Sens de rotation (1 pour horaire, -1 pour anti-horaire)
    public int sensRotation = 1;

    // Axe de rotation
    public Vector3 axeRotation = Vector3.up;

    void Update()
    {
        // Calcul de la rotation
        float rotation = vitesseRotation * sensRotation * Time.deltaTime;

        // Appliquer la rotation autour de l'axe spécifié
        transform.Rotate(axeRotation * rotation);
    }
}
