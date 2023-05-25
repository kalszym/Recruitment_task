using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static float pointToEnd;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        pointToEnd = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if(pointToEnd ==0)
        {
            
            UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
        }
    }

}
