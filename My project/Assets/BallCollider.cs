using UnityEngine;

public class BallCollider : MonoBehaviour
{
    public Rigidbody sphereRigidbody;
    public float ballSpeed = 2f;
    public float jumpForce = 5f; // Add a variable for jump force

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Calling the Start method");
    }

    // Update is called once per frame
    void Update(){
        Vector2 inputVector = Vector2.zero; // intialize our input vector
        if (Input.GetKey(KeyCode.W)){
            inputVector += Vector2.up; // "a += b" <=> "a = a + b"
        }
        if (Input.GetKey(KeyCode.S)){
            inputVector += Vector2.down;
        }
        if (Input.GetKey(KeyCode.D)){
            inputVector += Vector2.right;
        }
        if (Input.GetKey(KeyCode.A)){
            inputVector += Vector2.left;
        }
    
        Vector3 inputXZPlane = new Vector3(inputVector.x, 0, inputVector.y);
        sphereRigidbody.AddForce(inputXZPlane * ballSpeed);
        Debug.Log("Resultant Vector: " + inputVector);
        Debug.Log("Resultant 3D Vector: " + inputXZPlane);
        // Check for space key press to jump for extra points
        if (Input.GetKeyDown(KeyCode.Space)){
            sphereRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
