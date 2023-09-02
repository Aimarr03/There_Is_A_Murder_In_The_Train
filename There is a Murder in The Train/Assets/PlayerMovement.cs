using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;
    float vertical;
    public bool status = true;

    [SerializeField] public float runSpeed = 20.0f;

    void Start ()
    {
       body = GetComponent<Rigidbody2D>(); 
    }


    private void Update()
    {
        if (status)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
            body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
        }
    }  
}
