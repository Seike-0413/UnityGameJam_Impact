using System;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using System.Collections;

public class enemyScript : MonoBehaviour
{
    public void Damage(float damage)//
    {
        currentHP -= damage;
        hpBar.TakeDamage(damage);
        
        Debug.Log("Enemy HP : " + currentHP);
        
            if (currentHP <= 0)
        {
            Destroy(gameObject);
            Debug.Log("ゲームクリアー");
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameClear");
        }
    }

    public float MoveSpeed = 10.0f;
    public float rotateSpeed = 1.0f;
    public float stopDistance = 10.0f;
    public float attackDistance = 10.0f;
    public float attackInterval = 5.0f;

    public float maxHP = 300;
    private float currentHP;
    public BossHPBar hpBar;
    private bool isPreparingAttack = false;
    private bool attackLocked = false;

    public GameObject shockWavePrefab;
    public Transform attackPoint;
    public GameObject waterEffect;
    public GameObject warningCirclePrefab;

    private Transform player;
    private float attackTimer;

    Rigidbody m_rigidBody;
   
    void Start()
    {
            Debug.Log("Start");
            attackTimer = 0f;
        
        currentHP = maxHP;
        hpBar.currentHP = currentHP;
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
        //if(distance>stopDistance)
        //{
        //    //追いかける
        //    transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        //}
        //else
        //{
        //    //止まって攻撃
        //    attackTimer += Time.deltaTime;

        //    if(attackTimer>=attackInterval)
        //    {
        //        Attack();
        //        attackTimer = 0f;
        //    }
        //}
        if (distance > stopDistance && !isPreparingAttack)
        {
            //移動
            transform.position += 
                transform.forward
                * MoveSpeed 
                *Time.deltaTime;
        }
        else
        {
            //攻撃
            attackTimer += Time.deltaTime;
            if (attackTimer >= attackInterval && !isPreparingAttack)
            {
                isPreparingAttack = true;
                StartCoroutine(PrepareAttack());
                attackTimer = 0f;
            }
        }
    }
    
    void Attack()
    {
        Debug.Log("attack実行");
        Debug.Log(attackPoint.position);
        //衝撃波エフェクトを出す
        if (waterEffect != null)
        {
            int count = 36;

            for (int i = 0; i < count; i++)
            {
                float angle = i * Mathf.PI * 2 / count;
                Vector3 outerPos = transform.position +
                    new Vector3(
                        Mathf.Cos(angle) * attackDistance,
                        0,
                        Mathf.Sin(angle) * attackDistance
                        );
                Instantiate(waterEffect, outerPos, Quaternion.identity);
                Vector3 pos = transform.position +
                    new Vector3(
                        Mathf.Cos(angle) * (attackDistance*0.5f),
                        0,
                        Mathf.Sin(angle) * (attackDistance*0.5f)
                    );

                Instantiate(waterEffect, pos, Quaternion.identity);
                Collider[] hits = Physics.OverlapSphere(pos, 5f);

                foreach (Collider hit in hits)
                {
                    if (hit.CompareTag("Player"))
                    {
                        Debug.Log("プレイヤー発見");
                        Player player = 
                        hit.GetComponentInParent<Player>();

                        if (player != null)
                        {
                            player.TakeDamage(10);
                        }
                    }
                }
            }
        }
    }
    IEnumerator PrepareAttack()
    {
        Debug.Log("準備開始");
        //isPreparingAttack = true;
        float originalSpeed = MoveSpeed;
        MoveSpeed = 0f;
        Instantiate(
             warningCirclePrefab,
             transform.position,
             Quaternion.identity
             );
        yield return new WaitForSeconds(2f);
        Debug.Log("攻撃!");
        Attack();
        MoveSpeed = originalSpeed;
        //attackLocked = false;
        isPreparingAttack = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(
        transform.position, attackDistance);
    }
}
