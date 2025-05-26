using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    public float speed = 7f; // 기본 속도 값 설정 (원한다면 Inspector에서 조절 가능)
    public int hp = 1;

    Rigidbody2D player1;
    Animator anim1;
    float h1, v1;
    bool isHorizonMove1 = true;
    bool isMoving1 = false;
    bool isDead = false;
    SpriteRenderer p1Flip;
    KeyCode lastKeyPressed = KeyCode.None;

    void Awake()
    {
        player1 = GetComponent<Rigidbody2D>();
        anim1 = GetComponent<Animator>();
        p1Flip = GetComponent<SpriteRenderer>();
    }



   void Update()
   {
       if (GameManager.isPaused)
           return;
       h1 = 0;
       v1 = 0;

       // ▼ 최근에 눌린 키 추적
       if (Input.GetKeyDown(KeyCode.W)) lastKeyPressed = KeyCode.W;
       if (Input.GetKeyDown(KeyCode.S)) lastKeyPressed = KeyCode.S;
       if (Input.GetKeyDown(KeyCode.A)) lastKeyPressed = KeyCode.A;
       if (Input.GetKeyDown(KeyCode.D)) lastKeyPressed = KeyCode.D;

       // ▼ 키 입력 상태 파악
       bool isW = Input.GetKey(KeyCode.W);
       bool isS = Input.GetKey(KeyCode.S);
       bool isA = Input.GetKey(KeyCode.A);
       bool isD = Input.GetKey(KeyCode.D);

       // ▼ 방향값 세팅
       if (isA) h1 = -1;
       else if (isD) h1 = 1;

       if (isW) v1 = 1;
       else if (isS) v1 = -1;

       // ▼ 방향 우선순위 결정
       if ((isA || isD || isW || isS))
       {
           // 나중에 누른 키가 아직 눌려있으면 그것 기준
           if (lastKeyPressed == KeyCode.A || lastKeyPressed == KeyCode.D)
               isHorizonMove1 = true;
           else if (lastKeyPressed == KeyCode.W || lastKeyPressed == KeyCode.S)
               isHorizonMove1 = false;

           // 만약 마지막에 누른 키를 뗐으면 → 남은 키 기준으로 다시 전환
           if (!Input.GetKey(lastKeyPressed))
           {
               if (isA || isD) isHorizonMove1 = true;
               else if (isW || isS) isHorizonMove1 = false;
           }
       }

       // ▼ 반전 처리
       if (h1 < 0) p1Flip.flipX = true;
       else if (h1 > 0) p1Flip.flipX = false;

       // ▼ 애니메이션
       isMoving1 = (h1 != 0 || v1 != 0);
       anim1.SetBool("isMoving1", isMoving1);

       if (hp <= 0)
           Invoke("destroy_self", 0.1f);
   }

    void FixedUpdate()
    {
        if (!isDead)
        {
            // Player 1 Movement
            Vector2 moveVec1 = isHorizonMove1 ? new Vector2(h1, 0) : new Vector2(0, v1);
            player1.linearVelocity = moveVec1 * speed;
        }

    }


    public void takeDamage(int damage)
    {
        hp -= damage;
        
    }

    public void destroy_self()
    {
        isDead = true;
        anim1.SetBool("isDead", isDead);
        player1.linearVelocity = Vector2.zero;
    }

    public bool getIsDead()
    {
        return isDead;
    }
    
    
}