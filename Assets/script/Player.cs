using MathNet.Numerics.Optimization.ObjectiveFunctions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float MoveSpeed = 0.01f;

    public float JumpPower = 6.0f;

    public int HP = 100;

    Rigidbody m_rigidBody;
    GameObject m_mainCamera;
    void Start()
{
        // 自分にアタッチされているRigidBodyを取得する
        m_rigidBody = GetComponent<Rigidbody>();

        //メインカメラのゲームオブジェクトを取得する
        m_mainCamera = Camera.main.gameObject;
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

        //カメラを考慮した移動
        Vector3 PlayerMove = Vector3.zero;

        Vector3 forward = m_mainCamera.transform.forward;
        Vector3 right = m_mainCamera.transform.right;
        forward.y = 0.0f;
        right.y = 0.0f;
        right *= move.x;
        forward*= move.z;
        //移動速度に上記で計算したベクトルを加算する
        PlayerMove += right +forward;
        //移動させる
        transform.position += PlayerMove * Time.deltaTime;

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

    public void TakeDamage(int damage)
    {
        HP -= damage;

        Debug.Log("プレイヤーHP：" + HP);

        if (HP <= 0)
        {
            Debug.Log("ゲームオーバー");
        }
    }
}
