using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField]
    private int Ammo;

    private float FireRate;
    public int Cadency;

    public GameObject Bullet;


    // Update is called once per frame
    void Update()
    {
        LookToMouse();
        if (FireRate < Cadency)
        {
            FireRate += Time.deltaTime * 10;
        }
        else if (Input.GetKey(KeyCode.Mouse0) && Ammo > 0)
        {
            Shoot();
            FireRate = 0;
            Ammo--;
        }

    }

    void LookToMouse()
    {
        Vector3 mouseposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Quaternion rot = Quaternion.LookRotation(transform.position - mouseposition, Vector3.forward);

        transform.rotation = rot;
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z + 90.0f);
    }

    void Shoot()
    {
        var mouseposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Quaternion rot = Quaternion.LookRotation(transform.position - mouseposition, Vector3.forward);
        Instantiate(Bullet, gameObject.transform.GetChild(0).position, rot);
    }
}
