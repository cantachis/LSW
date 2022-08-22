using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotInfo : MonoBehaviour
{
    private void Start()
    {


    }
    private void FixedUpdate()
    {
                if (transform.childCount > 0)
        {
            IsOccupied = true;
        }
                else
        {
            IsOccupied = false;
        }
    }
    public bool IsOccupied { get; set; }
}
