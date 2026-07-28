//using UnityEngine;
//using UnityEngine.SceneManagement;

//public class Title : MonoBehaviour
//{
//    public void StartGame()
//    {
//        SceneManager.LoadScene("SampleScene");
//    }
//    // Start is called once before the first execution of Update after the MonoBehaviour is created
//    public void Start()
//    {

//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.Space))
//        {
//            Debug.Log("Spaceキーが押された");
//            StartGame();
//            //SceneManager.LoadScene("SampleScene");
//        }
//        // コントローラーの決定ボタンでスタート
//        if (Input.GetButtonDown("Submit"))
//        {
//            Debug.Log("コントローラーが押された");
//            StartGame();
//        }
//    }

//}
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Title : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    void Update()
    {
        // Spaceキー
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Debug.Log("Spaceキーが押された");
            StartGame();
        }

        // コントローラー Aボタン（PSなら×）
        if (Gamepad.current != null && Gamepad.current.buttonSouth.wasPressedThisFrame)
        {
            Debug.Log("Aボタンが押された");
            StartGame();
        }
    }
}
