
    using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    public Image hpBar;

    public float maxHP = 100;
    public float currentHP = 100;

    void Start()
    {
        hpBar.fillAmount = 1;
    }

    public void Damage(float damage)
    {
        currentHP -= damage;

        if (currentHP < 0)
            currentHP = 0;

        hpBar.fillAmount = currentHP / maxHP;
    }
}
