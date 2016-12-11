using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PnjBehavior : MonoBehaviour {

    public float speed;

    public GameObject target;
    public int forceHeight;

    private Vector3 targetVector;

    private float timeToDoor = 1.0f;
    private WaveController god;

    private float initY;

    // Use this for initialization
    void Start () {
        initY = transform.position.y;
        //targetVector = (target.transform.position - this.transform.position).normalized;
        GameObject gameManager = GameObject.Find("GameController");
        god = gameManager.GetComponent<WaveController>();
        timeToDoor = god.TimeWalk;
        // Make the character move to the given point
        StartCoroutine(MoveOverSeconds(gameObject, target.transform.position, timeToDoor));
    }

    bool isArrived = false;

    bool isInvited = false;

	void Update () {
        if(isArrived)
            transform.Translate(targetVector * Time.deltaTime * speed);
        //this.transform.position = Vector3.Lerp(this.transform.position, Vector3.zero, Time.deltaTime * speed);
        //
    }

    public IEnumerator MoveOverSeconds(GameObject objectToMove, Vector3 end, float seconds)
    {
        end = new Vector3(end.x, initY, end.z);
        float distance = Vector3.Distance(this.transform.position, end);
        targetVector = -(this.transform.position - end).normalized;
        speed = distance / seconds;

        float elapsedTime = 0;
        Vector3 startingPos = objectToMove.transform.position;
        Vector3 move;
        while (elapsedTime < seconds)
        {
            move = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
            transform.position = move;
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.position = end;
        isArrived = true;
    }

    public void wasChecked()
    {
        isInvited = true;
    }

    public void passedLastCollider()
    {
        if(!isInvited)
            Destroy(gameObject);
    }
}
