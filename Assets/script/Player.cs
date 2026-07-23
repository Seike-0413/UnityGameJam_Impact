using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float MoveSpeed = 0.01f;

    public float JumpPower = 6.0f;


    Rigidbody m_rigidBody;
    void Start()
{
        // 自分にアタッチされているRigidBodyを取得する
        m_rigidBody = GetComponent<Rigidbody>();
}

void Update()
{
    // 移動速度を初期化
    Vector3 move = Vector3.zero;


    // 前後移動
    if (Input.GetKey(KeyCode.W))
    {
        move.z += MoveSpeed;
    }
    if (Input.GetKey(KeyCode.S))
    {
        move.z += -MoveSpeed;
    }
    // 左右移動
    if (Input.GetKey(KeyCode.D))
    {
        move.x += MoveSpeed;
    }
    if (Input.GetKey(KeyCode.A))
    {
        move.x += -MoveSpeed;
    }


    // 移動させる
    transform.position += move;
        // 回転
        if (move.sqrMagnitude > 0.0f)
        {
            transform.rotation = Quaternion.LookRotation(move.normalized);
        }
        // ジャンプ
        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_rigidBody.AddForce(new Vector3(0.0f, JumpPower, 0.0f),
                ForceMode.VelocityChange);
        }
    }
}
