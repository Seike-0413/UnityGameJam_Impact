using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHP : MonoBehaviour
{
    public Slider hpBar;
    public TMP_Text hpText;

    public int maxHP = 100;
    private int currentHP;

    void Start()
    {
        currentHP = maxHP;
        UpdateHP();
    }

    public void Damage(int damage)
    {
        currentHP -= damage;

        if (currentHP < 0)
            currentHP = 0;

        UpdateHP();
    }

    void UpdateHP()
    {
        hpBar.maxValue = maxHP;
        hpBar.value = currentHP;
        hpText.text = currentHP + " / " + maxHP;
    }
}
