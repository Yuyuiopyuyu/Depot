using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perfect : MonoBehaviour {

    private TheDoor parent;

    void Start()
    {
        parent = transform.parent.GetComponent<TheDoor>();
    }

    void OnTriggerEnter(Collider aCol)
    {
        parent.PerfectTriggerEnter(aCol);
    }

    void OnTriggerExit(Collider aCol)
    {
        parent.PerfectTriggerExit(aCol);
    }
}
