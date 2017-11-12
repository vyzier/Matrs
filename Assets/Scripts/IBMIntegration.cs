using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class UnityWebRequestUsage : MonoBehaviour
{
    string user = "2e4e1e7a-3f55-4a56-b46a-1c902f00ed09-bluemix";
    string database = "test";

    string downloadText;

    public string GetTextFromDB()
    {
        StartCoroutine(GetText());
        return downloadText;
    }

    public void PutTextToDB(string text)
    {
        StartCoroutine(PutText(text));
    }

    IEnumerator GetText()
    {
        using (UnityWebRequest request = UnityWebRequest.Get("https://" + user + ".cloudant.com/" + database))
        {
            yield return request.Send();

            if (request.isError) // Error
            {
                downloadText = null;
                Debug.Log(request.error);
            }
            else // Success
            {
                downloadText = request.downloadHandler.text;
                Debug.Log(request.downloadHandler.text);
            }
        }
    }

    IEnumerator PutText(string text)
    {
        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(text);
        using (UnityWebRequest request = UnityWebRequest.Put("https://" + user + ".cloudant.com/" + database, bytes))
        {
            yield return request.Send();

            if (request.isError) // Error
            {
                Debug.Log(request.error);
            }
            else // Success
            {
                Debug.Log("Upload complete!");
            }
        }
    }
}