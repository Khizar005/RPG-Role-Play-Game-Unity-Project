using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogController : MonoBehaviour
{
    public static DialogController instance;
    [SerializeField] TextMeshProUGUI dialogeText, nameText;
    [SerializeField] GameObject dialogBox, NameBox ;
    [SerializeField] public GameObject textToShowOnTrigger;

    [SerializeField] string[] dialogSentences;
    [SerializeField] int currentSentence;
    private bool dialogJustStarted;
    void Start()
    {
        
        instance = this;
        
        textToShowOnTrigger.SetActive(false);
        dialogeText.text = dialogSentences[currentSentence];
        
    }

    void Update()
    {
        if (dialogBox.activeInHierarchy && Input.GetButtonUp("Jump") )
        {
            if (!dialogJustStarted) 
            { 
                currentSentence++;
           
                if (currentSentence >= dialogSentences.Length)
                {
                    dialogBox.SetActive(false);
                    GameManager.instance.dialogBoxOpened = false;
                 }
                else
                {

                    SentenceStartWith();
                    dialogeText.text = dialogSentences[currentSentence];
                }
             }
            else
            {
                dialogJustStarted = false;
            }
        }
    }
    public void ActivateDialog(string[] newSentence)
    {
        dialogSentences = newSentence;
        currentSentence = 0;
        SentenceStartWith();
        dialogeText.text = dialogSentences[currentSentence];
        dialogBox.SetActive(true);
        dialogJustStarted = true;
       GameManager.instance.dialogBoxOpened = true;
    }
    void SentenceStartWith()
    {
        if (dialogSentences[currentSentence].StartsWith("#"))
        {
            nameText.text=dialogSentences[currentSentence].Replace("#" , "");
            currentSentence++;
            
        }
    }
    public bool IsDialogIsActive()
    {
        return dialogBox.activeInHierarchy;
    }

}
