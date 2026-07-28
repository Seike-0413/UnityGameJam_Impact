using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHP : MonoBehaviour
{
    public Slider hpBar;
    public TextMeshProUGUI hpText;

    public int maxHP = 100;
    int hp;

    void Start()
    {
        Damage(20);
        hp = maxHP;
        UpdateHP();
    }

    public void Damage(int damage)
    {
        hp -= damage;

        if (hp < 0)
            hp = 0;

        UpdateHP();
    }

    void UpdateHP()
    {
        hpBar.value = hp;
        hpText.text = hp + " / " + maxHP;
    }
}