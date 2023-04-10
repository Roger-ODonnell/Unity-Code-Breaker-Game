using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class keypad : MonoBehaviour
{
    [SerializeField] TMP_Text codeViewer;
    [SerializeField] Image inputPanel;
    [SerializeField]int code;
    [SerializeField] AudioSource input_Sound, fail_Sound, success_Sound;
    string guess = "";
    string stringCode = "";

    private void Start()
    {
        GenerateCode();
    }

    private void GenerateCode()
    {
        stringCode = "";
        for (int i = 0; i < 4; i++)
        {
            stringCode += Random.Range(0, 9).ToString();
        }
        
        code = int.Parse(stringCode);
        Debug.Log("String code is: " + stringCode);
        if (stringCode.Length < 4){GenerateCode();}
    }

    public void EnterNumber(int number)
    {
        if (guess.Length == 4) { Debug.Log("max entry reached"); }
        else
        {
            guess = guess + number.ToString();
            codeViewer.text = guess;
            input_Sound.Play();
        }
    }

    public void GuessCode()
    {
        if (guess.Length < 4) { Debug.Log("Enter More Numbers"); }
        else if (guess.Length == 4)
        {
            var guessedCode = int.Parse(guess);
            if (guessedCode == code)
            {
                inputPanel.color = Color.green;
                codeViewer.text = "Correct!";
                success_Sound.Play();
                Invoke("Reset", 1f);
            }
            else if (guessedCode != code)
            {
                inputPanel.color = Color.red;
                codeViewer.text = "Wrong!";
                Invoke("clearCode", 1f);
                fail_Sound.Play();
            }
        }
    }

    public void clearCode()
    {
        guess = "";
        codeViewer.text = "";
        inputPanel.color = Color.grey;
    }

    public void Reset()
    {
        GenerateCode();
        guess = "";
        codeViewer.text = "";
        inputPanel.color = Color.grey;
    }
}
