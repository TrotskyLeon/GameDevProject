using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform playerToFollow;

    Camera cam;

    private float targetZoom;

    private float zoomFactor = 2f;
    private float lerpFactor = 8f;
    private float maxZoom = 8f;
    private float minZoom = 4.5f;

    private bool fixedState;

    // Start is called before the first frame update
    void Start()
    {
        cam = this.GetComponent<Camera>();
        targetZoom = cam.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (fixedState == false)
        {
            transform.position = new Vector3(playerToFollow.position.x, playerToFollow.position.y, -10);

            float scrollData;
            scrollData = Input.GetAxis("Mouse ScrollWheel");

            targetZoom -= scrollData * zoomFactor;
            targetZoom = Mathf.Clamp(targetZoom, minZoom, maxZoom);

            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetZoom, Time.deltaTime * lerpFactor);
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            toggleState();
        }
    }

    void toggleState()
    {
        fixedState = !fixedState;

        if (fixedState == true)
        {
            transform.position = new Vector3(0, 0, -10);
            cam.orthographicSize = maxZoom;
        }
    }
}
