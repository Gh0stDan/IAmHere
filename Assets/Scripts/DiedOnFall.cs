using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiedOnFall : MonoBehaviour
{
 

    private void Start()
    {
        Transform transform = GetComponent<Transform>();
    }
    

    
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -7)
        {
      
            SceneManager.LoadScene("GameOver");
        }
    }
}
