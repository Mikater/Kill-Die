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
    Vector2 directionToEnemy;

    public float dashSpeed;
    public float dashTime;
    private bool isDashing;

    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // input
        if (!isDashing)
        {
            Movement.x = Input.GetAxisRaw("Horizontal");
            Movement.y = Input.GetAxisRaw("Vertical");
        }
        //Movement = joystick.Direction;

        if (Movement.sqrMagnitude > 0.01)
            anim.SetBool("Run", true);
        else
            anim.SetBool("Run", false);

        anim.SetFloat("Horizontal", Movement.x);
        anim.SetFloat("Vertical", Movement.y);
    }

    public void AtackButtonClick()
    {
        if (!isDashing)
        {
            //StartCoroutine(Dash());
            StartCoroutine(Atack());
        }
    }

    private void FixedUpdate()
    {
        // Movement
        if(!isDashing)
            rb.MovePosition(rb.position + Movement * speed * Time.fixedDeltaTime);
        else
            rb.MovePosition(rb.position + Movement * dashSpeed * Time.fixedDeltaTime);
    }

    IEnumerator Dash()
    {
        anim.SetTrigger("Dash");
        isDashing = true;
        yield return new WaitForSeconds(dashTime);
        isDashing = false;
    }

    IEnumerator Atack()
    {
        // Беремо напрям до енемі
        directionToEnemy = enemy.transform.position - transform.position;
        // стрибок
        Movement = directionToEnemy.normalized;
        isDashing = true;

        anim.SetTrigger("Atack");
        yield return new WaitForSeconds(0.1f);
        Movement = Vector2.zero;
        isDashing = false;
    }
}
