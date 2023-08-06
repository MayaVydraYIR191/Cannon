using UnityEngine;

public class Cube : MonoBehaviour
{ 
    public static int count;

    private void Awake()
    {
        count = 0;
    }

    void Update()
    {
        if (gameObject.transform.position.y < 0)
        {
            count++;
            Destroy(gameObject);
        }
    }
}
