
using UnityEngine;

public class GunShoot : MonoBehaviour
{
    public float damage = 10.0f;
    
    public Transform firePoint;
    public GameObject bulletPreFab;
    public Camera cam;
    public float bulletForce = 20.0f;

    Vector3 worldMousePos = Vector3.zero;


    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        LookControls();

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
        GameObject bullet = Instantiate(bulletPreFab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);
    }

    void LookControls()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, int.MaxValue))
        {
            worldMousePos = hit.point;
        }

        if (Time.timeScale > 0)
        {
            firePoint.transform.LookAt(new Vector3(worldMousePos.x, firePoint.transform.position.y, worldMousePos.z)); 

            //aimbot
            //if (ZombieManager.instance.zombiePositions.Count > 0)
            //{
            //    Vector3 pos = ZombieManager.instance.zombiePositions[0].position;
            //    firePoint.transform.LookAt(new Vector3(pos.x,firePoint.transform.position.y,pos.z));
            //}
            
        }

    }

}
