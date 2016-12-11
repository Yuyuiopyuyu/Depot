using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    public GameObject entryA;
    public GameObject entryX;
    public GameObject entryB;
    public GameObject entryY;

    private TheDoor theDoorA;
    private TheDoor theDoorX;
    private TheDoor theDoorB;
    private TheDoor theDoorY;

    private WaveController waveControlller;

    void Start()
    {
        theDoorA = entryA.GetComponent<TheDoor>();
        theDoorX = entryX.GetComponent<TheDoor>();
        theDoorB = entryB.GetComponent<TheDoor>();
        theDoorY = entryY.GetComponent<TheDoor>();

        waveControlller = GameObject.Find("GameController").GetComponent<WaveController>();
    }

    Collider lastCollider = null;
    List<Collider> removeMe = new List<Collider>();

    void processDoor(TheDoor door)
    {
        //Check touch nothing
        if (door.pnjsPreNormal.Count <= 0 && door.pnjsPerfect.Count <= 0 && door.pnjsPostNormal.Count <= 0)
        {
            //Too early
            GameObject.Find("GameController").GetComponent<WaveController>().missNote();
            return;
        }

        lastCollider = null;
        bool thereWasPerfect = false;

        //Check perfect
        if (door.pnjsPerfect.Count > 0)
        {
            Debug.Log("Perfect");
            processColliders(door.pnjsPerfect, door, true);
            thereWasPerfect = true;
        }
        //Check Post
        if (door.pnjsPostNormal.Count > 0)
        {
            Debug.Log("Post");
            processColliders(door.pnjsPostNormal, door, false);
        }
        //Check Pre
        if (!thereWasPerfect && door.pnjsPreNormal.Count > 0)
        {
            Debug.Log("Pre");
            processColliders(door.pnjsPreNormal, door, false);
        }
        door.playNote(lastCollider.transform.parent.GetComponent<PnjBehavior>().forceHeight);
    }

    void processColliders(List<Collider> temp, TheDoor door, bool perfect)
    {
        foreach (Collider col in temp)
        {
            waveControlller.validNote(perfect);
            removeMe.Add(col);
            //Peut etre dans un des deux autres colliders
            if (perfect)
            {
                door.pnjsPostNormal.Remove(col);
                door.pnjsPreNormal.Remove(col);
            }

            lastCollider = col;
            col.transform.parent.GetComponent<PnjBehavior>().wasChecked();
            col.transform.GetComponent<Collider>().enabled = false;
        }
        foreach (Collider s in removeMe)
            temp.Remove(s);
        removeMe.Clear();
    }

    void Update()
    {
        if (Input.GetButtonDown("ButtonA"))
        {
            processDoor(theDoorA);
        }

        if (Input.GetButtonDown("ButtonX"))
        {
            processDoor(theDoorX);
        }

        if (Input.GetButtonDown("ButtonB"))
        {
            processDoor(theDoorB);
        }

        if (Input.GetButtonDown("ButtonY"))
        {
            processDoor(theDoorY);
        }
    }
}
