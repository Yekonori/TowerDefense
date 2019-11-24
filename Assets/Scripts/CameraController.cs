using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Attributes")]
    public float panSpeed = 30f;
    public float panBorderThickness = 10f;

    public float scrollSpeed = 5f;

    public float minY = 10f;
    public float maxY = 80f;

    [Header("Unity Setup")]
    public KeyCode lockMoveKey;
    private bool _doMovement = true;

    // Update is called once per frame
    void Update()
    {
        _UpdateLockMovement();

        if (!_doMovement)
        {
            return;
        }

        //_UpdateMovement();
        _UpdateScrollWheel();
    }

    private void _UpdateLockMovement()
    {
        if (Input.GetKeyDown(lockMoveKey))
        {
            _doMovement = !_doMovement;
        }
    }

    private void _UpdateMovement()
    {
        float xMov = Input.GetAxis("Horizontal");
        float yMov = Input.GetAxis("Vertical");

        // Top
        if (yMov > 0 || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }

        // Bottom
        if (yMov < 0 || Input.mousePosition.y <= panBorderThickness)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

        // Left
        if (xMov < 0 || Input.mousePosition.x <= panBorderThickness)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }

        // Right
        if (xMov > 0 || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
    }

    private void _UpdateScrollWheel()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 newPos = transform.position;
        newPos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        newPos.y = Mathf.Clamp(newPos.y, minY, maxY);

        transform.position = newPos;
    }
}
