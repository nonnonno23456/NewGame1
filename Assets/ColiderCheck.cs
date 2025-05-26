using System;
using UnityEngine;

public class ColiderCheck : MonoBehaviour
{
    [SerializeField] private Bomb bomb;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
            bomb.FireExplode();
    }
}
