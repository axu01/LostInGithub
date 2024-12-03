using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange1 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject SceneWip;
    public void SceneChanged()
    {
        print("Button licked");
        SceneManager.LoadScene("ButtonTestDraft2");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
