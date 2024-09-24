using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public float timePassed;
    public float lerpDone;
    public float xMove = 10;
    public float seconds = 5f;

    private void Start()
    {

    }
    private void Update()
    {
        EnemyMovement();
    }

    private void EnemyMovement()
    {
        timePassed += Time.deltaTime;
        lerpDone = timePassed / seconds;

        Vector3 startPoint = new Vector3(0f, -5.23999977f, 0f);
        Vector3 endLeft = new Vector3(startPoint.x - xMove, startPoint.y, 0);
        Vector3 endRight = new Vector3(startPoint.x + xMove, startPoint.y, 0);

        transform.position = Vector3.Lerp(startPoint, endLeft, lerpDone);

        if(lerpDone >= 1)
        {
            transform.position = Vector3.Lerp(endLeft, endRight, lerpDone);
        }

        

    }

}
