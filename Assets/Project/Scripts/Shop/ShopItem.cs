using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopItem : MonoBehaviour
{

    // Gets and Saves info about Item that it holds in Shop 
    Inventory inventory;
    public GameObject ItemToSell { get; set; }
    public int cost;

    private void Start()
    {
        inventory = GameObject.Find("Player").GetComponent<Inventory>();
        transform.GetChild(0).GetComponent<Image>().sprite = ItemToSell.GetComponent<Image>().sprite;
        cost = int.Parse(transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = Random.Range(5,11).ToString());
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(Buy);
    }

    void Buy()
    {
        if (inventory.coins > cost)
        {
            inventory.BuyItem(ItemToSell, cost);
        }
    }
}
