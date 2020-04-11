using UnityEngine;

public sealed class Ship : Entity
{
    public Weapon weapon;

    public float Speed;

    private Instance Owner;

    private void Start()
    {
        weapon = gameObject.GetComponentInChildren<Weapon>();
        Owner = gameObject.GetComponentInParent<Instance>();

        if(Owner == null)
            Destroy(this);
    }

    public void LookTo(Vector3 target)
    {
        weapon.transform.rotation = Quaternion.LookRotation(weapon.transform.position - target, Vector3.forward);
        weapon.transform.eulerAngles = new Vector3(0, 0, weapon.transform.eulerAngles.z +90.0f);
    }

}
