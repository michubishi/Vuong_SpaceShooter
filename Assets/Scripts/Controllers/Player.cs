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
    public List<float> points = new List<float>();



    void Update()
    {
        PlayerMovement();
        EnemyRadar(1, 6);
    }

    public void PlayerMovement()
    {

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = transform.position + (velocity = new Vector3(-0.01f, 0f));
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

    public void EnemyRadar(float radius, int circlePoints)
    {
        int angle = 360 / circlePoints;

        for (int i = 0; i < circlePoints; i++) 
        {
            Vector3 point = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle)) * radius * Mathf.Rad2Deg;
            Debug.DrawLine(transform.position, point, Color.red);
            angle = angle + angle;
        }
    }
}
