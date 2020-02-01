using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerer : MonoBehaviour
{
    public Dialogue dialogue;
    public void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            gameObject.SetActive(false);
        }
    }

}
