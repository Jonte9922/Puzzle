using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Timers;


public class Tutorial : MonoBehaviour
{

    public Text UpdateText;
    public int counter;
    public bool asdf = false;

    // Start is called before the first frame update
    void Start()
    {
        UpdateText.text = "Welcome to this tutorial!";
        Invoke("UpdateText1", 5f);
    }


    public void GrabCube()
    {
        if (counter == 1)
        {
            UpdateText.text = "You managed to grab the cube!";
            Invoke("UpdateText1", 2f);
        }
    }
    public void hej()
    {
        asdf = true;
    }
    public void hejda()
    {
        asdf = false;
    }

    public void Colliding()
    {
        if (asdf == true&&counter == 2)
        {
            UpdateText.text = "You managed to drop the cube on the plate";
            Invoke("UpdateText1", 2f);
        }
    }

    void UpdateText1()
    {
        if (counter == 0)
        {
            UpdateText.text = "Try to grab the cube by squeezeing the cube with your thumb and index finger";
            counter++;
        }
        else if (counter == 1)
        {
            UpdateText.text = "Now try to place the cube on the plate and release it";
            counter++;
        }
        else if(counter == 2)
        {
            UpdateText.text = "You passed the tutorial!";
            counter++;
        }

    }

}