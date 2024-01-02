using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    private PlayerStats playerStats;
    private float movementSpeed;
    private new Rigidbody rigidbody;
    private PlayerAnimation playerAnimation;
    void Awake()
    {
        playerStats = GetComponent<PlayerStats>();
        rigidbody = gameObject.GetComponent<Rigidbody>();
        playerAnimation = gameObject.GetComponent<PlayerAnimation>();
    }
    private void Start()
    {
        movementSpeed = playerStats.MovementSpeed;
    }
    void Update()
    {

    }
    void FixedUpdate()
    {
        MovePlayer();
    }
    Vector3 InputVector()
    {
        return new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
    }
    void MovePlayer()
    {
        if (InputVector() != Vector3.zero)
        {
            playerAnimation.PlayMovementAnimation();
            rigidbody.MovePosition(rigidbody.position + (InputVector() * movementSpeed));
        }
        else
        {
            playerAnimation.StopMovementAnimation();
        }
    }
}
