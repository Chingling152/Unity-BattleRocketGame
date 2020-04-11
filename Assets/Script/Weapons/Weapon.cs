using UnityEngine;

public sealed class Weapon : MonoBehaviour
{

    private float FireRate;

    [SerializeField]
    private int Cadency;

    [SerializeField]
    private int Ammo;

    [SerializeField]
    private Bullet bullet;


    private Entity owner;

    void Start()
    {
        owner = gameObject.GetComponentInParent<Entity>();
    }

    // Update is called once per frame
    void Update()
    {
        if (FireRate < Cadency)
            FireRate += Time.deltaTime * 10;
    }

    public void Shoot(Vector3 target)
    {
        if(Ammo > 0 && FireRate > Cadency)
        {
            Quaternion rot = Quaternion.LookRotation(target - transform.position , Vector3.forward);
            Instantiate(bullet, transform.GetChild(0).position, transform.rotation).Owner = this.owner;
            FireRate= 0;
            Ammo--;
        }
    }

}
