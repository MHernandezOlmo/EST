using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartOnCollision : MonoBehaviour
{
    public void OnTriggerEnter(Collider collider)
    {
        
        if (collider.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<PlayerController>().ReceiveDamage(1999);
            //GameEvents.LoadScene.Invoke(SceneManager.GetActiveScene().name);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        print(collision.collider.gameObject);
        //if (collider.gameObject.CompareTag("Player"))
        //{
        //    FindObjectOfType<PlayerController>().ReceiveDamage(1999);
        //    Destroy(gameObject);
        //    //GameEvents.LoadScene.Invoke(SceneManager.GetActiveScene().name);
        //}
    }
    //private void OnCollisionEnter(Collision collider)
    //{
    //   
    //}

}
