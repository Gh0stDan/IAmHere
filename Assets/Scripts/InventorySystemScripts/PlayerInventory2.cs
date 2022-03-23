using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory2 : MonoBehaviour
{

    public InventoryObject inventory;
    public GameObject instructionPanel;
    bool instructonPanelStatus;
    
     void Start()
     {
         instructonPanelStatus = false;
         instructionPanel.SetActive(false);
     }
     
     private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            inventory.Save();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            inventory.Load();
        }
    }      

     public void OnTriggerEnter(Collider collisonActive)
     {
         
         
             instructionPanel.SetActive(true);
             instructonPanelStatus = true;
         
     }

     public void OnTriggerStay(Collider CollisionConfirmation)
     {
         
             if(Input.GetKey(KeyCode.E) && instructonPanelStatus == true)
             {
                 var item = CollisionConfirmation.GetComponent<Item>();
                 if (item)
                 {
                     inventory.AddItem(item.item, 1);
                     Destroy(CollisionConfirmation.gameObject);
                     instructionPanel.SetActive(false);
                     instructonPanelStatus = false;
            }
             }
             else { return; }
         
     }

     public void OnTriggerExit(Collider collisionDisable)
     {
         
         
             instructionPanel.SetActive(false);
             instructonPanelStatus = false;
         
     }

    private void OnApplicationQuit()
    {
        inventory.Container.Clear();
    }

}
