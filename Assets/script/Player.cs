

using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("Animator")]
    [SerializeField]
    private Animator animator;

    public GameObject unitychan;


    [Header("移動")]
    public float MoveSpeed = 3.0f;

    public float RotateSpeed = 10.0f;


    [Header("ジャンプ")]
    public float JumpPower = 6.0f;


    [Header("HP")]
    public int HP = 200;


    private Rigidbody m_rigidBody;
    private GameObject m_mainCamera;


    private bool IsGround = false;



    //========================
    // 初期化
    //========================
    void Start()
    {
        m_rigidBody = GetComponent<Rigidbody>();


        m_mainCamera = Camera.main.gameObject;


        if (unitychan != null)
        {
            animator = unitychan.GetComponent<Animator>();
        }


        if (animator == null)
        {
            Debug.LogError("Animatorがありません");
        }
    }




    //========================
    // 毎フレーム
    //========================
    void Update()
    {
        if (Gamepad.current == null)
            return;


        Move();

        Rotate();

        UpdateAnimator();

        Jump();
    }




    //========================
    // 移動
    //========================
    void Move()
    {
        Vector2 input =
            Gamepad.current.leftStick.ReadValue();



        Vector3 forward =
            m_mainCamera.transform.forward;


        Vector3 right =
            m_mainCamera.transform.right;



        forward.y = 0;
        right.y = 0;


        forward.Normalize();
        right.Normalize();



        Vector3 direction =
            forward * input.y +
            right * input.x;



        transform.position +=
            direction *
            MoveSpeed *
            Time.deltaTime;
    }




    //========================
    // 回転
    //========================
    void Rotate()
    {
        Vector2 input =
            Gamepad.current.leftStick.ReadValue();



        Vector3 forward =
            m_mainCamera.transform.forward;


        Vector3 right =
            m_mainCamera.transform.right;



        forward.y = 0;
        right.y = 0;


        forward.Normalize();
        right.Normalize();



        Vector3 direction =
            forward * input.y +
            right * input.x;



        if (direction.sqrMagnitude > 0.001f)
        {
            Quaternion targetRotation =
                Quaternion.LookRotation(direction);



            transform.rotation =
                Quaternion.Lerp(
                    transform.rotation,
                    targetRotation,
                    RotateSpeed *
                    Time.deltaTime
                );
        }
    }




    //========================
    // Animator
    //========================
    void UpdateAnimator()
    {
        {
            if (animator == null)
            {
                Debug.LogError("Animatorがありません");
                return;
            }

            // 左スティック入力
            Vector2 input =
                Gamepad.current.leftStick.ReadValue();


            // スティックの倒し具合
            float speed =
                input.magnitude;


            // MoveSpeedに値を渡す
            animator.SetFloat(
                "MoveSpeed",
                speed
            );


            // LTを押している間はAim
            bool isAim =
                Gamepad.current.leftTrigger.isPressed;


            // IsAimに値を渡す
            animator.SetBool(
                "isAim",
                isAim
            );
          
            if (Gamepad.current.leftTrigger.isPressed)
            {
                animator.Play("Aim");
            }
        }
    }



    //========================
    // ジャンプ
    //========================
    void Jump()
    {
        if (!IsGround)
            return;



        if (Gamepad.current.buttonSouth.wasPressedThisFrame)
        {
            m_rigidBody.AddForce(
                Vector3.up *
                JumpPower,
                ForceMode.VelocityChange
            );


            if (animator != null)
            {
                animator.SetTrigger("Jump");
            }
        }
    }




    //========================
    // 接地判定
    //========================
    private void OnCollisionStay(Collision collision)
    {
        IsGround = true;
    }



    private void OnCollisionExit(Collision collision)
    {
        IsGround = false;
    }




    //========================
    // ダメージ
    //========================
    public void TakeDamage(int damage)
    {
        HP -= damage;


        Debug.Log(
            "Player HP : " + HP
        );


        if (HP <= 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(
                "Gameover"
            );
        }
    }
}