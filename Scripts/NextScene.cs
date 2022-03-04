using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    //public int levelToLoad = 1;

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            SceneManager.LoadScene("Main");
        }
    }

}
