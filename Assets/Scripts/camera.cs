
//46.156 -107.26 32.837

using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private Transform target;
    [SerializeField] private float distanceToTarget ;

    private Vector3 previousPosition;
    private void Start()
    {
           //Cursor.visible = false; 
    }
    private void LateUpdate()
    {
       //////////////// transform.Rotate(0, Space.World, 0, Space.World);
        if (Input.GetMouseButtonDown(0))
        {
            previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 newPosition = cam.ScreenToViewportPoint(Input.mousePosition);
            Vector3 direction = previousPosition - newPosition;

            float rotationAroundYAxis = -direction.x * 180; // camera moves horizontally
            float rotationAroundXAxis = direction.y * 180; // camera moves vertically

           // cam.transform.position = target.position;
            
            target.transform.Rotate(new Vector3(1, 0, 0), rotationAroundXAxis);
            target.transform.Rotate(new Vector3(0, 1, 0), rotationAroundYAxis, Space.World);
            
           // cam.transform.Translate(new Vector3(0, 0, -distanceToTarget));

            previousPosition = newPosition;
        }
    }
}