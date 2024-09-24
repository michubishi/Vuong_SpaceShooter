using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;
    public Vector3 velocity;
    public float maxSpeed = 1f;
    public float accelerationTime;


    void Update()
    {
        PlayerMovement();

    }

    public void PlayerMovement()
    {

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            accelerationTime += Time.deltaTime;
            transform.position += transform.position + (velocity = new Vector3(maxSpeed - 0.01f/accelerationTime, 0f));
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = transform.position + (velocity = new Vector3(0.01f, 0f));
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position = transform.position + (velocity = new Vector3(0f, 0.01f));
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position = transform.position + (velocity = new Vector3(0f, -0.01f));
;        }
    }

}
