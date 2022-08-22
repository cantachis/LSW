using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    /*
     * Idea is, that whenever Player enters shop
     * game loads NPC that he can interact with
     */

    GameObject npcSeller;
    [SerializeField] private GameObject pressEPrefab;
    [SerializeField] private UIManager uiManager;
    bool isInProximity;
    GameObject pressE;
    void Start()
    {
        npcSeller = GameObject.Find("NPC");
    }


    void Update()
    {
        // Checks the proximity of NPC
        if (Vector2.Distance(transform.position, npcSeller.transform.position) <= 2)
        {
            
            if (!isInProximity) 
            {
                pressE = Instantiate(pressEPrefab, npcSeller.transform.position, pressEPrefab.transform.rotation); 
            }
            if (Input.GetKey(KeyCode.E)){ Talk(); }

               
            isInProximity = true;
            
        }
        else
        {
            isInProximity = false;
            if (pressE != null) { Destroy(pressE);
                uiManager.CloseEverything();
            }  
        }
    }
    void Talk()
    {
        uiManager.OpenDialogue();
    }
}
