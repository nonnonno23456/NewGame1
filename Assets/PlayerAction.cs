using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public float speed = 5f; // 기본 속도 값 설정 (원한다면 Inspector에서 조절 가능)

    public Rigidbody2D player1;
    public Rigidbody2D player2;
    
    
    float h1, v1;
    float h2, v2;
    bool isHorizonMove1 = true;
    bool isHorizonMove2 = true;

    

    void Update()
    {
        // Player 1 (WASD)
        h1 = 0;
        v1 = 0;
        
        if (Input.GetKey(KeyCode.A))
            h1 = -1;
        else if (Input.GetKey(KeyCode.D))
            h1 = 1;

        if (h1 == 0)
        {
            if (Input.GetKey(KeyCode.W))
                v1 = 1;
            else if (Input.GetKey(KeyCode.S)) 
                v1 = -1;
        }

        bool h1Down = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D);
        bool v1Down = Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S);
        
        if (h1Down) 
            isHorizonMove1 = true;
        else if (v1Down) 
            isHorizonMove1 = false;

        
        // Player 2 (Arrow Keys)
        h2 = 0;
        v2 = 0;
        
        if (Input.GetKey(KeyCode.LeftArrow))
            h2 = -1;
        else if (Input.GetKey(KeyCode.RightArrow))
            h2 = 1;

        if (h2 == 0)
        {
            if (Input.GetKey(KeyCode.UpArrow)) v2 = 1;
            else if (Input.GetKey(KeyCode.DownArrow)) v2 = -1;
        }

        bool h2Down = Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow);
        bool v2Down = Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow);
        
        if (h2Down)
            isHorizonMove2 = true;
        else if (v2Down)
            isHorizonMove2 = false;
    }

    void FixedUpdate()
    {
        // Player 1 Movement
        Vector2 moveVec1 = isHorizonMove1 ? new Vector2(h1, 0) : new Vector2(0, v1);
        player1.linearVelocity = moveVec1 * speed;

        // Player 2 Movement
        Vector2 moveVec2 = isHorizonMove2 ? new Vector2(h2, 0) : new Vector2(0, v2);
        player2.linearVelocity = moveVec2 * speed;
    }
}