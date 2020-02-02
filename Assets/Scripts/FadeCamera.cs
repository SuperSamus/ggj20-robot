using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class FadeCamera : MonoBehaviour
{
    public AnimationCurve FadeCurve;
    private float _alpha = 1;
    private Texture2D _texture;
    private bool _exit = false;
    private float _time;


    public void Reset()

    {
        _alpha = 1;
        _time = 0;
    }

    [RuntimeInitializeOnLoadMethod]
    public void RedoFade()
    {
        Reset();
    }

    public void OnGUI()
    {
        if (_texture == null) _texture = new Texture2D(1, 1);
        if (!_exit) {
            _texture.SetPixel(0, 0, new Color(0, 0, 0, _alpha));
        }
        else {
            _texture.SetPixel(0, 0, new Color(1, 1, 1, _alpha));
        }
        _texture.Apply();

        _time += Time.deltaTime * (_exit ? -1 : 1);
        _alpha = FadeCurve.Evaluate(_time);
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), _texture);

        _time = Mathf.Clamp(_time, 0f, 4f);
    }

    public void end() {
        _exit = true;
        StartCoroutine(close());
    }

    IEnumerator close() {
        yield return new WaitForSeconds(6);
        SceneManager.LoadScene("StartMenu");
    }
}

