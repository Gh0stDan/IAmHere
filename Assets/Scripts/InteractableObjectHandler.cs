using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjectHandler : MonoBehaviour
{
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

    public void CheckIfInteractable(GameObject objectToCheck)
    {
        InteractableObject objectToCheckInteractable = objectToCheck.GetComponent<InteractableObject>();

        foreach (var interactable in interactablesInventory)
        {
            if (objectToCheckInteractable.interactableID == interactable.interactableID)
            {
                Debug.Log("Object can be destroyed");
                Destroy(objectToCheck);
            }
        }
    }

    private void OnMouseOver()
    {
        Debug.Log("Player is looking at " + transform.name);
    }
}
