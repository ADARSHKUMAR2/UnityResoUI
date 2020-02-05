using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using Newtonsoft.Json;

public class OpenMenus : MonoBehaviour
{

    public List<Canvas> listOfCanvas;
    public ContactsData contacts;
    //public ContactsList ContactsList = new ContactsList();
    private string file = "ContactsFile.txt";
    public string value;

    private void Start()
    {

        //Debug.Log(Application.persistentDataPath);
    }

    public void SaveContact()
    {
        var setting = new JsonSerializerSettings();
        setting.Formatting = Formatting.Indented;
        setting.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

        //var contacts = new ContactsData();
        //var contacts = new List<ContactsData>();
        //string json = JsonUtility.ToJson(contacts);

        ContactsList contactsList = new ContactsList();
        //contactsList.Contacts.Add(new ContactsData("my name"));
        //contactsList.Contacts.Add(new ContactsData("my name 2"));
        //contactsList.Contacts.Add(new ContactsData("my name 3"));
        //contactsList.Contacts.Add(new ContactsData(name));

        string serializedContacts = JsonConvert.SerializeObject(contactsList);
        Debug.Log(serializedContacts);
        
        WriteToFile(file, serializedContacts);
        value = serializedContacts;
        //{
        //    name = name
        //};
        //File.WriteAllText(Application.persistentDataPath, json);
        //CRoot root = JsonUtility.ToJson<CRoot>(json);

    }

    public void LoadContacts()
    {
        //string json = ReadFromFile(file);
        //TextAsset asset = (TextAsset)Resources.Load(json, typeof(TextAsset));
        //JsonUtility.FromJson<ContactsList>(asset.text);
        contacts = new ContactsData();
        string json = ReadFromFile(file);
        JsonUtility.FromJsonOverwrite(json,contacts);
        //JsonUtility.FromJsonOverwrite(json, contacts);

        //var deserializedContacts = JsonConvert.DeserializeObject(value);
        //Debug.Log(deserializedContacts);

        //TextAsset asset = (TextAsset)Resources.Load(json, typeof(TextAsset));
        //
        //ContactsList = JsonUtility.FromJson<ContactsList>(json);


        //TextAsset asset = Resources.Load("Contacts") as TextAsset;
        //JsonUtility.FromJsonOverwrite(json, contacts);

        //var data = PlayerPrefs.GetString("GameData");

        //CRoot root = JsonUtility.FromJson<CRoot>(json);

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
        FileStream fileStream = new FileStream(path, FileMode.Append);
        //using (StreamWriter writer = File.AppendText(path))
        using (StreamWriter writer = new StreamWriter(fileStream))
        {
            writer.WriteLine(json);
            Debug.Log("File Created");
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
