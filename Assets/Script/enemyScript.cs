using System;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    public float MoveSpeed = 10.0f;
    public float rotateSpeed = 1.0f;
    public float stopDistance = 10.0f;
    public float attackDistnance = 10.0f;
    public float attackInterval = 2.0f;

    private Transform player;
    private float attackTimer;

    Rigidbody m_rigidBody;
    //Animation m_enemyAnimatior;

    //設置判定用スクリプト
    //public GroundChecker Ground_Checker;

    //bool m_moveFlag,m_jumpFlag,m_airFlag;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //自分にアタッチされているRigidBodyを取得する
        m_rigidBody = GetComponent<Rigidbody>();
        //自分にアタッチされているAnimationを取得する
        //m_enemyAnimation=GetComponent<Animation>();

        player = GameObject.FindGameObjectWithTag("Player").transform;
    
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = new Vector3(
             player.position.x,
             transform.position.y,
             player.position.z);

        //プレイヤーの方向を向く
        Vector3 direction = (target - transform.position).normalized;

        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                rotateSpeed * Time.deltaTime
                );
        }

        //前進する
        //transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        float distance = Vector3.Distance(transform.position, player.position);
        if(distance>stopDistance)
        {
            //追いかける
            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        }
        else
        {
            //止まって攻撃
            attackTimer += Time.deltaTime;

            if(attackTimer>=attackInterval)
            {
                Attack();
                attackTimer = 0;
            }
        }
        

        //if(target == Vector3.zero)
        //{
        //    MoveSpeed = 0;
        //    rotateSpeed = 0;
        //}

        enemyUI();

        //transform.position = Vector3.MoveTowards(
        //    transform.position,
        //    target,
        //    MoveSpeed * Time.deltaTime);

        //transform.LookAt(target);

    }
    
    void Attack()
    {

    }
    public void enemyUI()
    {

    }
}
