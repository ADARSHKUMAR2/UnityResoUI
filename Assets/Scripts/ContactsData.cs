using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContactsData : MonoBehaviour
{
    public InputField contactName;
    public OpenMenus openMenus;
    public Text ContactPersonName;
    // Start is called before the first frame update
    
    void Start()
    {
        openMenus.LoadContacts();   
        contactName.text = openMenus.contacts.name;
        ContactPersonName.text = openMenus.contacts.name.ToString();
    }
    
    public void ClickToEnter()
    {
        ContactPersonName.text = openMenus.name.ToString();
    }

    public void ChangeName(string text)
    {
        openMenus.name = text ;
    }
    
    public void ClickToSave()
    {
        //ContactPersonName.text = openMenus.contacts.number.ToString();
        openMenus.SaveContact();
     
    }
    
}
