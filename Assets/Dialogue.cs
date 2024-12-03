using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class Dialogue : MonoBehaviour
{
    // Start is called before the first frame update
    public List<string> goodNarratorstrings;
    public List<string> badNarratorstrings;
    public TMP_Text goodNarratorBox;
    public TMP_Text badNarratorBox;
    public int GoodIndex;
    public int BadIndex;
    void Start()
    {
        goodNarratorBox.text = goodNarratorstrings[GoodIndex];
        badNarratorBox.text = badNarratorstrings[BadIndex];
        badNarratorBox.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GoodIndex < goodNarratorstrings.Count)
        {
            if (Input.GetKeyDown("space"))
            {
                print("sigh");
                //goodNarratorBox.text = goodNarratorstrings[GoodIndex = GoodIndex + 1];
                goodNarratorBox.text = goodNarratorstrings[GoodIndex];

                GoodIndex = GoodIndex + 1;

            }
        }
     

        if (GoodIndex == goodNarratorstrings.Count & BadIndex < badNarratorstrings.Count) 
        {
            goodNarratorBox.enabled = false;
            badNarratorBox.enabled = true;
            
            if (Input.GetKeyDown("space"))
            {
                print("sigh");
                //goodNarratorBox.text = goodNarratorstrings[GoodIndex = GoodIndex + 1];
                badNarratorBox.text = badNarratorstrings[BadIndex];

                BadIndex = BadIndex + 1;

            }

        }

        //if (Input.GetKeyDown("y"))
        //{
            //print("how do i put a cap on this???");
            //badNarratorBox.text = badNarratorstrings[BadIndex + 1];
        //}


    }

 


    
}
