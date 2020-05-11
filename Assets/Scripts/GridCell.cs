using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCell : MonoBehaviour
{
    public Point gridPos;
    Vector3 initialPosition;

    Vector3 endPos;

    private void Awake()
    {
        initialPosition = gameObject.transform.position;
        //StartCoroutine(AnimateGroundUp(gameObject, false));
    }

    private void Update()
    {
        //this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + Mathf.PingPong(Time.time, Random.Range(0.1f, 0.4f)), this.transform.position.z);
        //StartCoroutine(AnimateGroundUp(gameObject, false));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //Debug.Log("<b>IN</b>" + gameObject.transform.position);
            //StartCoroutine(AnimateGroundUp(gameObject));

            for (int i = 0; i < GridManager.Instance.gridPoints.Count; i++)
            {
                if (GridManager.Instance.gridPoints[i] == gameObject)
                {
                    //find neighbours of this gameobject and animate them
                    StartCoroutine(AnimateGroundUp(GridManager.Instance.gridPoints[i], true));
                    //Debug.Log(GridManager.Instance.gridPoints[i].transform.position);
                    //GridManager.Instance.GetNeighbours(gameObject.GetComponent<GridCell>());
                    //foreach (var groundPart in GridManager.Instance.GetNeighbours(gameObject.GetComponent<GridCell>()))
                    //{
                    //    Debug.Log(groundPart.transform.position);
                    //}
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            //Debug.Log("<b>OUT</b>" + gameObject.transform.position);
            StartCoroutine(AnimateGroundDown(gameObject, true));
        }
    }

    IEnumerator AnimateGroundUp(GameObject partToAnimate, bool isActive)
    {
        float height;
        height = isActive ? 0.5f : Random.Range(0.1f, 0.4f);

        Vector3 startPos = partToAnimate.transform.position;
        Vector3 endPos = startPos + new Vector3(0f, height, 0f);

        float progressTime = 0f;
        float duration = 1f;

        while (progressTime < duration)
        {
            progressTime += Time.deltaTime;
            partToAnimate.transform.position = Vector3.Lerp(startPos, endPos, progressTime);
            yield return null;
        }
        if (!isActive)
        {
            StartCoroutine(AnimateGroundDown(partToAnimate, false));
        }
        
    }

    IEnumerator AnimateGroundDown(GameObject partToAnimate, bool isActive)
    {
        float height;
        height = isActive ? 0.5f : 0.3f;

        Vector3 startPos = partToAnimate.transform.position;
        Vector3 endPos = initialPosition;

        float progressTime = 0f;
        float duration = 1f;

        while (progressTime < duration)
        {
            progressTime += Time.deltaTime;
            partToAnimate.transform.position = Vector3.Lerp(startPos, endPos, progressTime);
            yield return null;
        }
        if (!isActive)
        {
            StartCoroutine(AnimateGroundUp(partToAnimate, false));
        }
    }
}
