using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHPUI : MonoBehaviour
{
    //public Slider hpBar;
    //public TMP_Text hpText;
    //public Player player;

    public float maxHP = 100;
    public float currentHP=100;
    public Slider hpSlider;
    public Player player;

    //public Image fillImage;
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
    void Start()
    {
        hpSlider.maxValue = player.HP;
        hpSlider.value = player.HP;
    }

    void Update()
    {
        //hpBar.maxValue = 100;
        hpSlider.value = player.HP;

        //hpText.text = player.HP + "/ 100";
        //fillImage.fillAmount = currentHP / maxHP;
    }
    public void TakeDamage(float damage)
    {
        currentHP -= damage;

        if (currentHP < 0)
        {
            currentHP = 0;
        }
        hpSlider.value = currentHP;
        Debug.Log("Player HP : " + currentHP);
    }
}