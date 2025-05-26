using UnityEngine;

public class FakeBomb : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("충돌: " + col.gameObject.name);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("트리거 충돌: " + col.gameObject.name);
    }

}
