using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    public GameObject player;
    public float allowedDistance;

    [SerializeField]
    private HashSet<Point> playerPointsHash = new HashSet<Point>();

    private void Update()
    {
        if (Input.GetKey(KeyCode.V))
        {
            GroundAnimation();
        }

        //foreach (var groundPart in GridManager.Instance.gridPoints)
        //{
        //    //if (IsNeighboor(player.transform.position, groundPart.transform.position))
        //    //{
        //    //    StartCoroutine(AnimateGroundUp(groundPart));
        //    //}
        //    if (groundPart.transform.position.x == 3)
        //    {
        //        StartCoroutine(AnimateGroundUp(groundPart));
        //    }
        //}

        //Point playerPoints = new Point((int)player.transform.position.x, (int)player.transform.position.z);
        //playerPointsHash.Add(playerPoints);

        //foreach (var groundPart in GridManager.Instance.gridPoints)
        //{
        //    foreach (var playerPoint in playerPointsHash)
        //    {
        //        if (groundPart.GetComponent<GridSell>().gridPos == playerPoint)
        //        {
        //            Debug.Log("we found it");
        //        }
        //    }
        //}
    }

    void GroundAnimation()
    {
        foreach (var groundPart in GridManager.Instance.gridPoints)
        {
            StartCoroutine(AnimateGroundUp(groundPart));
        }
    }

    bool IsNeighboor(Vector3 playerPos, Vector3 groundPartPos)
    {
        float posDifference;

        //posDifference = playerPos.x - groundPartPos.x;
        //if (posDifference <= allowedDistance)
        //{
        //    return true;
        //}
        
        if ((playerPos.x - groundPartPos.x) >= allowedDistance || (playerPos.z - groundPartPos.z) >= allowedDistance)
        {
            Debug.Log(playerPos.x - groundPartPos.x);
            return true;
        }
        else
        {
            return false;
        }
          
    }

    IEnumerator AnimateGroundUp(GameObject partToAnimate)
    {
        Vector3 startPos = partToAnimate.transform.position;
        Vector3 endPos = startPos + new Vector3(0f, 3f, 0f);

        float progressTime = 0f;
        float duration = 2f;

        while (progressTime < duration)
        {
            progressTime += Time.deltaTime;
            partToAnimate.transform.position = Vector3.Lerp(startPos, endPos, progressTime);
            yield return null;
        }

        StartCoroutine(AnimateGroundDown(partToAnimate));
    }

    IEnumerator AnimateGroundDown (GameObject partToAnimate)
    {
        Vector3 startPos = partToAnimate.transform.position;
        Vector3 endPos = startPos - new Vector3(0f, 3f, 0f);

        float progressTime = 0f;
        float duration = 2f;

        while (progressTime < duration)
        {
            progressTime += Time.deltaTime;
            partToAnimate.transform.position = Vector3.Lerp(startPos, endPos, progressTime);
            yield return null;
        }

    }
}
