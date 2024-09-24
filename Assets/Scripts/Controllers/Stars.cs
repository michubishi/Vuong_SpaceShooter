using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class Stars : MonoBehaviour
{
    public List<Transform> starTransforms;
    public float drawingTime = 2f;
    public int firstPoint = 0;
    public int nextPoint = 1;
    public float timePassed;

    // Update is called once per frame
    void Update()
    {
        DrawConstellation();
    }

    public void DrawConstellation()
    {

        foreach (Transform star in starTransforms)
        {
            timePassed += Time.deltaTime;

            if(timePassed >= drawingTime)
            {
                Vector3 distance1 = new Vector3(starTransforms.ElementAt(firstPoint).transform.position.x, starTransforms.ElementAt(firstPoint).transform.position.y, 0);
                Vector3 distance2 = new Vector3(starTransforms.ElementAt(nextPoint).transform.position.x, starTransforms.ElementAt(nextPoint).transform.position.y, 0);

                Debug.DrawLine(distance1, distance2, Color.red);
                if (firstPoint > starTransforms.ElementAt(6).transform.position.x && nextPoint > starTransforms.ElementAt(6).transform.position.x && firstPoint > starTransforms.ElementAt(6).transform.position.y && nextPoint > starTransforms.ElementAt(5).transform.position.y)
                {
                    firstPoint = 0;
                    nextPoint = 1;
                }

                firstPoint = firstPoint + 1;
                nextPoint = nextPoint + 1;
                print(firstPoint);
                print(nextPoint);
                timePassed = 0;

                
            }
           

            




        }

    }
}
