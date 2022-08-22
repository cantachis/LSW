using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    //Manages Invertory, Dialogue and Shop

    [SerializeField] private GameObject Inventory;
    [SerializeField] private GameObject Dialogue;
    [SerializeField] private GameObject Shop;
    GameObject dialogue;
    public GameObject inventory;
    GameObject shop;
    void Awake()
    {
        inventory = GameObject.Find("Inventory");
        GameObject.Find("Player").GetComponent<Inventory>().coinsText = GameObject.Find("CoinsText").GetComponent<TextMeshProUGUI>();
        inventory.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            OpenCloseInventory();
        }
    }
    public void OpenDialogue()
    {
        if (dialogue == null)
        {
            dialogue = Instantiate(Dialogue, GameObject.Find("Canvas").transform);
        }
        else
        {
            dialogue.SetActive(true);
        }
    }
    public void CloseUIBox(GameObject uiElement)
    {
        uiElement.SetActive(false);
    }
    public void CloseEverything()
    {
        foreach (Transform child in GameObject.Find("Canvas").transform)
        {
            child.gameObject.SetActive(false);
        }
    }
    public void OpenShop()
    {
        if (shop == null)
        {
            shop = Instantiate(Shop, GameObject.Find("Canvas").transform);
        }
        else
        {
            shop.SetActive(true);
        }
    }
    public void OpenCloseInventory()
    {
        if (inventory.activeSelf)
                {
                inventory.SetActive(false);
                }
                else
                {
                 inventory.SetActive(true);
                }
            }
    private void OnApplicationQuit()
    {
        inventory.SetActive(true); //Unity saves the info after a play mode. this line of code insures that its active every time
    }
}



