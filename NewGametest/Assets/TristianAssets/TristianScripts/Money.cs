using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Money : MonoBehaviour
{
    public static int money;
    public int startMoney = 300;

    public TextMeshProUGUI moneyText;

    private void Start()
    {
        money = startMoney;
    }

    private void Update()
    {
        moneyText.text = "Money: " + money;
    }


}
