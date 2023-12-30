using System.Collections;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.Rendering.Universal;

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

    [Header("Attack")]
    public float detectionRadius = 2;
    public GameObject enemy;
    public int[] damageDiapazone;

    [Header("Light")]
    public Light2D playerLight;

    void Update()
    {
        if (!isDashing)
        {
            Movement.x = Input.GetAxisRaw("Horizontal");
            Movement.y = Input.GetAxisRaw("Vertical");
        }

        if (Movement.sqrMagnitude > 0.01)
        {
            anim.SetBool("Run", true);

            // Обчислення кута обертання світла
            float angle = Mathf.Atan2(Movement.y, Movement.x) * Mathf.Rad2Deg;

            // Оптимізація для правильного обертання усіх напрямків
            angle -= 90f;

            playerLight.transform.rotation = Quaternion.Slerp(playerLight.transform.rotation, Quaternion.Euler(0, 0, angle), Time.deltaTime * 5f);
        }
        else
        {
            anim.SetBool("Run", false);
        }

        anim.SetFloat("Horizontal", Movement.x);
        anim.SetFloat("Vertical", Movement.y);
    }

    private void FixedUpdate()
    {
        if (!isDashing)
        {
            rb.MovePosition(rb.position + Movement * speed * Time.fixedDeltaTime);
        }
        else
        {
            rb.MovePosition(rb.position + Movement * dashSpeed * Time.fixedDeltaTime);
        }
    }

    public void AttackButtonClick()
    {
        if (!isDashing)
        {
            if (CheckEnemy())
            {
                StartCoroutine(Attack());
            }
            else
            {
                StartCoroutine(Dash());
            }
        }
    }

    IEnumerator Dash()
    {
        anim.SetTrigger("Dash");
        isDashing = true;
        yield return new WaitForSeconds(dashTime);
        isDashing = false;
    }

    IEnumerator Attack()
    {
        directionToEnemy = enemy.transform.position - transform.position;
        Movement = directionToEnemy.normalized;
        isDashing = true;

        anim.SetTrigger("Attack");
        enemy.GetComponent<Enemy1>().GetDamage(Random.Range(damageDiapazone[0], damageDiapazone[1]));
        yield return new WaitForSeconds(0.1f);

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
