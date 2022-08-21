using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuOpen : MonoBehaviour
{
    public GameObject menuPanel;
   
    public void OpenPanel()
    {       
        menuPanel.SetActive(!menuPanel.activeInHierarchy);
       
    }

}
