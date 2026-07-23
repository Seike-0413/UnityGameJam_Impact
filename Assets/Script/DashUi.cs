using UnityEngine;
using UnityEngine.UI;

public class DashUI : MonoBehaviour
{
    public Slider dashBar;

    public float maxDash = 100f;
    public float currentDash;

    void Start()
    {
        currentDash = maxDash;
        dashBar.maxValue = maxDash;
        dashBar.value = currentDash;
    }

    void Update()
    {
        // Shiftを押している間ダッシュを消費
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentDash -= 20f * Time.deltaTime;
        }
        else
        {
            // 離すと回復
            currentDash += 10f * Time.deltaTime;
        }

        currentDash = Mathf.Clamp(currentDash, 0, maxDash);
        dashBar.value = currentDash;
    }
}