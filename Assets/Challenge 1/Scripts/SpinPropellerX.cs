using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{

    public float speed = 2000f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.back * speed * Time.deltaTime);
    }
}
