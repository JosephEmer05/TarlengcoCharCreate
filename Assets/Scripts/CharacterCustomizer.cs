using UnityEngine;

public class CharacterCustomizer : MonoBehaviour
{
    [Header("Character Options")]
    public GameObject[] hairOptions;
    public GameObject[] topOptions;
    public GameObject[] bottomOptions;
    public GameObject[] shoeOptions;

    private void Awake()
    {
        Initialize();
    }

    public void Initialize()
    {
        SetActiveOption(hairOptions, 0);
        SetActiveOption(topOptions, 0);
        SetActiveOption(bottomOptions, 0);
        SetActiveOption(shoeOptions, 0);
    }

    public void SetHair(int index)
    {
        SetActiveOption(hairOptions, index);
    }

    public void SetTop(int index)
    {
        SetActiveOption(topOptions, index);
    }

    public void SetBottom(int index)
    {
        SetActiveOption(bottomOptions, index);
    }

    public void SetShoes(int index)
    {
        SetActiveOption(shoeOptions, index);
    }

    private void SetActiveOption(GameObject[] options, int activeIndex)
    {
        for (int i = 0; i < options.Length; i++)
        {
            if (options[i] != null)
            {
                options[i].SetActive(i == activeIndex);
            }
        }
    }
}
