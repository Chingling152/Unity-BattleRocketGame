using Entities.Generics;
using UnityEngine;

namespace Entities.Allies
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class Player : BaseInstance 
    {
        private GameObject PlayerCamera;

        new void Start()
        {
            base.Start();
            PlayerCamera = GameObject.FindGameObjectWithTag("MainCamera");
            if (PlayerCamera == null)
                Destroy(gameObject);
        }

        // Update is called once per frame
        new void Update()
        {
            base.Update();

            Target = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Move();

            if (Input.GetKey(KeyCode.Mouse0))
                this.weapon.Shoot(Target);
        }

        void FixedUpdate()
        {
            this.LookTo(this.Target);
        }

        protected override void Move()
        {
            float vertical = Input.GetAxis("Vertical");
            this.GetComponent<Rigidbody2D>().AddForce(PlayerCamera.transform.up * this.Speed * vertical);

            float horizontal = Input.GetAxis("Horizontal");
            this.GetComponent<Rigidbody2D>().AddForce(PlayerCamera.transform.right * this.Speed * horizontal);
        }

    }
}