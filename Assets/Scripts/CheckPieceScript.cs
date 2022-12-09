using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPieceScript : MonoBehaviour
{

    public static GameObject ThisPiece;
    public static bool grab_object;


    public void CheckPiece()
    {
        ThisPiece = this.gameObject;
    }

    public void Grab()
    {
        grab_object = true;
    }

    public void Release()
    {
        grab_object = false;
    }
}
