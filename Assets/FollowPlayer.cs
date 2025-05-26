using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target; // Player1을 드래그해서 연결
    public Vector3 offset = new Vector3(0, 0, -10); // 카메라 기본 거리

    void LateUpdate()
    {
        if (target != null)
            transform.position = target.position + offset;
    }
}

