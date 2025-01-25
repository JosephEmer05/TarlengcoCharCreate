using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("Hair Buttons")]
    public Button nextHairButton;
    public Button previousHairButton;

    [Header("Top Buttons")]
    public Button nextTopButton;
    public Button previousTopButton;

    [Header("Bottom Buttons")]
    public Button nextBottomButton;
    public Button previousBottomButton;

    [Header("Shoes Buttons")]
    public Button nextShoesButton;
    public Button previousShoesButton;

    public Button sceneSwitchButton;
    public string sceneName;

    public CharacterCustomizer characterCustomizer;

    private int currentHairIndex = 0;
    private int currentTopIndex = 0;
    private int currentBottomIndex = 0;
    private int currentShoesIndex = 0;

    private void Start()
    {
        // Initialize character defaults
        characterCustomizer.Initialize();

        // Assign button click listeners
        nextHairButton.onClick.AddListener(() => ChangeOption("hair", true));
        previousHairButton.onClick.AddListener(() => ChangeOption("hair", false));

        nextTopButton.onClick.AddListener(() => ChangeOption("top", true));
        previousTopButton.onClick.AddListener(() => ChangeOption("top", false));

        nextBottomButton.onClick.AddListener(() => ChangeOption("bottom", true));
        previousBottomButton.onClick.AddListener(() => ChangeOption("bottom", false));

        nextShoesButton.onClick.AddListener(() => ChangeOption("shoes", true));
        previousShoesButton.onClick.AddListener(() => ChangeOption("shoes", false));

        sceneSwitchButton.onClick.AddListener(SwitchScene);
    }

    private void SwitchScene()
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    public void ChangeOption(string category, bool isNext)
    {
        switch (category.ToLower())
        {
            case "hair":
                currentHairIndex = GetNextIndex(currentHairIndex, characterCustomizer.hairOptions.Length, isNext);
                characterCustomizer.SetHair(currentHairIndex);
                break;

            case "top":
                currentTopIndex = GetNextIndex(currentTopIndex, characterCustomizer.topOptions.Length, isNext);
                characterCustomizer.SetTop(currentTopIndex);
                break;

            case "bottom":
                currentBottomIndex = GetNextIndex(currentBottomIndex, characterCustomizer.bottomOptions.Length, isNext);
                characterCustomizer.SetBottom(currentBottomIndex);
                break;

            case "shoes":
                currentShoesIndex = GetNextIndex(currentShoesIndex, characterCustomizer.shoeOptions.Length, isNext);
                characterCustomizer.SetShoes(currentShoesIndex);
                break;

            default:
                Debug.LogWarning("Invalid category: " + category);
                break;
        }
    }

    private int GetNextIndex(int currentIndex, int arrayLength, bool isNext)
    {
        if (isNext)
        {
            return (currentIndex + 1) % arrayLength;
        }
        else
        {
            return (currentIndex - 1 + arrayLength) % arrayLength;
        }
    }
}
