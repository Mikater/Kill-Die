using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1;
    public float dashForce = 2;

    public Rigidbody2D rb;
    public Animator anim;

    public FixedJoystick joystick;

    Vector2 Movement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // input
        Movement.x = Input.GetAxisRaw("Horizontal");
        Movement.y = Input.GetAxisRaw("Vertical");
        //Movement = joystick.Direction;

        if (Movement.sqrMagnitude > 0.01)
            anim.SetBool("Run", true);
        else
            anim.SetBool("Run", false);

        anim.SetFloat("Horizontal", Movement.x);
        anim.SetFloat("Vertical", Movement.y);
    }

    public void Dash()
    {
        rb.AddForce(Movement * dashForce, ForceMode2D.Impulse);
    }

    private void FixedUpdate()
    {
        // Movement
        rb.MovePosition(rb.position + Movement * speed * Time.fixedDeltaTime);
    }
}
