using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabInit : MonoBehaviour
{
    [SerializeField] private List<GameObject> ItemsToSell;
    public List<GameObject> GetItems()
    {
        return ItemsToSell;
    }
}
