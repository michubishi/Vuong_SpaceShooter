using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float moveSpeed;
    public float arrivalDistance;
    public float maxFloatDistance;
    public float timePassed;
    public float duration = 5f;
    private Vector3 firstPosition;
    private Vector3 travelPoint;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 asteroidRadius = new Vector3(maxFloatDistance, maxFloatDistance, 0);
        firstPosition = transform.position;
        travelPoint = new Vector3(Random.Range(-asteroidRadius.x + transform.position.x, asteroidRadius.x + transform.position.x), Random.Range(-asteroidRadius.y + transform.position.y, asteroidRadius.y + transform.position.y), 0);
    }

    // Update is called once per frame
    void Update()
    {
        AsteroidMovement();
    }

    public void AsteroidMovement()
    {
        timePassed += Time.deltaTime;

        float lerpDone = timePassed / 3;
        
        Vector3 asteroidRadius = new Vector3(maxFloatDistance, maxFloatDistance, 0);

        if (lerpDone >= 1)
        {
            travelPoint = new Vector3(Random.Range(-asteroidRadius.x + transform.position.x, asteroidRadius.x + transform.position.x), Random.Range(-asteroidRadius.y + transform.position.y, asteroidRadius.y + transform.position.y), 0);
            timePassed = 0;
        }

        transform.position = Vector3.Lerp(firstPosition, travelPoint, lerpDone);

        firstPosition = transform.position;
    }
}
