using System;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    public float MoveSpeed = 10.0f;
    public float rotateSpeed = 1.0f;
    public float stopDistance = 10.0f;
    public float attackDistance = 10.0f;
    public float attackInterval = 5.0f;

    public float maxHP = 300;

    public GameObject shockWavePrefab;
    public Transform attackPoint;

    private Transform player;
    private float attackTimer;

    Rigidbody m_rigidBody;
   
    void Start()
    {
        //自分にアタッチされているRigidBodyを取得する
        m_rigidBody = GetComponent<Rigidbody>();

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
                attackTimer = 3.0f;
            }
        }

        //enemyUI();

    }
    
    void Attack()
    {
        Debug.Log("attack実行");

        //衝撃波エフェクトを出す
        //Instantiate(
        //           shockWavePrefab,
        //           attackPoint.position,
        //           Quaternion.identity
        //           );

        //範囲内の検索
        Collider[] hitPlayers = Physics.OverlapSphere(
            transform.position, attackDistance);
        foreach(Collider hit in hitPlayers)
        {
            if(hit.CompareTag("Player"))
            {
                Player player = hit.GetComponent<Player>();

                if (player != null)
                {
                    player.TakeDamage(10);
                }
            }
        }

    }


    //private void OnDrawGizmosSelected()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(transform.position, attackDistance);
    //}

    //private void OnDrawGizmosSelected()
    //    {if (attackPoint == null) return;
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(attackPoint.position,attackDistance);
    //}

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(
        transform.position, attackDistance);
    }

//public void enemyUI()
//    {

    //    }
}
