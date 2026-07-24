using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;      // プレイヤー
    public Vector3 offset;         // カメラとの距離

    void LateUpdate()
    {
        if (target != null)
        {
            transform.position = target.position + offset;
            transform.LookAt(target);
        }
    
    }
}