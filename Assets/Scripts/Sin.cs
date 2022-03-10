using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sin : MonoBehaviour
{
    Vector3 tempPosition;
    Vector3 offset;
    private void Awake()
    {
        offset = transform.position;
        tempPosition = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        tempPosition.y = Mathf.Sin(Time.time);
        transform.position = tempPosition + offset;
    }
}
