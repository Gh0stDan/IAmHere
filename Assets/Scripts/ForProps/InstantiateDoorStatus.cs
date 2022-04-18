using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateDoorStatus : MonoBehaviour
{
    [Header("Vars For Doors")]
    public GameObject[] GOsToInstantiateDoors;
    public GameObject DoorPrefab;

    private void Start()
    {
        foreach(GameObject go in GOsToInstantiateDoors)
        {         
            //Set rotation of the empty door
            /*if (go.transform.localPosition.x == 0.0f)
            {
                go.transform.rotation = new Quaternion(0, -0.707106829f, 0, 0.707106829f);
            }
            else if(Mathf.Sign(go.transform.localPosition.x) == 1 || Mathf.Sign(go.transform.position.x) == 0)
            {
                go.transform.rotation = new Quaternion(0, 0, 0, 1);
            }
            else if (Mathf.Sign(go.transform.localPosition.x) == -1)
            {
                go.transform.rotation = new Quaternion(0, 1, 0, 0);
            }*/


            //Instantiate door 
            GameObject prefab = Instantiate(DoorPrefab, go.transform);

            //Set rotation of the empty door
            //prefab.transform.rotation = new Quaternion(0, 1, 0, 0);
        }
    }

    //Lines to check pos
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(transform.position, 0.2f);

        foreach (GameObject go in GOsToInstantiateDoors)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(go.transform.position, 0.2f);
        }
    }
}
