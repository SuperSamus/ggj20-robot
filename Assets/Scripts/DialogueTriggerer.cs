using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerer : MonoBehaviour
{
    public string activatedByTag;
    public Dialogue dialogue;

    public void OnTriggerEnter(Collider other) {
        if (other.CompareTag(activatedByTag)) {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            gameObject.SetActive(false);
        }
    }

}
