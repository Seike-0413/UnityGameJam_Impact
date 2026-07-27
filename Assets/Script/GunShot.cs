using UnityEngine;
using UnityEngine.InputSystem;

public class GunShot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float speed = 500f;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame ||
    (Gamepad.current != null && Gamepad.current.rightTrigger.wasPressedThisFrame))
        {
            GameObject bullet = Instantiate(
                bulletPrefab,
                firePoint.position,
                firePoint.rotation);

            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.linearVelocity = firePoint.forward * speed;

            Destroy(bullet, 5f);
        }
    }
}
