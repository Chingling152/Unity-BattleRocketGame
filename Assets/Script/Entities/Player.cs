using UnityEngine;

public sealed class Player : Instance
{

    private GameObject PlayerCamera;

    new void Start()
    {
        base.Start();
        PlayerCamera = GameObject.FindGameObjectWithTag("MainCamera");
        if(PlayerCamera == null)
            Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Target = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Move();


        if (Input.GetKey(KeyCode.Mouse0))
            ship.weapon.Shoot(Target);
    }

    void FixedUpdate()
    {
       ship.LookTo(Target);
    }

    protected override void Move()
    {
        float vertical = Input.GetAxis("Vertical");
        ship.GetComponent<Rigidbody2D>().AddForce(PlayerCamera.transform.up * ship.Speed * vertical);

        float horizontal = Input.GetAxis("Horizontal");
        ship.GetComponent<Rigidbody2D>().AddForce(PlayerCamera.transform.right * ship.Speed * horizontal);
    }
}
