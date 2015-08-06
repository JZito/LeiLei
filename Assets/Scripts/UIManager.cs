using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

//	public GameObject gameplayScreen;
//	public GameObject selectionScreen;
	public bool spanish;
	public bool aboutPage;
	public bool selectionScreen;
	public GameObject aboutButton;
	public GameObject aboutPanelSpanish;
	public GameObject aboutPanelEnglish;
	private int languageTicker = 0;
	public GameObject language;
	public Sprite englishButtonSprite;
	public Sprite spanishButtonSprite;
	public Sprite englishAboutSprite;
	public Sprite spanishAboutSprite;
	public Sprite backButton;
	public GameObject javiWebButton;
	public GameObject javiBackButton;
	public GameObject vowelSelectionScreen;
	public string javiUrl;

	// Use this for initialization

	void Awake () {
		language = GameObject.Find ("Language");
		languageTicker = PlayerPrefs.GetInt ("Spanish");
		if (languageTicker == 0) {
			if (selectionScreen){
				language.GetComponent<Image>().sprite = spanishButtonSprite;
				aboutButton.GetComponent<SpriteRenderer>().sprite = spanishAboutSprite;
			}
			spanish = true;
		} 
		else if (languageTicker == 1) {
			if (selectionScreen) {
				language.GetComponent<Image>().sprite = englishButtonSprite;
				aboutButton.GetComponent<SpriteRenderer>().sprite = englishAboutSprite;
			}
			spanish = false;
		}
	}
	void Start () {

		//GameObject aboutPanel = GameObject.FindGameObjectWithTag ("AboutPanel");
	}
	
	// Update is called once per frame
	void Update () {

	
	}

	public void SwitchToAboutPage () {
		aboutPage = true;
		javiWebButton.SetActive (false);
		vowelSelectionScreen.SetActive (false);
		javiBackButton.SetActive (true);
		if (spanish) {
			aboutPanelSpanish.gameObject.SetActive(true);	
		}
		else if (!spanish) {
			aboutPanelEnglish.gameObject.SetActive(true);
		}
	}

	public void BackToSelection() {
		Application.LoadLevel ("selection");
	}

	public void JaviSite() {
		if (aboutPage) {
			aboutPanelSpanish.gameObject.SetActive(false);	
			aboutPanelEnglish.gameObject.SetActive(false);
			javiWebButton.SetActive (true);
			javiBackButton.SetActive (false);
			vowelSelectionScreen.SetActive (true);

			aboutPage = false;
		} 
		else if (!aboutPage) {
			Application.OpenURL (javiUrl);
		}
	}

	public void LoadSite() {
		Application.OpenURL (javiUrl);
	}

	public void AboutPageOnOff() {
		if (!spanish) {
			if (!aboutPanelEnglish.activeSelf && !aboutPanelSpanish.activeSelf) {
				aboutPanelEnglish.gameObject.SetActive (true);		
			} 
			else if (aboutPanelEnglish.activeSelf || aboutPanelSpanish.activeSelf) {
				aboutPanelSpanish.gameObject.SetActive(false);
				aboutPanelEnglish.gameObject.SetActive(false);	
			}
		}
		else if (spanish){
			if (!aboutPanelSpanish.activeSelf && !aboutPanelEnglish.activeSelf) {
				aboutPanelSpanish.gameObject.SetActive (true);		
			} 
			else if (aboutPanelSpanish.activeSelf || aboutPanelEnglish.activeSelf) {
				aboutPanelSpanish.gameObject.SetActive(false);	
				aboutPanelEnglish.gameObject.SetActive(false);
			}
		}
	}

	public void LanguageButton () {
		if (languageTicker == 0){
			PlayerPrefs.SetInt("Spanish", 1);
			languageTicker = 1;
			language.GetComponent<Image>().sprite = englishButtonSprite;
			aboutButton.GetComponent<SpriteRenderer>().sprite = englishAboutSprite;
			spanish = false;
		}
		else if (languageTicker == 1) {
			PlayerPrefs.SetInt("Spanish", 0);
			languageTicker = 0;
			language.GetComponent<Image>().sprite = spanishButtonSprite;
			aboutButton.GetComponent<SpriteRenderer>().sprite = spanishAboutSprite;

			spanish = true;
		}
		if (aboutPanelSpanish.activeSelf || aboutPanelEnglish.activeSelf) {
			if (!spanish) {
				aboutPanelSpanish.gameObject.SetActive(false);
				aboutPanelEnglish.gameObject.SetActive (true);	
			}	
			else if (spanish) {
				aboutPanelSpanish.gameObject.SetActive (true);
				aboutPanelEnglish.gameObject.SetActive(false);
			}
		}
	}
}
