using System;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
   /// <summary>
   /// private Vector2 bounds;
   /// </summary>
   // private float obWidth;
   // private float obheight;
    public float minX = -10f, maxX = 10f, minY = -5f, maxY = 4f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        //obWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        //obheight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 viewPosition = transform.position;
        viewPosition.x = Mathf.Clamp(viewPosition.x, minX, maxX);
        viewPosition.y = Mathf.Clamp(viewPosition.y, minY, maxY);
        transform.position = viewPosition;

    }
}
