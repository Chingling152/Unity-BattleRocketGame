using UnityEngine;

public class Player : Entity
{

    private GameObject Camera;
    private Ship ship;

    void Start()
    {
        ship = gameObject.GetComponentInChildren<Ship>();
        Camera = GameObject.FindGameObjectWithTag("MainCamera");
        if(ship == null || Camera == null)
            Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        ship.GetComponent<Rigidbody2D>().AddForce(Camera.transform.up * ship.Speed * vertical);

        float horizontal = Input.GetAxis("Horizontal");
        ship.GetComponent<Rigidbody2D>().AddForce(Camera.transform.right * ship.Speed * horizontal);
    }

}
