using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHPUI : MonoBehaviour
{
    public Slider hpBar;
    public TMP_Text hpText;

    public Player player;

    //public int maxHP = 100;
    //private int currentHP;

    //void Start()
    //{
    //    currentHP = maxHP;
    //    UpdateHP();
    //}

    //public void Damage(int damage)
    //{
    //    currentHP -= damage;
    //    currentHP = Mathf.Clamp(currentHP, 0, maxHP);

    //    UpdateHP();
    //}

    void Update()
    {
        hpBar.maxValue = 100;
        hpBar.value = player.HP;
        
        hpText.text = player.HP + " / 100";
    }
}