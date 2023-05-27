using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 180.0f;
    [SerializeField] private int collectPoints = 1;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerScore.Instance.AdjustScore(collectPoints);
            Destroy(gameObject);
        }
    }
}
