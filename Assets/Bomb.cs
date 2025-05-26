using System;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private float explosionRadius = 2.5f;
    public int hp = 1;
    public float delay_time = 1.15f;
    LayerMask layerMask;
    public AudioSource fireAudio;
    public AudioSource explodeAudio;


    
    int damage = 1;
    bool isFired = false;
    bool isBombed = false;
    private Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("isFired", isFired);
        layerMask = LayerMask.GetMask("Player","Bomb");
        
    }


    public void FireExplode()
    {
        isFired = true;
        if (isFired)
        {
            fireAudio.time = 1.0f;
            fireAudio.Play();
        }

        anim.SetBool("isFired", isFired);
        Invoke("Explode", delay_time);
        

    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }

    


    private void Explode()
    {
        anim.SetBool("isBombed",true);


        Collider2D[] targets = Physics2D.OverlapCircleAll(transform.position, explosionRadius, layerMask);


        foreach (Collider2D target in targets)
        {

            Player1 player1 = target.GetComponent<Player1>();
            if (player1 != null)
            {
                player1.takeDamage(damage);
            }
            
            Player2 player2 = target.GetComponent<Player2>();
            if (player2 != null)
            {
                player2.takeDamage(damage);
            }

            // 다른 폭탄에게도 데미지 
            Bomb bomb = target.GetComponent<Bomb>();
            if (bomb != null)
            {
                bomb.takeDamage(damage);
            }

        }
        explodeAudio.Play();
        Invoke("Set_bool", delay_time-0.5f);
       
    }

    void takeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0 && !isFired)
        {
            FireExplode();
        }
    }

    void Set_bool()
    {
        anim.SetBool("isExplode", true);
        explodeAudio.Play();
    }



}
