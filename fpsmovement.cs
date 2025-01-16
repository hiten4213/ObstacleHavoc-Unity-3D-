using UnityEngine;

public class FPSController : MonoBehaviour
{
    [SerializeField] private float speed = 6f;
    [SerializeField] private float jumpForce = 2f;
    [SerializeField] private float sensitivity = 2f;
    [SerializeField] private bool invertY = false; // Add a serialized field for inverting Y axis

    public Transform cameraTransform;
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float fireRate = 0.2f;

    private float nextFireTime = 0f;
    private CharacterController characterController;
    private float xRotation = 0f; // For camera clamping

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Look around
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        xRotation -= mouseY * (invertY ? 1 : -1); // Invert Y axis if desired
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Clamp camera angle

        transform.Rotate(Vector3.up * mouseX);
        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 moveDirection = transform.right * horizontalInput + transform.forward * verticalInput;
        characterController.Move(moveDirection * speed * Time.deltaTime);

        // Jumping
        if (Input.GetButtonDown("Jump") && characterController.isGrounded)
        {
            characterController.Move(Vector3.up * jumpForce * Time.deltaTime);
        }

        // Shooting
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            Instantiate(bulletPrefab, bulletSpawnPoint.position, cameraTransform.rotation);
        }
    }
}
