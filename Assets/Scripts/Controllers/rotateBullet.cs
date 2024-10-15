using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateBullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0 * Time.deltaTime, 0 * Time.deltaTime, 10 * Time.deltaTime) ;
    }
}
