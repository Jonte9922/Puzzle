using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InOrder : MonoBehaviour
{

    int r = 2;
    public List<GameObject> Zones = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        ZoneList();
        InactivateZones();
    }


    public void ZoneList()
    {
        Transform[] Children = GetComponentsInChildren<Transform>();
        foreach (Transform child in Children)
        {
            Zones.Add(child.gameObject);
        }
    }


    public void InactivateZones()
    {
        for (int i = 2; i <= 9; i++)
        {
            Zones[i].SetActive(false);
        }
    }


    public void ActivateZones()
    {
        if (r == 10)
        {
            Zones[9].SetActive(false);
        }
        else
        {
            Zones[r].SetActive(true);
            r++;
        }

    }
}
