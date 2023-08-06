using UnityEngine;
public class CannonBullet : MonoBehaviour
{
    private static float speed = 10f;
    public float lifeTime = 2;
    public static float power;

    void Update()
    {
        power += Time.deltaTime;
        transform.Translate(Vector3.forward *(speed*power/2)*  Time.deltaTime);
        lifeTime -= Time.deltaTime;
        if (lifeTime < 0)
        {
            Destroy(gameObject);
        }
    }
}

