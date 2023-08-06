using UnityEngine;

public class CannonController : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 10f;
    [SerializeField] private Camera followCamera;
    public GameObject shot;
    public Transform shotPoint;
    [SerializeField] private GameObject victory;

    void Update()
    {
        float horizonInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movementInput = Quaternion.Euler(0, followCamera.transform.eulerAngles.y, 0) *
                                new Vector3(horizonInput, 0, verticalInput);
        Vector3 upDown = Quaternion.Euler(verticalInput, 0, followCamera.transform.eulerAngles.z) *
                         new Vector3(0, verticalInput, 0);
        Vector3 movementDirection = movementInput.normalized;
        Vector3 movUp = upDown.normalized;
        if (movementDirection != Vector3.zero)
        {
            Quaternion desiredRotate = Quaternion.LookRotation(movementDirection, movUp);
            transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotate, rotationSpeed * Time.deltaTime);
        }

        shotPoint.rotation = gameObject.transform.rotation;
        if (Input.GetKey(KeyCode.F))
        {
            CannonBullet.power += Time.deltaTime;
            
            if (Input.GetKeyDown(KeyCode.H))
            {
                Instantiate(shot, shotPoint.position, shotPoint.rotation);
                CannonBullet.power = 0;
            }
        }

        if (Cube.count == 3)
        {
            victory.SetActive(true);
        }
    }


}
