using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public int HP;
    public Animator anim;

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
        VizualizateDamage();
        if (HP < 0)
            StartCoroutine(Death());
        else
            anim.SetTrigger("Hit");
    }

    void VizualizateDamage()
    {
        return;
    }

    IEnumerator Death()
    {
        anim.SetTrigger("Death");
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }
}
