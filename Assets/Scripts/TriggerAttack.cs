
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerAttack : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("Derrota");
        }
    }
}
