using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class CameraScript : MonoBehaviour
{
    private Vector3 distance;
    public float maxDistance;
    public Transform target;
    public float angleX = 180;
    public float angleY = 180;
    private float _mouseY;
    private float _mouseX;
    private float _currentPitch;
    private float _currentYaw;
    public float _minYaw;
    public float _maxYaw;
    public float _minPitch;
    public float _maxPitch;
    private float _calculatedYaw;
    // Start is called before the first frame update
    void Start()
    {
        distance = transform.position - target.position;
    }

    private void Update()
    {





        /*AdjustCameraOrientation();*/
        transform.LookAt(target.position);
        distance = transform.position - target.position;
        float distanceX = Mathf.Clamp(distance.x, -maxDistance, maxDistance);
        float distanceY = Mathf.Clamp(distance.y, -maxDistance, maxDistance);
        float distanceZ = Mathf.Clamp(distance.z, -maxDistance, maxDistance);
        distance = new Vector3(distanceX, distance.y, distanceZ);
        if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
        {
              transform.RotateAround(target.position, Vector3.up, Input.GetAxis("Mouse X") * Time.deltaTime * angleX);
              transform.RotateAround(target.position, Vector3.right, Input.GetAxis("Mouse Y") * Time.deltaTime * angleY);
        }
        

    }
    /*
    private void AdjustCameraOrientation()
    {
        // Pitch
        _mouseY = Input.GetAxis("Mouse Y");
        _currentPitch = Mathf.Clamp(_currentPitch - _mouseY, _minPitch, _maxPitch);

        // Yaw
        _mouseX = Input.GetAxis("Mouse X");
        _currentYaw = Mathf.Clamp(_currentYaw - _mouseX, _minYaw, _maxYaw);
        // Add in player's rotation
        _calculatedYaw = target.eulerAngles.y + _currentYaw;

        // Rotate Camera
        this.transform.eulerAngles = new Vector3(_currentPitch, _calculatedYaw, 0.0f);
    }
    
    private void LateUpdate()
    {
    }
    */
    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        transform.position = target.position + distance;
    }

    

    void DistanceChange(float x, float y, float z)
    {

        transform.position = new Vector3(target.position.x + x, transform.position.y + y, target.position.z + z);
    }
}
