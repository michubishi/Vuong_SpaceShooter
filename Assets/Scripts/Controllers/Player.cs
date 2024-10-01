using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public GameObject powerupPrefab;
    public Transform bombsTransform;
    public Vector3 velocity;
    public float maxSpeed = 1f;
    public float accelerationTime;
    public List<float> points = new List<float>();
    public List<float> bombPoints = new List<float>();



    void Update()
    {
        PlayerMovement();
        EnemyRadar(1, 6);

        if (Input.GetKeyDown(KeyCode.O))
        {
            SpawnPowerUps(1, 5);
        }
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
;       }

        if (Input.GetKey(KeyCode.P))
        {

        }
    }

    public void EnemyRadar(float radius, int circlePoints)
    {
        int angle = 360/circlePoints;

        for (int i = 0; i <= circlePoints; i++) 
        {
            float radian = Mathf.Rad2Deg * angle;

            Vector3 point = new Vector3(Mathf.Cos(radian), Mathf.Sin(radian)) * radius;
            Debug.DrawLine(transform.position, transform.position + point, Color.red);

            angle = angle + circlePoints*10;
        }
    }

    public void SpawnPowerUps(float radius, int numberOfPowerUps)
    {
        int angle = 360 / numberOfPowerUps;

        for (int i = 0; i <= numberOfPowerUps; i++)
        {
            float radian = Mathf.Rad2Deg * angle;

            Vector3 powerUpPoint = new Vector3(Mathf.Cos(radian), Mathf.Sin(radian)) * radius;
            Instantiate(powerupPrefab, transform.position + powerUpPoint, powerupPrefab.transform.rotation);

            angle = angle + numberOfPowerUps * 10;
        }
    }
}
