using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerMovement : MonoBehaviour
{
    [Header("Individual")]
    public float speed = 1;
    public float dashForce = 2;

    public Rigidbody2D rb;
    public Animator anim;

    [Header("Joystick")]
    public FixedJoystick joystick;

    Vector2 Movement;
    Vector2 directionToEnemy;

    [Header("Dash")]
    public float dashSpeed;
    public float dashTime;
    private bool isDashing;
    [Header("Atack")]
    public float detectionRadius = 2;
    public GameObject enemy;
    public int[] damageDiapazone;

    void Start()
    {
        
    }

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
            if(CheckEnemy())
                StartCoroutine(Atack());
            else
                StartCoroutine(Dash());
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
        enemy.GetComponent<Enemy1>().GetDamage(Random.Range(damageDiapazone[0], damageDiapazone[1]));
        yield return new WaitForSeconds(0.1f);

        //Обнулення
        enemy = null;
        Movement = Vector2.zero;
        isDashing = false;
    }

    private bool CheckEnemy()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Enemy")) 
            {
                enemy = collider.gameObject;
                return true;
            }
        }
        return false;
    }
}
