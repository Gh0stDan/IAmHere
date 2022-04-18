using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPosRooms : MonoBehaviour
{
    [Header("Vars For Rooms")]
    public List<GameObject> Rooms;
    public List<GameObject> Emptys = new List<GameObject>();
    public static List<GameObject> RemainingRooms;

    private void Awake()
    {
        //Load Emptys
        if(Emptys.Count == 0)
        {
            PreLoadEmptys();
        }

        //Randomize Rooms in any Empty in MainRoom
        for(int i = 0; i < Emptys.Count; i++)
        {
            //if there are any empty free but i is on the last count refresh i
            if (Emptys.Count != 0 && (i + 1) == Emptys.Count)
            {
                i = 0;
            }

            //Check if empty is free, if not remove from the list
            for (int j = 0; j < Emptys.Count; j++)
            {
                if (Emptys[j].GetComponent<StatusEmptyDoor>().isEmpty == false)
                {
                    Emptys.RemoveAt(j);
                }
            }            

            //Randomize empty and room
            int RandomEmptyIndex = Random.Range(0, Emptys.Count);
            int RandomRoomIndex = Random.Range(0, Rooms.Count);
            //if Emptys count has more than 1 empty free randomize empty and room
            if (Emptys.Count > 0)
            {              
                //Send room to empty set rotation to room and enable              
                Rooms[RandomRoomIndex].transform.SetPositionAndRotation(Emptys[RandomEmptyIndex].transform.position, Emptys[RandomEmptyIndex].transform.rotation);
                Rooms[RandomRoomIndex].SetActive(true);

                //Remove room moved and set isEmpty to false
                Rooms.RemoveAt(RandomRoomIndex);
                Emptys[RandomEmptyIndex].GetComponent<StatusEmptyDoor>().isEmpty = false;
            }
            else
            {
                //if emptys array has only 1 empty free randomize room in the only empty:
                Rooms[0].transform.position = Emptys[RandomEmptyIndex].transform.position;
            }
        }        
    }

    private void PreLoadEmptys()
    {
        Transform[] PreCheck = GetComponentsInChildren<Transform>();

        foreach (Transform t in PreCheck)
        {
            if (t.gameObject.GetComponent<StatusEmptyDoor>())
            {
                Emptys.Add(t.gameObject);
            }
        }
    }
}
