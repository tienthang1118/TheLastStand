using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [Header("Ray from mouse distance")]
    [SerializeField]
    private float rayDistance;

    [Header("Player turning speed")]
    [SerializeField]
    private float turningSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ChangeRotation();
    }
    Vector3 RayHitPosition()
    {
        Ray rayFromMouse = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit rayHitPosition; 
        if (Physics.Raycast(rayFromMouse, out rayHitPosition, rayDistance))
        {
            return new Vector3(rayHitPosition.point.x, transform.position.y, rayHitPosition.point.z);
        }
        else
        {
            return transform.position;
        }
    }
    void ChangeRotation()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(RayHitPosition() - transform.position), Time.deltaTime * turningSpeed);
    }
}
