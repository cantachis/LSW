using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class ItemInfo : MonoBehaviour, IPointerClickHandler
{
    public string spriteAssetName;
    public string slot;
    public int cost;
    void Start()
    {
        cost = 3;
        Slot = transform.parent.gameObject;
    }

    //Some Info Holder, and item selling code.
   
    public GameObject Slot { get; set;}
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right && Slot.CompareTag("Slot")) //So it wont sell if equipped
        {
            GameObject.Find("Player").GetComponent<Inventory>().coins += cost;
            Destroy(gameObject);
        }
    }


}
