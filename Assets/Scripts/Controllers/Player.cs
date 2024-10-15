using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public GameObject energyPrefab;
    public GameObject missilePrefab;
    public Transform bombsTransform;

    public float accelerationTime = 1f;
    public float decelerationTime = 1f;
    public float maxSpeed = 7.5f;
    public float turnSpeed = 180f;

    private float acceleration;
    private float deceleration;
    private Vector3 currentVelocity;
    private float maxSpeedSqr;

    private void Start()
    {
        acceleration = maxSpeed / accelerationTime;
        deceleration = maxSpeed / decelerationTime;
        maxSpeedSqr = maxSpeed * maxSpeed;
    }

    void Update()
    {
        MoveSpaceShip();
        //SpinningEnergy(2, new Vector3(2, 2, 0), 2);
        AimShoot();
    }

    public void MoveSpaceShip()
    {
        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
            moveDirection += Vector3.up;
        if (Input.GetKey(KeyCode.S))
            moveDirection += Vector3.down;

        if (Input.GetKey(KeyCode.D))
            moveDirection += Vector3.right;
        if (Input.GetKey(KeyCode.A))
            moveDirection += Vector3.left;

        if (moveDirection.sqrMagnitude > 0)
        {
            currentVelocity += Time.deltaTime * acceleration * moveDirection;
            if (currentVelocity.sqrMagnitude > maxSpeedSqr)
            {
                currentVelocity = currentVelocity.normalized * maxSpeed;
            }
        }
        else
        {
            Vector3 velocityDelta = Time.deltaTime * deceleration * currentVelocity.normalized;
            if (velocityDelta.sqrMagnitude > currentVelocity.sqrMagnitude)
            {
                currentVelocity = Vector3.zero;
            }
            else
            {
                currentVelocity -= velocityDelta;
            }
        }

        transform.position += currentVelocity * Time.deltaTime;
    }

    public void SpinningEnergy(int numBullets, Vector3 speed, float radius)
    {
        float angle = (360 / numBullets) * Mathf.Deg2Rad;
        Vector3 point2 = new Vector3(0, 1, 0);

        Vector3 point = new Vector3(Mathf.Cos(angle) * radius, Mathf.Sin(angle) * radius) * Mathf.Rad2Deg;

        for (int i = 0; i < numBullets; i++)
        {
            Instantiate(energyPrefab, transform.position + point2, transform.rotation);
            energyPrefab.transform.Rotate(0, 1, 0);
            angle = angle + angle;
        }


    }

    public void AimShoot()
    {
        Vector3 endPoint = new Vector3(transform.position.x, transform.position.y + 4, transform.position.z);
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.DrawLine(transform.position, endPoint);
            if (Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.RightArrow))
            {
                Vector3 point = new Vector3(transform.position.x + 3, transform.position.y + 3);

                Debug.DrawLine(transform.position, point);
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    Instantiate(missilePrefab, point + transform.position, transform.rotation);
                }
            }

            if (Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.LeftArrow))
            {
                Vector3 point = new Vector3(transform.position.x - 3, transform.position.y + 3);

                Debug.DrawLine(transform.position, point);
            }
        }
    }

    

}
