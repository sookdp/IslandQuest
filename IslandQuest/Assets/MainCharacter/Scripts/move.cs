using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float speed = 6f; // Vitesse de déplacement
    public float jumpSpeed = 8f;
    public float gravity = 20f;
    private Vector3 moveD = Vector3.zero;
    CharacterController Cac;
   
    void Start()
    {
        Cac = GetComponent<CharacterController>();
        
    }

    void Update()
    {
        if(Cac.isGrounded){
            moveD = new Vector3(0, 0, Input.GetAxis("Vertical"));
            moveD = transform.TransformDirection(moveD);
            moveD *= speed;

            if(Input.GetButton("Jump")){
                moveD.y = jumpSpeed;
            }
            else {
            moveD.y = -0.5f; // Une petite valeur pour maintenir le personnage au sol quand il est au sol
            }
        } 
        else {
            moveD.y -= gravity * Time.deltaTime; // Appliquer la gravité uniquement si le personnage n'est pas au sol
        }
        transform.Rotate (Vector3.up * Input.GetAxis("Horizontal")*Time.deltaTime * speed * 10);

        Cac.Move(moveD*Time.deltaTime);
        
    }
}