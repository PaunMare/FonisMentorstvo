using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.AccessControl;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class SetGame : MonoBehaviour
{
    AudioSource audioSource, audioRotate, audioDone; 
    public static int SCORE = 420;

    #region Fields

    [SerializeField]
    private Sprite backgroundImage; // FONIS slika kao poledjina karte

    public List<Sprite> cardImages = new List<Sprite>(); // sadrzi 18 slika potrebnih za igru. Slike dodeljene rucno preko editora

    public List<Button> buttons = new List<Button>();

    #endregion

    #region  Variables for checking match and counting game

    private bool firstGuess, secondGuess;

    private int guessCounter;
    private int correctGuessCounter;
    private int gameGuesses;

    private int firstGuessIndex, secondGuessIndex;
    private string firstGuesCard, secondGuessCard;


    #endregion

    public List<Sprite> Randomize(List<Sprite> objects) // izmesa listu slika da bi se onda random dodeljivale
    {
        for (int i = 0; i < objects.Count; i++)
        {
            Sprite obj = objects[i];
            int randomizeArray = Random.Range(0, i);
            objects[i] = objects[randomizeArray];
            objects[randomizeArray] = obj;
        }
        return objects;
    }
    private void Awake()
    {
        audioSource = GameObject.FindGameObjectWithTag("AudioScore").GetComponent<AudioSource>();
        audioRotate = GameObject.FindGameObjectWithTag("MenuSound").GetComponent<AudioSource>();
        audioDone = GameObject.FindGameObjectWithTag("SoundDone").GetComponent<AudioSource>();
    }

    void Start(){
        GetButtons(); 
        AddOnClick(); 
        cardImages = Randomize(cardImages);
        gameGuesses = cardImages.Count / 2;
        audioSource.mute = false;
    }

    void GetButtons(){ // uzmemo dugmice sa scene i dodamo ih u listu, kao i svakom dodamo pozadinu FONIS
        GameObject[] objects = GameObject.FindGameObjectsWithTag("MemoryCard");

        for(int i=0; i < objects.Length;i++){
            buttons.Add(objects[i].GetComponent<Button>());
            buttons[i].image.sprite = backgroundImage;
        }
    }


    void AddOnClick() { // dodeljujemo metodu dugmicima 
        for (int i = 0; i < buttons.Count; i++) {
            buttons[i].onClick.AddListener(() => ClickButton());
        }
    }

    IEnumerator ChangeImage(Button button,int imageIndex){
        yield return new WaitForSeconds(0.19f);
        button.image.sprite = cardImages[imageIndex];
    }
    string pom = "";
    void ClickButton(){ 
        string name = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;

        if(!firstGuess){
            if (audioRotate.enabled) audioRotate.Play();
            else audioRotate.enabled = true;
            firstGuess = true;
            firstGuessIndex = int.Parse(name);
            firstGuesCard = cardImages[firstGuessIndex].name;
            //buttons[firstGuessIndex].image.sprite = cardImages[firstGuessIndex];
            StartCoroutine(ChangeImage(buttons[firstGuessIndex], firstGuessIndex));
            pom = name;

        }else if(!secondGuess && !(name.Equals(pom))) {
            audioRotate.Play();
            secondGuess = true;
            secondGuessIndex = int.Parse(name);
            secondGuessCard = cardImages[secondGuessIndex].name;
            //buttons[secondGuessIndex].image.sprite = cardImages[secondGuessIndex];
            StartCoroutine(ChangeImage(buttons[secondGuessIndex], secondGuessIndex));
            guessCounter++;

            StartCoroutine(CheckMatch());
        }


    }

    IEnumerator CheckMatch(){ // proverava da li se poklapaju (yield i interactable nzm sta su )
        yield return new WaitForSeconds(1f);

        if (firstGuesCard.Equals(secondGuessCard)){
            if (audioDone.enabled) audioDone.Play();
            else audioDone.enabled = true;
            yield return new WaitForSeconds(.5f);

            buttons[firstGuessIndex].image.color = new Color(0,0,0,0);
            buttons[secondGuessIndex].image.color = new Color(0, 0, 0, 0);

            buttons[firstGuessIndex].interactable = false;
            buttons[secondGuessIndex].interactable = false;

            GameFinished();
        } else {
            if (audioSource.enabled) audioSource.Play();
            else audioSource.enabled = true;

            yield return new WaitForSeconds(.4f);
            buttons[firstGuessIndex].image.sprite = backgroundImage;
            buttons[secondGuessIndex].image.sprite = backgroundImage;
        }

        yield return new WaitForSeconds(.1f);

        firstGuess = secondGuess = false;
    }

    GameObject scoreText; 

    void GameFinished(){ //proverava da li je kraj igre
        correctGuessCounter++;

        if (correctGuessCounter == gameGuesses){
            if (guessCounter < 13) SCORE = 420;
            else if (guessCounter < 14) SCORE -= 30;
            else if (guessCounter < 15) SCORE -= 60;
            else if (guessCounter < 16) SCORE -= 90;
            else if (guessCounter < 17) SCORE -= 120;
            else if (guessCounter < 18) SCORE -= 150;
            else if (guessCounter < 19) SCORE -= 180;
            else if (guessCounter < 20) SCORE -= 210;
            else SCORE -= 240;

            scoreText = GameObject.FindGameObjectWithTag("SadINIkad");

            string[] nameAndScore = scoreText.GetComponent<Text>().text.Split('$');

            int totalScore = int.Parse(nameAndScore[1]);

            totalScore += SCORE;

            scoreText.GetComponent<Text>().text = nameAndScore[0] + '$' + nameAndScore[1];
            UnityEngine.Debug.Log(totalScore.ToString()+" "+nameAndScore[0]);
            //SceneManager.LoadScene(4);
        }
    }
}
