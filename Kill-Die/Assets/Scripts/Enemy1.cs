using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public int HP;
    public Animator anim;

    public GameObject damageViz;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetDamage(int damage)
    {
        HP -= damage;
        VizualizateDamage(damage);
        if (HP < 0)
            StartCoroutine(Death());
        else
            anim.SetTrigger("Hit");
    }

    void VizualizateDamage(int damage)
    {
        GameObject damageText = Instantiate(damageViz, transform.position, Quaternion.identity);
        damageText.GetComponentInChildren<TextMeshProUGUI>().text = damage.ToString();
        damageText.GetComponent<Rigidbody2D>().velocity = transform.up * 10f;
        // Задаємо анімацію зникнення
        Destroy(damageText, 0.2f);
    }

    IEnumerator Death()
    {
        anim.SetTrigger("Death");
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }
}
