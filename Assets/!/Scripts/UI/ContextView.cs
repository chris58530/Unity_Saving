using UnityEngine;
using UnityEngine.UI;

namespace _.Scripts.UI
{
    public class ContextView : MonoBehaviour
    {
        public GameObject[] abilityValues;
        public Image HpImage;

        public void SetAbilityQuanity(GameObject[] values, int count)
        {
            for (int i = 0; i < values.Length; i++)
            {
                values[i].SetActive(false);
            }

            switch (count)
            {
                case 0:
                    return;
                case 1:
                    values[0].SetActive(true);
                    break;
                case 2:
                    values[0].SetActive(true);
                    values[1].SetActive(true);
                    break;
                case 3:
                    values[0].SetActive(true);
                    values[1].SetActive(true);
                    values[2].SetActive(true);
                    break;
                case 4:
                    values[0].SetActive(true);
                    values[1].SetActive(true);
                    values[2].SetActive(true);
                    values[3].SetActive(true);
                    break;
            }
        }
    }
}