using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopInit : MonoBehaviour
{
    GameObject tab;
    [SerializeField] GameObject[] tabs;
    [SerializeField] private GameObject shopTab;
    List<GameObject> items;


    void Start()
    {      
        OpenTab(0);
    }

    void Update()
    {
        
    }
    public void OpenTab(int tabNum)
    {
        foreach (GameObject tab in tabs)
        {
            tab.GetComponent<CanvasRenderer>().SetAlpha(0.2f);
        }
        
     DeInitShop();
     tab = tabs[tabNum];
     Debug.Log(tab.name);
     tab.GetComponent<CanvasRenderer>().SetAlpha(1);
     InitItems(tab);
    }
    void DeInitShop()
    {

        foreach (GameObject item in GameObject.FindGameObjectsWithTag("ShopItems"))
        {
            Destroy(item);
        }
    }

    void InitItems(GameObject tab)
    {
         items = tab.GetComponent<TabInit>().GetItems();

        for (int i = 0; i < items.Count; i++)
        {
            GameObject slot = GameObject.Find("ShopSlot" + i);
            GameObject it = Instantiate(shopTab, GameObject.Find("ShopBody").transform);          
            it.transform.position = slot.transform.position;
            it.GetComponent<ShopItem>().ItemToSell = items[i];
        }
    }
    void OnDisable()
    {
        DeInitShop();
    }
    private void OnEnable()
    {
        OpenTab(0);
    }
}
