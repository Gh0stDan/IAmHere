using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MessageToPlayer : MonoBehaviour
{
    public GameObject MessagePanel_GO; 
    public GameObject ShowLock_GO;
    public TextMeshProUGUI Message_TMP;
    public RawImage MessageImage_RawImage;

    public void OpenMessageDoorToUser(string texToShow, bool IsLock)
    {
        //Change icon here;
        ShowLock_GO.SetActive(IsLock);
        Message_TMP.text = texToShow;
        MessagePanel_GO.SetActive(true);
    }

    public void CloseMessageDoorToUser() 
    {
        MessagePanel_GO.SetActive(false);
    }
}