using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogHandler : MonoBehaviour
{

    [SerializeField] string[] sentences;
    public bool canActivateBox;
    void Start()
    {
    }

    void Update()
    {
        if (canActivateBox &&Input.GetButtonDown("Jump") && !DialogController.instance.IsDialogIsActive())
        {
            DialogController.instance.ActivateDialog(sentences);
            DialogController.instance.textToShowOnTrigger.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canActivateBox = true;
            DialogController.instance.textToShowOnTrigger.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            DialogController.instance.textToShowOnTrigger.SetActive(false);
            canActivateBox = false;
        }
    }
}
