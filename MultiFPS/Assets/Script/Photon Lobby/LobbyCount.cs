using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyCount : MonoBehaviour
{
    public int count;
    //public 

    public void Selected()
    {
        Data.count = count;
    }
}
