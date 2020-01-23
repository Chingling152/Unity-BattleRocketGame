using UnityEngine;

class Bullet : MonoBehaviour
{
    private float Timer = 0;
    public float MaxTimer = 5f;

    [SerializeField]
    private float MaxSpeed = 5f;

    // Update is called once per frame
    void Update()
    {
        Vector3 speed = new Vector3(0, MaxSpeed * Time.deltaTime, 0);
        transform.position += transform.rotation * speed;
        Timer += Time.deltaTime * 10;

        if(Timer > MaxTimer)
            Destroy(gameObject);

    }
}

