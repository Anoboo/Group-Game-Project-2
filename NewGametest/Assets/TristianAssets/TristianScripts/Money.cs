using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Money : MonoBehaviour
{
    [SerializeField] private int money;
    [SerializeField] private TextMeshProUGUI moneyText;

    // Special Move
    public GameObject blessedRains;
    public Transform blessedRainsSpawn;
    private Vector3 blessedRainsLocation;
    private GameObject blessedRainsRef;
    public float SpawnDelay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (money >= 5)
        {
            SpecialMove();
        }
    }

    public void MoneyCount()
    {
        money = money + 1;
        UpdateUI();
    }

    void UpdateUI()
    {
        moneyText.text = "Money: " + money;
    }

    void SpecialMove()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Vector3 blessedRainsLocation = blessedRainsSpawn.position;
            blessedRainsRef = Instantiate(blessedRains, blessedRainsLocation, transform.rotation * Quaternion.identity);

            Invoke("SpecialEnemy", SpawnDelay);
            money = money - 5;
        }
    }
}
