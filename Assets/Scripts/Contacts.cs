using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Contact 
{
    public string name;
    //public string number = "";
}

[System.Serializable]
public class Contacts
{
    //public Contacts[] listOfContacts;
    public List<Contact> contacts;
}