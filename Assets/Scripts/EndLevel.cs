using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    [SerializeField]
    private bool isLastLevel;
    [SerializeField]
    private string nextLevelName;

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player"))    
        {
            if (isLastLevel == true)
                SceneManager.LoadScene("GameOver");
            else
                SceneManager.LoadScene(nextLevelName);
        }
    }
}
