using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public float speed = 7f; // 기본 속도 값 설정 (원한다면 Inspector에서 조절 가능)
    public int hp = 1;

    Rigidbody2D player2;
    Animator anim2;
    SpriteRenderer p2Flip;
    float h2, v2;
    bool isHorizonMove2 = true;
    bool isMoving2 = false;
    bool isDead = false;
    KeyCode lastKeyPressed2 = KeyCode.None;

    
    void Awake()
    {
        player2 = GetComponent<Rigidbody2D>();
        anim2 = GetComponent<Animator>();
        p2Flip = GetComponent<SpriteRenderer>();
    }
  

    void Update()
    {
        if (GameManager.isPaused)
            return;
        h2 = 0;
        v2 = 0;

        // ▼ 최근에 누른 키 기록
        if (Input.GetKeyDown(KeyCode.UpArrow)) lastKeyPressed2 = KeyCode.UpArrow;
        if (Input.GetKeyDown(KeyCode.DownArrow)) lastKeyPressed2 = KeyCode.DownArrow;
        if (Input.GetKeyDown(KeyCode.LeftArrow)) lastKeyPressed2 = KeyCode.LeftArrow;
        if (Input.GetKeyDown(KeyCode.RightArrow)) lastKeyPressed2 = KeyCode.RightArrow;

        // ▼ 현재 키 입력 상태
        bool isUp = Input.GetKey(KeyCode.UpArrow);
        bool isDown = Input.GetKey(KeyCode.DownArrow);
        bool isLeft = Input.GetKey(KeyCode.LeftArrow);
        bool isRight = Input.GetKey(KeyCode.RightArrow);

        // ▼ 이동 값 결정
        if (isLeft) h2 = -1;
        else if (isRight) h2 = 1;

        if (isUp) v2 = 1;
        else if (isDown) v2 = -1;

        // ▼ 방향 우선순위 적용
        if (isLeft || isRight || isUp || isDown)
        {
            // 마지막 누른 키가 아직 눌려 있다면 그것 기준
            if (lastKeyPressed2 == KeyCode.LeftArrow || lastKeyPressed2 == KeyCode.RightArrow)
                isHorizonMove2 = true;
            else if (lastKeyPressed2 == KeyCode.UpArrow || lastKeyPressed2 == KeyCode.DownArrow)
                isHorizonMove2 = false;

            // 만약 마지막 누른 키가 떼졌다면 → 다른 키 기준으로 다시 판단
            if (!Input.GetKey(lastKeyPressed2))
            {
                if (isLeft || isRight) isHorizonMove2 = true;
                else if (isUp || isDown) isHorizonMove2 = false;
            }
        }

        // ▼ 좌우 반전 처리
        if (h2 < 0) p2Flip.flipX = true;
        else if (h2 > 0) p2Flip.flipX = false;

        // ▼ 애니메이션
        isMoving2 = (h2 != 0 || v2 != 0);
        anim2.SetBool("isMoving2", isMoving2);

        if (hp <= 0)
            Invoke("destroy_self", 0.1f);
    }



    void FixedUpdate()
    {
        if (!isDead)
        {
            // Player 2 Movement
            Vector2 moveVec2 = isHorizonMove2 ? new Vector2(h2, 0) : new Vector2(0, v2);
            player2.linearVelocity = moveVec2 * speed;
        }


    }


    public void takeDamage(int damage)
    {
        hp -= damage;
        
    }
    
    public void destroy_self()
    {
        isDead = true;
        anim2.SetBool("isDead", isDead);
        player2.linearVelocity = Vector2.zero;
    }
    
    public bool getIsDead()
    {
        return isDead;
    }
}