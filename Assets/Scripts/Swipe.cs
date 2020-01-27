using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Swipe : MonoBehaviour
{
    public GameObject scrollBar;
    float scroll_position = 0;
    float[] position;
    void Update()
    {
        position = new float[transform.childCount];
        //Debug.Log(position.Length);
        float distance = 1f / (position.Length - 1f);
        for (int i = 0; i < position.Length; i++)
        {
            position[i] = distance * i;
        }

        if(Input.GetMouseButton(0))
        {
            scroll_position = scrollBar.GetComponent<Scrollbar>().value;

        }
        
        else
        {
            for (int i = 0; i < position.Length; i++)
            {
                if(scroll_position<position[i]+(distance/2)&&scroll_position>position[i]-(distance/2))
                {
                    scrollBar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollBar.GetComponent<Scrollbar>().value, position[i], 0.2f);
                }
                
            }
        }

        //Debug.Log((float)System.Math.Round((double)scrollBar.GetComponent<Scrollbar>().value, 2));
    }

    public void Choice(int choice)
    {
        scroll_position = position[choice]; ;
    }

}
