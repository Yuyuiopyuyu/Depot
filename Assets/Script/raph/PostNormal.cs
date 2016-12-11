using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostNormal : MonoBehaviour {

    private TheDoor parent;

    void Start()
    {
        parent = transform.parent.GetComponent<TheDoor>();
    }

    void OnTriggerEnter(Collider aCol)
    {
        parent.PostNormalTriggerEnter(aCol);
    }

    void OnTriggerExit(Collider aCol)
    {
        parent.PostNormalTriggerExit(aCol);
    }
}
