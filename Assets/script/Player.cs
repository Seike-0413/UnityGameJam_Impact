using MathNet.Numerics.Optimization.ObjectiveFunctions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float MoveSpeed = 1.0f;

    public float JumpPower = 6.0f;

    public int HP = 100;

    bool IsGround = false;

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
        if (Gamepad.current == null) return;
        Debug.Log(m_mainCamera.transform.forward);

        // 移動速度を初期化
        Vector3 move = Vector3.zero;

        Vector2 moveInput = Gamepad.current.leftStick.ReadValue();

        //move.x = moveInput.x * MoveSpeed;
        //move.z = moveInput.y * MoveSpeed;

        ////カメラを考慮した移動
        //Vector3 PlayerMove = Vector3.zero;

        Vector3 forward = m_mainCamera.transform.forward;
        Vector3 right = m_mainCamera.transform.right;
        forward.y = 0.0f;
        right.y = 0.0f;
        forward.Normalize();
        right.Normalize();
        Vector3 PlayerMove = forward * moveInput.y + right * moveInput.x;

        ////移動速度に上記で計算したベクトルを加算する
        //PlayerMove = right * move.x + forward * move.z;
        ////移動させる
        //if (PlayerMove.magnitude > 1.0f)
        //{
        //    PlayerMove.Normalize();
        //}

        transform.position += PlayerMove * MoveSpeed * Time.deltaTime;

        if (PlayerMove.magnitude > 1.0f)
        {
            if (PlayerMove.magnitude > 1.0f) ;
        }

            //// 移動させる
            //transform.position += move;
            // 回転
            if (PlayerMove.sqrMagnitude > 0.001f) ;
        {
            transform.rotation = Quaternion.LookRotation(PlayerMove);
        }
        //// ジャンプ
        //if (Gamepad.current.buttonSouth.wasPressedThisFrame)
        //{
        //    m_rigidBody.AddForce(
        //        Vector3.up * JumpPower,
        //        ForceMode.Impulse
        //    );
        //}
        if (IsGround &&
    Gamepad.current.buttonSouth.wasPressedThisFrame)
        {
            m_rigidBody.AddForce(
                new Vector3(0.0f, JumpPower, 0.0f),
                ForceMode.VelocityChange
            );
        }

    }
    private void OnCollisionStay(Collision collision)
    {
        IsGround = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        IsGround = false;
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
