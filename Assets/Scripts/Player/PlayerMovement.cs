using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    private Vector3 velocity;

    public float speed = 12f;
    public float gravity = -4f; //defaullt unity gravity speed -9.81f (kurva gyors)

    private Animator pAnimator;

    private void Start()
    {
        pAnimator = GetComponent<Animator>();
    }
    private void Movement(float inputX, float inputZ)
    {
        Vector3 move = transform.right * inputX + transform.forward * inputZ;
        controller.Move(move * speed * Time.deltaTime);
        pAnimator.SetBool("isMoving", true);
    }

    private void Gravity()
    {
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Movement(x, z);
        Gravity();
    }
}
