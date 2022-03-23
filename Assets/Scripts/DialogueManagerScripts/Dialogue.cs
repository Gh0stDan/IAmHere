using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue : MonoBehaviour
{

    public string nameChar;
    [TextArea(3, 10)]

    public string[] sentenceList;

    public float sentenceListLength;
    public float sentenceLengthReal;

    public void update()
    {
        sentenceListLength = sentenceList.Length;
        sentenceLengthReal = sentenceListLength;
    }
}
