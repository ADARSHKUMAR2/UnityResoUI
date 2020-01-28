using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class OpenMenus : MonoBehaviour
{
    public List<Canvas> listOfCanvas;
    public Contacts contacts;
    //public ContactsList ContactsList = new ContactsList();
    private string file = "ContactsFile.txt";

    private void Start()
    {

        //Debug.Log(Application.persistentDataPath);
    }

    public void SaveContact()
    {
        string json = JsonUtility.ToJson(contacts);
        WriteToFile(file, json);
    }

    public void LoadContacts()
    {
        contacts = new Contacts();
       
        
        string json = ReadFromFile(file);
        //TextAsset asset = Resources.Load("Contacts") as TextAsset;
        //JsonUtility.FromJsonOverwrite(json, contacts);

        //var data = PlayerPrefs.GetString("GameData");
        JsonUtility.FromJson<ContactsList>(json);
        //contacts = JsonUtility.FromJson<Contacts>(json);

        //TextAsset asset = (TextAsset)Resources.Load(json, typeof(TextAsset));
        //json = asset.text;

    }
    /*
    public static T LoadContacts<T>(string filename) whe
    {

        return default(Contacts);
    }
    */

    private void WriteToFile(string filename,string json)
    {
        string path = GetFilePath(filename);

        //string json1 = JsonUtility.ToJson(contacts);
        //PlayerPrefs.SetString("GameData", json1);
        //StreamWriter sw = File.CreateText(path);
        //sw.Close();
        //File.AppendAllText(path,json1);

        //if(!File.Exists(path)
        FileStream fileStream = new FileStream(path, FileMode.Create);
        //using (StreamWriter writer = File.AppendText(path))
        using (StreamWriter writer = new StreamWriter(fileStream))
        {
            writer.WriteLine(json);
        }
    }

    private string ReadFromFile(string filename)
    {
        string path = GetFilePath(filename);
        if (File.Exists(path))
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string json = reader.ReadToEnd();
                return json;
            }
        }
        
        else
            Debug.LogWarning("File Not Found");

        return "";
    }

    private string GetFilePath(string filename)
    {
        return Application.persistentDataPath + "/" + filename;
    }

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
        //LoadContacts();
        
    }
}
