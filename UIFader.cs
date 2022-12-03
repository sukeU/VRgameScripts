using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIFader : MonoBehaviour
{
    List<Image> images = new List<Image>();
    List<TextMeshProUGUI> textMeshes = new List<TextMeshProUGUI>();
    List<Renderer> materials = new List<Renderer>();
    float alpha=1f;
    Coroutine coroutine;
    Vector3 defaultPosition;
    private void Start()
    {
        defaultPosition = transform.position;
        RecursiveSetActive(this.gameObject);
        Invisible();
    }

    public void AppearUI()
    {
       coroutine= StartCoroutine(FadeOut());
        SoundManager.Instance.PlaySeByName("Result_display2", gameObject);
    }
    public void DisappearUI()
    {
        transform.position = defaultPosition;
        Invisible();
        if(coroutine!=null)
        StopCoroutine(coroutine);
    }

    private void RecursiveSetActive(GameObject a_CheckObject)
    {
        // �ΏۃI�u�W�F�N�g�̎q�I�u�W�F�N�g���`�F�b�N����
        foreach (Transform child in a_CheckObject.transform)
        {
            GameObject childObject = child.gameObject;
            if (childObject.GetComponent<Image>() != null)
            {
                images.Add(childObject.GetComponent<Image>());
            }else if(childObject.GetComponent<TextMeshProUGUI>() != null)
            {
                textMeshes.Add(childObject.GetComponent<TextMeshProUGUI>());
            }
            else if (childObject.GetComponent<Renderer>() != null)
            {
                materials.Add(childObject.GetComponent<Renderer>());
            }

            // �ċA�I�ɑS�Ă̎q�I�u�W�F�N�g����������
            RecursiveSetActive(childObject);
        }
    }
    private void Invisible()
    {
        alpha = 0f;
        foreach (var image in images)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
        }
        foreach (var textMesh in textMeshes)
        {
            textMesh.alpha = alpha;
        }
        foreach (var material in materials)
        {
            material.material.color = new Color(material.material.color.r, material.material.color.g, material.material.color.b, alpha);
        }
    }
    IEnumerator FadeIn()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.025f);
            alpha -= 0.02f;
            foreach(var image in images)
            {
                image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
            }
            foreach (var textMesh in textMeshes)
            {
                textMesh.alpha = alpha;
            }
             foreach(var material in materials)
            {
                material.material.color = new Color(material.material.color.r, material.material.color.g, material.material.color.b, alpha);
            }
            
            if (alpha <= 0f) // �s�����x��0�ȉ��̂Ƃ�
            {
                alpha = 0f;
                break; // �J��Ԃ��I��
            }
        }
    }
    IEnumerator FadeOut()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.025f); 
            alpha += 0.02f;
            transform.Translate(0, alpha*0.05f,0);
            foreach (var image in images)
            {
                image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
            }
            foreach (var textMesh in textMeshes)
            {
                textMesh.alpha = alpha;
            }
            foreach (var material in materials)
            {
                material.material.color = new Color(material.material.color.r, material.material.color.g, material.material.color.b, alpha);
            }
            if (alpha >= 1f) // �s�����x��0�ȉ��̂Ƃ�
            {
                alpha = 1f;
                break; // �J��Ԃ��I��
            }
        }
    }
}
