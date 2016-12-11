using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SapinScript : MonoBehaviour {

    Vector3 originalScale;

    // Use this for initialization
    void Start () {
        originalScale = transform.localScale;
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

   
    

    Coroutine currentScale;

    public void scaleSapin()
    {
        if (currentScale != null)
            StopCoroutine(currentScale);
        currentScale = StartCoroutine(SmoothMove(this.transform.localScale, originalScale * Random.Range(1.05f,1.13f), 0.2f,0.2f));
    }

    IEnumerator SmoothMove(Vector3 startscale, Vector3 endscale, float secondsIn, float secondsOut) { 
        float t = 0.0f;
        while (t <= 1.0f)
        {
            t += Time.deltaTime / secondsIn;
            transform.localScale = Vector3.Lerp(startscale, endscale, Mathf.SmoothStep(0.0f, 1.0f, t));
            yield return new WaitForEndOfFrame();
        }
        while (t >= 0.0f)
        {
            t -= Time.deltaTime / secondsOut;
            transform.localScale = Vector3.Lerp(endscale, originalScale, Mathf.SmoothStep(1.0f, 0.0f, t));
            yield return new WaitForEndOfFrame();
        }
        currentScale = null;
    }
}
