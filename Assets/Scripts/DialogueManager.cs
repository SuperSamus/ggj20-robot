using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	public Text nameText;
	public Text dialogueText;

	public Animator animator;

	private Queue<(string, string)> sentences;

	// Use this for initialization
	void Start () {
		sentences = new Queue<(string, string)>();
	}

	public void StartDialogue (Dialogue dialogue)
	{
		animator.SetBool("IsOpen", true);

		sentences.Clear();

		for (int i = 0; i < dialogue.sentences.Length; ++i)
		{
			sentences.Enqueue((dialogue.names[i], dialogue.sentences[i]));
		}

		DisplayNextSentence();
	}

	public void DisplayNextSentence ()
	{
		Debug.Log("Displaying next sentence");
		if (sentences.Count == 0)
		{
			EndDialogue();
			return;
		}

		(string name, string sentence) = sentences.Dequeue();
		StopAllCoroutines();
		nameText.text = name;
		StartCoroutine(TypeSentence(sentence));
	}

	IEnumerator TypeSentence (string sentence)
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			yield return null;
		}
		yield return new WaitForSeconds(3f);
		DisplayNextSentence();
	}

	void EndDialogue()
	{
		animator.SetBool("IsOpen", false);
	}

}
