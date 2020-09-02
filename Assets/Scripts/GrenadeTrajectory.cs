using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeTrajectory : MonoBehaviour
{

    public GameObject point;
    public GameObject[] points;
    public int numberOfPoint = 20;
    public float force = 50f;
    public float time = 0.05f;
    public float scaleFactor = 2f;
    public GameObject trajectory;
    // Start is called before the first frame update
    void Start()
    {
        points = new GameObject[numberOfPoint];

        for(int i = 0;i< numberOfPoint; i++)
        {
            points[i] = Instantiate(point, trajectory.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < points.Length; i++)
        {
            points[i].transform.position = PointPosition((i + 1) * time);
            points[i].transform.localScale = new Vector3(0.1f, 0.1f, 0.1f) * (scaleFactor);
        }
    }

    Vector3 PointPosition(float t)
    {
        Vector3 currentPointPos = transform.position + (transform.forward.normalized * force * t) + 0.5f * Physics.gravity * (t * t);
        return currentPointPos;
    }
}
