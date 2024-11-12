using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{

    public Material OneMaterial;
    public Material TwoMaterial;
    public Material ThreeMaterial;

    public Color PlayersColor_1;
    public Color PlayersColor_2;
    public Color PlayersColor_3;

    public Renderer myRenderer;

    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<Renderer>();
        // print(myRenderer.material.name +"  ....myRenderer in Start() ChangeMaterial.cs");

    
        // Assign value to OneRenderer: use the current Material 
        OneMaterial = myRenderer.material;
        Color currentColor = myRenderer.material.GetColor("_Color");
        // print(currentColor+"  myRenderer.material.GetColor(_Color) in ChangeMaterial.cs)");
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            OneMaterial.SetColor("_Color", new Color(0.1f, 0.1f, 0.1f));
            Color currentColor = myRenderer.material.GetColor("_Color");
            print(currentColor+"  SPACE PRESSED:  myRenderer.material.GetColor(_Color) in ChangeMaterial.cs)");
        }
    
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            myRenderer.material = TwoMaterial;
            Color currentColor = myRenderer.material.GetColor("_Color");
            print(currentColor+"  LeftShift Pressed:  myRenderer.material.GetColor(_Color) in ChangeMaterial.cs)");
        }

    }

    public void ColorPickingButton(int numberOfButton)
    {
        if(numberOfButton == 1)
        {
            myRenderer.material.SetColor("_Color", PlayersColor_1);
        }
        if(numberOfButton == 2)
        {
            myRenderer.material.SetColor("_Color", PlayersColor_2);
        }
        if(numberOfButton == 3)
        {
            myRenderer.material.SetColor("_Color", PlayersColor_3);
        }
    }

    public void OnCollisionEnter()
    {
        print("OnCollisionEnter() on the Cube ....!!");
    }

}
