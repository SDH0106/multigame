using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class Information : MonoBehaviour
{
    public Text RoomData;

    public void SetInfo(string name, int current, int max)
    {
        RoomData.text = name + " ( " + current + " / " + max + " )";
    }
}
