using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Selector : MonoBehaviour
{
    public GameObject[] characters;
    private Vector3 characterPosition;
    private Vector3 offscreenPosition;
    private int characterNumber;
    [SerializeField]
    private Text selectedText;
    [SerializeField]
    private Text unlockLevelText;

    [SerializeField]
    private Button characterSelectButton;
    [SerializeField]
    private Button levelButton;
    [SerializeField]
    private InputField levelField;
    [SerializeField]
    private GameObject lockButtonImage;
    private string inputFieldText;

    public List<Transform> Panels;
    public List<Sprite> Sprites;
    public List<int> LevelUnlocked;
    public List<Button> Tab_Buttons;

    private int a = 0;
    private void Start()
    {
        Tab_Buttons[0] = GetComponent<Button>();
        Tab_Buttons[1] = GetComponent<Button>();
    }
    private void Awake()
    {
        Tab_Buttons[0].image.sprite = Sprites[0];
        Tab_Buttons[1].image.sprite = Sprites[1];
        selectedText.enabled = true;
        characters[0].SetActive(true);
    }

    public void NextPosition()
    {
        a++;
        Debug.Log("Forward"+a);
        Debug.Log("Selected Char" + characterNumber);
        if (characterNumber != a)
        {
            selectedText.enabled = false;
            characterSelectButton.gameObject.SetActive(true);
        }
        if (characterNumber == a)
        {
            selectedText.enabled = true;
            characterSelectButton.gameObject.SetActive(false);
        }
        if (a > characters.Length - 1)
        {
            a = 0;
        }
        characters[a].SetActive(true);
        unlockLevelText.text ="Unlock: "+LevelUnlocked[a].ToString();
        
        for (int i = 0; i < characters.Length; i++)
        {
            if(i!=a)
            {
                characters[i].SetActive(false);
            }
        }

        if (LevelAt < LevelUnlocked[a])
        {
            characterSelectButton.interactable = false;
            lockButtonImage.SetActive(true);
        }
        else
        {
            characterSelectButton.interactable = true;
            lockButtonImage.SetActive(false);
        }
        
    }

    public void PreviousPosition()
    {
        a--;

        Debug.Log("Previous"+a);
        if (characterNumber!=a)
        {
            selectedText.enabled = false;
            characterSelectButton.gameObject.SetActive(true);
        }
        if (characterNumber == a)
        {
            selectedText.enabled = true;
            characterSelectButton.gameObject.SetActive(false);
        }
        if (a < 0)
        {
            a = characters.Length-1;
        }
        
        characters[a].SetActive(true);
        unlockLevelText.text = LevelUnlocked[a].ToString();
        
        for (int i = 0; i < characters.Length; i++)
        {
            if (i != a)
            {
                characters[i].SetActive(false);
            }
        }

        if (LevelAt < LevelUnlocked[a])
        {
            characterSelectButton.interactable = false;
            lockButtonImage.SetActive(true);
        }
        else
        {
            characterSelectButton.interactable = true;
            lockButtonImage.SetActive(false);
        }

    }

    public void CharacterSelectButton()
    {
        selectedText.enabled = true;
        characterSelectButton.gameObject.SetActive(false);
        characterNumber = a;
        Debug.Log("Selected Character number"+characterNumber);

    }

    public void PanelsSelect(int a)
    {
        for (int i = 0; i < Panels.Count; i++)
        {
            if (i != a)
            {
                Panels[i].gameObject.SetActive(false);
                //Tab_Buttons[i].image.sprite = Sprites[0];
            }
            else
            {
                Panels[a].gameObject.SetActive(true);
                //Tab_Buttons[a].image.sprite = Sprites[1];
            }
        }
    }

    public void OnSubmit()
    {
        inputFieldText = levelField.text;
        Panels[0].gameObject.SetActive(true);
        levelField.gameObject.SetActive(false);
        levelButton.gameObject.SetActive(false);
        
        int levelAt = PlayerPrefs.GetInt("levelAt",int.Parse(inputFieldText));
        LevelAt = levelAt;
    }

    public void Theme()
    {
        levelButton.gameObject.SetActive(true);
        levelField.gameObject.SetActive(true);
        Tab_Buttons[2].gameObject.SetActive(false);
    }

    public static int LevelAt { get; set; }
}

