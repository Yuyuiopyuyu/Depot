using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreNormal : MonoBehaviour {

    private TheDoor parent;

    void Start()
    {
        parent = transform.parent.GetComponent<TheDoor>();
    }

    void OnTriggerEnter(Collider aCol)
    {
        parent.PreNormalTriggerEnter(aCol);
    }

    void OnTriggerExit(Collider aCol)
    {
        parent.PreNormalTriggerExit(aCol);
    }
}
