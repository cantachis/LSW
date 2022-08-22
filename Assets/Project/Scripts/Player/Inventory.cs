using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;
using UnityEngine.EventSystems;
using TMPro;

public class Inventory : MonoBehaviour
{
    // Handles sprite renderer changes, and implements inventory system.


    public SpriteLibrary torsoSprite;
    SpriteLibraryAsset currentTorsoEquipped;
    public SpriteLibrary headSprite;
    SpriteLibraryAsset currentHeadEquipped;
    public SpriteLibrary legsSprite;
    SpriteLibraryAsset currentLegsEquipped;
    GameObject currentTorso;
    GameObject currentHead;
    GameObject currentLegs;
    [SerializeField] GameObject[] inventorySlots = new GameObject[8];

    public int coins;
    public TextMeshProUGUI coinsText;
    private void Start()
    {
        coins = 200;
        torsoSprite = transform.GetChild(2).GetComponent<SpriteLibrary>();
        headSprite = transform.GetChild(1).GetComponent<SpriteLibrary>();
        legsSprite = transform.GetChild(3).GetComponent<SpriteLibrary>();
        currentHeadEquipped = headSprite.spriteLibraryAsset;
        currentTorsoEquipped = torsoSprite.spriteLibraryAsset;
        currentLegsEquipped = legsSprite.spriteLibraryAsset;

    }
    private void FixedUpdate()
    {
        if (coinsText != null)
        {

            if (coinsText.text != coins.ToString())
            { coinsText.text = coins.ToString(); }
        }
    }
    public void PlaceIteminInventory(GameObject item)
    {
        //Finds all slots, then finds all unoccupied, and then puts item in there

        inventorySlots = GameObject.FindGameObjectsWithTag("Slot");
        int occupied = 0;
        for (int i = 0; i < inventorySlots.Length; i ++)
        {
            if (!inventorySlots[i].GetComponent<SlotInfo>().IsOccupied)
            {
                inventorySlots[i].GetComponent<SlotInfo>().IsOccupied = true;
                    item.transform.position = inventorySlots[i].transform.position;
                    item.transform.SetParent(inventorySlots[i].transform);
                    item.GetComponent<ItemInfo>().Slot = inventorySlots[i];
                    break;
            }
            else { occupied++; }
        }
        if (occupied == inventorySlots.Length-1) { Debug.Log("inventory is full"); }
    }
    public void BuyItem(GameObject item, int cost)

    {
        //Buying item. Used in Shop buttons. using Instantiate instead of GameObject itself, not like method above
        if (GameObject.Find("UIManager").GetComponent<UIManager>().inventory.activeSelf)
        {
            int occupied = 0;
            inventorySlots = GameObject.FindGameObjectsWithTag("Slot");
            for (int i = 0; i < inventorySlots.Length; i++)
            {
                if (!inventorySlots[i].GetComponent<SlotInfo>().IsOccupied)
                {
                    inventorySlots[i].GetComponent<SlotInfo>().IsOccupied = true;
                    GameObject tempobj = Instantiate(item, inventorySlots[i].transform);
                    tempobj.GetComponent<ItemInfo>().Slot = inventorySlots[i];
                    break;
                }
                else { occupied++; }
                if (occupied == inventorySlots.Length - 1) { Debug.Log("inventory is full"); }
            }
       
        coins -= cost;
        }           
    }
    public void PutOn(GameObject item)
    {
        // Simple Item System, with handling Sprite Library
        //Left click - Put On, Right  Click - Sell

            ItemInfo info = item.GetComponent<ItemInfo>();
            if (info.slot == "Torso")
            {
                if (currentTorso != item)
                {
                    currentTorsoEquipped = Resources.Load<SpriteLibraryAsset>("Player Animations/" + info.slot + "/" + info.spriteAssetName);
                    torsoSprite = GameObject.Find("Torso").GetComponent<SpriteLibrary>();
                    torsoSprite.spriteLibraryAsset = currentTorsoEquipped;

                    UpdateItems(info.slot, item);

                    if (currentTorso != null)
                    {
                        PlaceIteminInventory(currentTorso);
                    }
                    currentTorso = item;
                }
            }
            if (info.slot == "Head")
            {
                if (currentHead != item)
                {
                    currentHeadEquipped = Resources.Load<SpriteLibraryAsset>("Player Animations/" + info.slot + "/" + info.spriteAssetName);
                    headSprite = GameObject.Find("Head").GetComponent<SpriteLibrary>();
                    headSprite.spriteLibraryAsset = currentHeadEquipped;
                    UpdateItems(info.slot, item);

                    if (currentHead != null)
                    {
                        PlaceIteminInventory(currentHead);
                    }
                    currentHead = item;
                }
            }
            if (info.slot == "Legs")
            {
                if (currentLegs != item)
                {
                    currentLegsEquipped = Resources.Load<SpriteLibraryAsset>("Player Animations/" + info.slot + "/" + info.spriteAssetName);
                    legsSprite = GameObject.Find("Legs").GetComponent<SpriteLibrary>();
                    legsSprite.spriteLibraryAsset = currentLegsEquipped;
                    UpdateItems(info.slot, item);

                    if (currentLegs != null)
                    {
                        PlaceIteminInventory(currentLegs);
                    }
                    currentLegs = item;
                }
            }
        }
    public void UpdateItems(string slotName, GameObject item)
    {
        //Puts item in the right slot
                if (slotName == "Head")
                {
                    ValidateItemSlot(slotName, item);     
                }else 
                if (slotName == "Torso")
                {              
                        ValidateItemSlot(slotName, item);                                   
                }else
                if (slotName == "Legs")
                {
                    ValidateItemSlot(slotName, item);
                }
    }           
    public void ValidateItemSlot(string slotName, GameObject item)
    {
        GameObject slot = GameObject.Find("Slot" + slotName);
        item.transform.position = slot.transform.position;
        item.transform.SetParent(slot.transform);
        item.GetComponent<ItemInfo>().Slot = slot;
    }
}
