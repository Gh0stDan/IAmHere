using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjectHandler : MonoBehaviour
{
    public InventoryObject inventory;

    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Raycast is casted");
            RaycastHit hit;

            if (Physics.Raycast(transform.position,
                                transform.TransformDirection(Vector3.forward),
                                out hit,
                                Mathf.Infinity))
            {
                if (hit.transform.GetComponent<ObjectToInteract>() != null)
                {
                    CheckIfInteractable(hit.transform.GetComponent<ObjectToInteract>());
                }
            }
        }
    }

    public void CheckIfInteractable(ObjectToInteract itemObject)
    {
        Debug.Log("Hit is interactable");

        foreach (InventorySlot slot in inventory.Container)
        {
            if (slot.item == itemObject.interactsWith)
            {
                Destroy(itemObject.gameObject);
            }
        }
    }
    /*
    public List<InteractableObject> interactablesInventory;
    public GameObject knife;

    public void Start()
    {
        interactablesInventory.Add(knife.GetComponent<InteractableObject>());
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Raycast is casted");
            RaycastHit hit;

            if (Physics.Raycast(transform.position, 
                                transform.TransformDirection(Vector3.forward),
                                out hit,
                                Mathf.Infinity))
            {
                if (hit.transform.GetComponent<InteractableObject>() != null)
                {
                    Debug.Log("Hit is interactable");
                    CheckIfInteractable(hit.transform.gameObject);
                }
            }
        }
    }

    

    private void OnMouseOver()
    {
        Debug.Log("Player is looking at " + transform.name);
    }*/
}
