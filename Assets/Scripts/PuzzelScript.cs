using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PuzzelScript : MonoBehaviour
{
    public List<GameObject> Pieces = new List<GameObject>();
    public List<Vector3> StartPos = new List<Vector3>();
    public List<Quaternion> Rot = new List<Quaternion>();


    public float intensity;
    public float ColorIntensity;
    public GameObject aukfwaduawhdhawidhiuwa;
    public Material hej;
    public Color color;
    public Rigidbody Rb;

    SubtleHints subtlehint;
    GameObject Child;


    [Header("Disable handgrab")]
    public UnityEvent hand;



    void Start()
    {
        AddPieceInformation();
    }

    void Update()
    {
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Puzzel_run_sub"))
        {
            subtlehint = aukfwaduawhdhawidhiuwa.GetComponent<SubtleHints>();
        }
        FallDown();
    }
    public void FallDown()
    {
        for (int i = 3; i < Pieces.Count; i = i + 2)
        {
            if (Pieces[i].transform.position.y < -1)
            {
                Pieces[i].transform.position = StartPos[i];
            }
        }
    }

    IEnumerator SubtleColor()
    {
        while (true)
        {
            if (intensity == 1.0F)
            {
                intensity = intensity + 0.001F;
                yield return new WaitForSeconds(5);
            }
            else
            {
                color = hej.color;
                color.a = ColorIntensity;
                hej.color = color;
                yield return new WaitForSeconds(1);
                ColorIntensity = ColorIntensity + 0.1F;
                yield return new WaitForSeconds(3);
            }
        }
    }


    public void AddPieceInformation()
    {
        Transform[] Children = GetComponentsInChildren<Transform>();
        foreach (Transform child in Children)
        {
            Pieces.Add(child.gameObject);
            StartPos.Add(child.transform.position);
            Rot.Add(child.transform.rotation);
        }
    }

    public void ChangePos(GameObject PieceName)
    {
        hand.Invoke();
        int Nr = Pieces.IndexOf(PieceName);
        Pieces[Nr].transform.position = StartPos[Nr];
        Pieces[Nr].transform.rotation = Rot[Nr];
    }

    public void RightPiece(GameObject PieceName)
    {
        int a = Pieces.IndexOf(PieceName);
        Rb = Pieces[a].GetComponent<Rigidbody>();
        int ConnectPiece = Pieces.IndexOf(PieceName) - 2; // Gets index from puzzle piece befor in list
        Vector3 temp = new Vector3(0.02f, 0, 0);           // Temporary vector that we will add to the new vector
        PieceName.transform.position = Pieces[ConnectPiece].transform.position;
        PieceName.transform.position += temp;             // Puzzle piece gets new position
        PieceName.transform.rotation = Rot[ConnectPiece];

        int CurrentPiece = Pieces.IndexOf(PieceName);
        Pieces[CurrentPiece].transform.position = PieceName.transform.position; // Updates the current position of the piece
        Rb.isKinematic = true;
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Puzzel_run_sub"))
        {
            subtlehint.CounterIncrease();
        }
        
    }


}