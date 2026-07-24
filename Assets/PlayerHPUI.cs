using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHPUI : MonoBehaviour
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
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);

        UpdateHP();
    }

    void UpdateHP()
    {
        hpBar.maxValue = maxHP;
        hpBar.value = currentHP;

        hpText.text = currentHP + " / " + maxHP;
    }
}