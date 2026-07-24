using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Spaceキーが押された");
            SceneManager.LoadScene("SampleScene");
        }
    }
}
