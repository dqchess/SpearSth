﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraWaypoint : MonoBehaviour
{
    public GameObject prevCameraPos;
    public GameObject nextCameraPos;
    public bool StartingWaypoint;


    private GameObject camera;
    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("MegaCamera");

        if (StartingWaypoint)
        {
            float newX = camera.transform.position.x - prevCameraPos.transform.position.x;
            float newY = camera.transform.position.y - prevCameraPos.transform.position.y;
            camera.transform.Translate(-newX, -newY, 0.0f);
            camera.GetComponent<GameManager>().curCameraPos = nextCameraPos;
        }
        if (nextCameraPos.tag == "CameraPosition")
        {
            Debug.Log("tagem and bag em");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("passed");
            //These are some pretty beefy if statments. The movement of the camera is not perfect, so the if statements give a little wiggle room for camera if it misses slightly
            if ((camera.transform.position.x <= prevCameraPos.transform.position.x + 0.1f && camera.transform.position.x >= prevCameraPos.transform.position.x - 0.1f)
                && camera.transform.position.y <= prevCameraPos.transform.position.y + 0.1f && camera.transform.position.y >= prevCameraPos.transform.position.y - 0.1f)
            {
                Debug.Log("go foreward");
                float newX = prevCameraPos.transform.position.x - nextCameraPos.transform.position.x;
                float newY = prevCameraPos.transform.position.y - nextCameraPos.transform.position.y;
                camera.transform.Translate(-newX, -newY, 0.0f);
                camera.GetComponent<GameManager>().curCameraPos = nextCameraPos;
            }
            else if ((camera.transform.position.x <= nextCameraPos.transform.position.x + 0.1f && camera.transform.position.x >= nextCameraPos.transform.position.x - 0.1f)
                && camera.transform.position.y <= nextCameraPos.transform.position.y + 0.1f && camera.transform.position.y >= nextCameraPos.transform.position.y - 0.1f)
            {
                Debug.Log("go back");
                float newX = prevCameraPos.transform.position.x - nextCameraPos.transform.position.x;
                float newY = prevCameraPos.transform.position.y - nextCameraPos.transform.position.y;
                camera.transform.Translate(newX, newY, 0.0f);
                camera.GetComponent<GameManager>().curCameraPos = prevCameraPos;
            }
            //Debug.Log(prevCameraPos.transform.position.x);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("PK Leave");

    }
}