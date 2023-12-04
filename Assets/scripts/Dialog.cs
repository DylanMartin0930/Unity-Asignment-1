using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
//just a separate script to easily store multiple dialog options
public class Dialog
{
    [SerializeField] List<string> lines; 

    public List<string> Lines
    {
        get { return lines; }
    }
}
