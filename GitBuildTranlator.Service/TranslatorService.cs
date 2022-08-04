using Translator.Service.Interface;
using Newtonsoft.Json;
using System.Collections;

namespace Tranlator.Service;

public class TranslatorService : ITranslatorService
{
    public string Translate(string words, string languageTranslateTo)
    {

        var url = String.Format
     ("https://translate.googleapis.com/translate_a/single?client=gtx&sl={0}&tl={1}&dt=t&q={2}",
      "en", languageTranslateTo, Uri.EscapeUriString(words));
        HttpClient httpClient = new HttpClient();
        string result = httpClient.GetStringAsync(url).Result;
        var jsonData = JsonConvert.DeserializeObject<List<dynamic>>(result);

        //string translation = "";
        //foreach (object item in jsonData)
        //{
        //    // Convert the item array to IEnumerable
        //    IEnumerable translationLineObject = item as IEnumerable;
        //    if (translationLineObject == null) continue;
        //    // Convert the IEnumerable translationLineObject to a IEnumerator
        //    IEnumerator translationLineString = translationLineObject.GetEnumerator();

        //    // Get first object in IEnumerator
        //    translationLineString.MoveNext();

        //    // Save its value (translated text)
        //    translation += string.Format(" {0}", Convert.ToString(translationLineString.Current));
        //}

        List<char> charsToRemove = new List<char>() { '[', ']' };
        string cha = String.Concat(result.Split(charsToRemove.ToArray()));
        List<string> allFenchWord=new List<string>();
        // Get all json data
        int k = 0;
        int counterAdd = 1;
        for (int i = 0;i < cha.Split('\"').Length; i++)
        {
            if ((i == 1 || i == counterAdd) && (cha.Split('\"')[i].Contains("null") || cha.Split('\"')[i] != "en"))
            {
                counterAdd = counterAdd + 8;
                allFenchWord.Add(cha.Split('\"')[i].Trim());
            }
            k++;
        }


        var translation = string.Join(' ', allFenchWord); 

        return translation;
    }

    //public string Translate(string words, string languageTranslateTo)
    //{
    //    string[] allEngWords = words.Split(' ');
    //    string[] allFreWords = words.Split(' ');
    //    string cha;
    //    int i = 0;
    //    foreach (var word in allEngWords)
    //    {
    //        var url = String.Format
    //             ("https://translate.googleapis.com/translate_a/single?client=gtx&sl={0}&tl={1}&dt=t&q={2}",
    //              "en", languageTranslateTo, Uri.EscapeUriString(word));

    //        HttpClient httpClient = new HttpClient();
    //        string result = httpClient.GetStringAsync(url).Result;
    //        List<char> charsToRemove = new List<char>() { '\'', '[', ']', '{', '}' };
    //        cha = String.Concat(result.Split(charsToRemove.ToArray()));

    //        allFreWords[i] = cha.ToString().Split(',')[1].Replace("\"", "") != ""
    //            ? cha.ToString().Split(',')[0].Replace("\"", "")
    //            : cha.ToString().Split(',')[0].Replace("\"", "") + ",";
    //        i++;
    //    }

    //    string res = string.Join(" ", allFreWords);

    //    return res;

    //    //   var url = String.Format
    //    //("https://translate.googleapis.com/translate_a/single?client=gtx&sl={0}&tl={1}&dt=t&q={2}",
    //    // "en", languageTranslateTo, Uri.EscapeUriString(words));
    //    //   HttpClient httpClient = new HttpClient();
    //    //   string result = httpClient.GetStringAsync(url).Result;
    //    //   var jsonData = JsonConvert.DeserializeObject<List<dynamic>>(result);

    //    //   string translation = "";
    //    //   foreach (object item in jsonData)
    //    //   {
    //    //       // Convert the item array to IEnumerable
    //    //       IEnumerable translationLineObject = item as IEnumerable;
    //    //       if (translationLineObject == null) continue;
    //    //       // Convert the IEnumerable translationLineObject to a IEnumerator
    //    //       IEnumerator translationLineString = translationLineObject.GetEnumerator();

    //    //       // Get first object in IEnumerator
    //    //       translationLineString.MoveNext();

    //    //       // Save its value (translated text)
    //    //       translation += string.Format(" {0}", Convert.ToString(translationLineString.Current));
    //    //   }

    //    //   List<char> charsToRemove = new List<char>() { '@', '_', '\'', '[', ']' };
    //    //   string cha = String.Concat(result.Split(charsToRemove.ToArray()));
    //    //   // Get all json data



    //    //var translationItems = cha.Split(',')[0] != null ? cha.Split(',')[0] : "";

    //    //return translationItems.Replace("▓", ",");
    //}

}
