using UnityEngine; //always call UnityEngine at the top of your script, it is the main library for Unity

public class PlayerMovement : MonoBehaviour //the name of the class must match the name of the script file
{
    public float moveSpeed = 1; //the speed at which the player moves
    public float sprintSpeed = 8f; //the speed at which the player sprints

    public Transform cameraTransform; //the transform of the player's camera, used for looking around
    public float mouseSensitivity = 100f; //the sensitivity of the mouse movement for looking around
    public bool lockCursor = true; // whether to lock the cursor to the center of the screen and hide it

    private CharacterController controller; // the CharacterController component attached to the player, used for movement
    private Vector3 velocity; // the velocity of the player, used for applying gravity and movement
    private float xRotation = 0f; // the current rotation around the x-axis for looking up and down
    private float currentSpeed; //  the current speed of the player, which can change when sprinting

    void Start() // Start is called before the first frame update, used for initialization
    {
        controller = GetComponent<CharacterController>(); // get the CharacterController component attached to the player
        currentSpeed = moveSpeed; // initialize current speed to the normal move speed

        if (lockCursor) // if lockCursor is true, lock the cursor to the center of the screen and hide it
        {
            Cursor.lockState = CursorLockMode.Locked; // lock the cursor to the center of the screen
            Cursor.visible = false; //  hide the cursor
        }
    } 

    void Update() // Update is called once per frame, used for handling input and movement
    {
        float mouseX = Input.GetAxis("Mouse X"); // get the horizontal mouse movement for looking around
        float mouseY = Input.GetAxis("Mouse Y"); // get the vertical mouse movement for looking around

        xRotation -= mouseY; // subtract mouseY from xRotation to look up and down
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // clamp xRotation to prevent looking too far up or down

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // set the local rotation of the camera to the xRotation for looking up and down
        transform.Rotate(Vector3.up * mouseX); // rotate the player around the y-axis based on mouseX for looking left and right

        float x = Input.GetAxis("Horizontal"); // get the horizontal input for movement (A/D or left/right arrow keys)
        float z = Input.GetAxis("Vertical"); // get the vertical input for movement (W/S or up/down arrow keys)

        if (Input.GetKey(KeyCode.LeftShift)) // if the left shift key is held down, set current speed to sprint speed
        {
            currentSpeed = sprintSpeed; // set current speed to sprint speed
        }
        else // if the left shift key is not held down, set current speed to normal move speed
        {
            currentSpeed = moveSpeed; // set current speed to normal move speed
        }

        Vector3 move = transform.right * x + transform.forward * z; // calculate the movement direction based on the player's orientation and input, using transform.right for horizontal movement and transform.forward for vertical movement
        controller.Move(move * currentSpeed * Time.deltaTime); // move the player based on the input and current speed, multiplied by Time.deltaTime to make it frame rate independent
    }
}
