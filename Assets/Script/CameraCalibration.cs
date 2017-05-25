using UnityEngine;
using System.Collections;

public class CameraCalibration : MonoBehaviour {


    private Camera camera;
    private bool boost = false;
    private FileSaver fileSaver;

    public float zoomSpeed = 1f;
    public float moveSpeed = 1f;

    public float boostMultiplier = 2f;
    public float PerspectiveBoost = 10f;

    // Use this for initialization
    void Start () {
        camera = GetComponent<Camera>();
        fileSaver = new FileSaver();
    }

    // Update is called once per frame
    void Update () {

        if (Input.GetKey("space")){ boost = true;}
        else{ boost = false; }

        if (Input.GetKey("q"))
        {
            if (camera.orthographic)
            {
                camera.orthographicSize += zoomSpeed * Time.deltaTime;
                if(boost)
                    camera.orthographicSize += zoomSpeed * Time.deltaTime * boostMultiplier;
            }
            else
            {
                camera.fieldOfView += zoomSpeed * Time.deltaTime;
                if (boost)
                    camera.fieldOfView += zoomSpeed * PerspectiveBoost * Time.deltaTime;
            }

        }

        if (Input.GetKey("e"))
        {
            if (camera.orthographic)
            {
                camera.orthographicSize -= zoomSpeed * Time.deltaTime;
                if (boost)
                    camera.orthographicSize -= zoomSpeed * Time.deltaTime * boostMultiplier;
            }
            else
            {
                camera.fieldOfView -= zoomSpeed * Time.deltaTime;
                if (boost)
                    camera.fieldOfView -= zoomSpeed * PerspectiveBoost * Time.deltaTime;
            }

        }

        if (boost)
        {
            this.transform.position += new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"))
                                     * moveSpeed 
                                     * Time.deltaTime
                                     * boostMultiplier;
        }
        else
        {
            this.transform.position += new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"))
                                    * moveSpeed 
                                    * Time.deltaTime;
        }

        if (Input.GetKeyDown("f5"))
        {
            if(camera.orthographic)
                fileSaver.saveCameraPosition(camera.transform.position, camera.orthographicSize);
            else
                fileSaver.saveCameraPosition(camera.transform.position, camera.fieldOfView);
        }
        if (Input.GetKeyDown("f9"))
        {
            ArrayList read = fileSaver.loadCameraPosition();
            if (camera.orthographic)
            {
                camera.transform.position = (Vector3)read[0];
                camera.orthographicSize = (float)read[1];
            }
            else
            {
                camera.transform.position = (Vector3)read[0];
                camera.fieldOfView = (float)read[1];
            }
        }

    }

    private void changeFOV()
    {

    }
}
