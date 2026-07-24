
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    // 接地しているかを格納する変数
    bool m_isGround;
    // 地面に触れているかを返す関数
    public bool GetIsGround()
    {
        return m_isGround;
    }


    // 毎フレーム最初に接地判定をリセットする
    private void FixedUpdate()
    {
        m_isGround = false;
    }


    // 自身に何かが衝突している間呼ばれる
    private void OnTriggerStay(Collider other)
    {
        // 地面のタグが付いたオブジェクトに衝突している
        if (other.CompareTag("Ground"))
        {
            m_isGround = true;
        }
    }


}