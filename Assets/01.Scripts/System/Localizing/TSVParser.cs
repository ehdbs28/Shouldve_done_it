using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class TSVParser : MonoBehaviour
{
    [SerializeField] string tsvFolderPath = "";
    [SerializeField] string tsvFileName = "";

    [Space(10f)]
    [SerializeField] string jsonFolderPath = "";
    [SerializeField] string jsonFileName = "";

    [ContextMenu("TSV2JSON")]
    public void ParseTSV2JSON()
    {
        string projectPath = Application.dataPath.Replace("/Assets", "");
        string tsvRootFolderPath = Path.Combine(projectPath, tsvFolderPath);
        if(Directory.Exists(tsvRootFolderPath) == false)
        {
            Debug.LogWarning($"Directory Not Founded! : {tsvRootFolderPath}");
            return;
        }

        string tsvPath = Path.Combine(tsvRootFolderPath, tsvFileName);
        if(File.Exists(tsvPath) == false)
        {
            Debug.LogWarning($"File Not Founded! : {tsvPath}");
            return;
        }

        string json = TSV2JSON(tsvPath);
        string jsonRootFolderPath = Path.Combine(projectPath, jsonFolderPath);
        if(Directory.Exists(jsonRootFolderPath) == false)
            Directory.CreateDirectory(jsonRootFolderPath);

        string jsonPath = Path.Combine(jsonRootFolderPath, jsonFileName);
        File.WriteAllText(jsonPath, json);

        #if UNITY_EDITOR
        AssetDatabase.Refresh();
        #endif
    }

    private string TSV2JSON(string path)
    {
        var lines = File.ReadAllLines(path);

        // 첫 행을 읽어 키로 사용
        string[] headers = lines[0]
            .Split('\t')
            .Select(i => i.Trim())
            .ToArray();
            
        List<string> keys = headers
            .Where(i => i.StartsWith("//") == false)
            .ToList();

        var dataList = new List<Dictionary<string, string>>();

        // 각 데이터 행 처리
        for (int i = 1; i < lines.Length; i++)
        {
            var values = lines[i]
                .Split('\t')
                .Where((i, index) => headers[index].StartsWith("//") == false)
                .Select(i => i.Trim())
                .Select(i => i.Replace("\\n", "\n"))
                .ToArray();

            var data = new Dictionary<string, string>();

            for (int j = 0; j < values.Length; j++)
                data[keys[j]] = values[j];

            dataList.Add(data);
        }

        // JSON으로 변환
        return JsonConvert.SerializeObject(dataList, Formatting.Indented);
    }
}
