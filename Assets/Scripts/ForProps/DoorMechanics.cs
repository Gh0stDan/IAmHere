using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMechanics : MonoBehaviour
{
    [Header("Dynamic Variables")]
    public bool isDoorLock = false;
    public bool isDoorOpen = false;
    public bool activateOneTime = false;

    [Header("Important Variables")]
    public Animator anim;
    //public AnimatorOverrideController animOverrideController;
    public MessageToPlayer messageToPlayer_class;

    private void Start()
    {
        messageToPlayer_class = GameObject.FindGameObjectWithTag("Administrador").GetComponent<MessageToPlayer>(); 
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //Show message when Player is reach to door
            if (isDoorLock)
            {
                messageToPlayer_class.OpenMessageDoorToUser("Door Locked", isDoorLock);
            }
            else
            {
                if (isDoorOpen)
                {
                    messageToPlayer_class.OpenMessageDoorToUser("Close Door", isDoorLock);
                }
                else
                {
                    messageToPlayer_class.OpenMessageDoorToUser("Open Door", isDoorLock);
                }
            }

            //Do action depend if door is locked or not
            if(activateOneTime == false && Input.GetKeyDown(KeyCode.E))
            {
                activateOneTime = true;

                if (isDoorLock == false)
                {                  
                    if (isDoorOpen)
                    {
                        isDoorOpen = false;

                        //Close anim and sound
                        anim.SetBool("isOpen", isDoorOpen);
                        //Debug.Log("Door closed");                       
                    }
                    else
                    {                       
                        isDoorOpen = true;

                        //Open anim and sound
                        anim.SetBool("isOpen", isDoorOpen);
                        //Debug.Log("Door Opened");                       
                    }                   
                }
                else
                {
                    //Sound door Locked
                    //Debug.Log("Door locked");
                }
            }
            else if (activateOneTime == true && Input.GetKeyUp(KeyCode.E))
            {
                activateOneTime = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            messageToPlayer_class.CloseMessageDoorToUser();
            activateOneTime = false;
        }
    }

    //Lines to check pos
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine( (transform.position + new Vector3(2.0f, 0.0f, 0.0f)), (transform.position + new Vector3(-2.0f, 0.0f, 0.0f)) );
        Gizmos.DrawLine( (transform.position + new Vector3(0.0f, 0.0f, 2.0f)), (transform.position + new Vector3(0.0f, 0.0f, -2.0f)) );
    }
}