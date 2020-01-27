using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenMenus : MonoBehaviour
{
    public List<Canvas> listOfCanvas;

    public void OpenMenu(int i)
    {
        listOfCanvas[i].enabled = true;
        listOfCanvas[0].enabled = false;

    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            foreach (var canvases in listOfCanvas)
            {
                canvases.enabled = false;

            }
            listOfCanvas[0].enabled = true;
            
        }

        
    }
}
