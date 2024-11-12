using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonclicc : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject OnClickPopup;
    public void ButtonClicked()
    {
        print("button smashed");
        SceneManager.LoadScene("rollaball");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
