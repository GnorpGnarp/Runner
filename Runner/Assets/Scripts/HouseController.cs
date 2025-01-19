using UnityEngine;

public class HouseController : MonoBehaviour
{
    public bool startMove;
    public float moveSpeed;
    public float incrementSpeed;

    private MeshRenderer meshRenderer;  // To reference the mesh renderer
    private Collider houseCollider;     // To reference the collider

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;  // Make sure it doesn't interfere with manual movement
        }
        // Cache the mesh renderer and collider if not already assigned
        meshRenderer = GetComponent<MeshRenderer>();
        houseCollider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startMove)
        {
            // Move both the mesh and the collider together
            moveSpeed += incrementSpeed * Time.deltaTime;
            Vector3 moveVector = new Vector3(0, 0, -1); // Move along Z-axis

            // Move the entire GameObject, including mesh and collider
            transform.Translate(moveVector * Time.deltaTime * moveSpeed);
        }
    }
}
