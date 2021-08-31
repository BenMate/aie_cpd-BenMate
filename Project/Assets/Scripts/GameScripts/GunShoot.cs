
using UnityEngine;

public class GunShoot : MonoBehaviour
{
    public float damage = 10.0f;
    
    public Transform firePoint;
    public GameObject bulletPreFab;

    public float bulletForce = 20.0f;


    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButtonDown("Fire1"))
        {
            if (Time.timeScale > 0)
            {
                Shoot();
            }
           
        }      
    }

    void Shoot()
    {
        //RaycastHit hit;
        //Physics.Raycast()


        GameObject bullet = Instantiate(bulletPreFab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode.Impulse);

    }

}
