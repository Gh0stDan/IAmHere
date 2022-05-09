using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Interactable Object", menuName = "Inventory System/Items/Interactable")]
public class InteractableObject : ItemObject
{
    public int interactionID;

    public void Awake()
    {
        type = ItemType.Interactable;
    }
}
