using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private GameObject objectToAttach;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            objectToAttach.transform.SetParent(this.transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            objectToAttach.transform.parent = null;
        }
    }
}
