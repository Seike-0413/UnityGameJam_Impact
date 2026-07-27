using UnityEngine;
using UnityEngine.UI;

public class BossHPBar : MonoBehaviour
{
    public Image fillImage;

    public float maxHP = 300;
    public float currentHP = 300;

    void Update()
    {
        fillImage.fillAmount = currentHP / maxHP;
    }

    public void TakeDamage(float damage)
    {
        currentHP -= damage;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);
    }
}