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
    public bool facingRight = true;
    [SerializeField]public Animator animator;

    [SerializeField] public float runSpeed = 0.1f;

    void Start ()
    {
       body = GetComponent<Rigidbody2D>(); 
    }
    Vector2 mvmnt;

    private void Update()
    {
        if (status)
        {
            mvmnt.x = Input.GetAxisRaw("Horizontal");
            mvmnt.y = Input.GetAxisRaw("Vertical");
            if(mvmnt.x > 0 && !facingRight)
                Flip();
            else if(mvmnt.x < 0 && facingRight)
                Flip();
            animator.SetFloat("horizontal", mvmnt.x);
            animator.SetFloat("vertical", mvmnt.y);
            animator.SetFloat("velocity", mvmnt.sqrMagnitude);
        }
    }
    void FixedUpdate()
    {
            body.MovePosition(body.position + (mvmnt * runSpeed));
    }
    void Flip ()
    {
        facingRight = !facingRight;
        Vector3 thisScale = transform.localScale;
        thisScale.x *= -1;
        transform.localScale = thisScale;
    }  
}
