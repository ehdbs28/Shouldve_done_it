using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;

public class GameDataManager : MonoSingleton<GameDataManager>
{
 
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    Dictionary<TABLE, GameData> _Tables = new Dictionary<TABLE, GameData>();

	public static bool ContainsTable(TABLE tableID)
    {
        return Instance._Tables.ContainsKey(tableID);
    }


    public static GameData GetTable(TABLE tableID)
    {
        if (Instance._Tables.ContainsKey(tableID) == false)
        {
            TextAsset assets = UnityEngine.Resources.Load<TextAsset>("Json/" + tableID.ToString());
            TABLE type = Instance.StringToEnum(assets.name);
            Instance._Tables[type] = (GameData)Instance.GetJsonData(type, assets.text);
        }

        if (Instance._Tables.ContainsKey(tableID) == false) return null;
        return Instance._Tables[tableID];
    }


    private TABLE StringToEnum(string e)
    {
        return (TABLE)System.Enum.Parse(typeof(TABLE), e);
    }
    private object GetJsonData(TABLE table,string data)
    {
        object obj = null;

        switch (table)
        {

case TABLE.TextTable:
        TextTable d_TextTable = new TextTable();
        d_TextTable.SetJson(data);
        obj  = d_TextTable;
        break;
        }

        return obj;
    }
    
    public void SetTable(TABLE tableId, GameData data)
    {
        _Tables[tableId] = data;
    }

	public static double GetNumber(TABLE tableId, string rowKey, string colKey)
    {
        var table = GetTable(tableId);

        return table.GetNumber(rowKey, colKey);
    }

    public static double GetNumber(TABLE tableId, int rowKey, string colKey)
    {
        var table = GetTable(tableId);

        return table.GetNumber(rowKey, colKey);
    }

    public static double Operation(string operation, double param1)
    {
        DataTable dt = new DataTable();
        var val = dt.Compute(string.Format(operation, param1), string.Empty);
        return double.Parse(val.ToString(), System.Globalization.CultureInfo.InvariantCulture);
    }

    public static double Operation(string operation, double param1, double param2)
    {
        DataTable dt = new DataTable();
        var val = dt.Compute(string.Format(operation, param1, param2), string.Empty);
        return double.Parse(val.ToString(), System.Globalization.CultureInfo.InvariantCulture);
    }

    public static double Operation(string operation, double param1, double param2, double param3)
    {
        DataTable dt = new DataTable();
        var val =  dt.Compute(string.Format(operation, param1, param2, param3), string.Empty);
        return double.Parse(val.ToString(), System.Globalization.CultureInfo.InvariantCulture); 
    }

    public static double Operation(string operation, double param1, double param2, double param3, double param4)
    {
        DataTable dt = new DataTable();
        var val = dt.Compute(string.Format(operation, param1, param2, param3,param4), string.Empty);
        return double.Parse(val.ToString(), System.Globalization.CultureInfo.InvariantCulture);
    }

    public static double Operation(string operation, double param1, double param2, double param3, double param4, double param5)
    {
        DataTable dt = new DataTable();
        var val = dt.Compute(string.Format(operation, param1, param2, param3, param4,param5), string.Empty);
        return double.Parse(val.ToString(), System.Globalization.CultureInfo.InvariantCulture);
    }

    public static double Operation(string operation, double param1, double param2, double param3, double param4, double param5, double param6)
    {
        DataTable dt = new DataTable();
        var val = dt.Compute(string.Format(operation, param1, param2, param3, param4, param5,param6), string.Empty);
        return double.Parse(val.ToString(), System.Globalization.CultureInfo.InvariantCulture);
    }
    public static double Operation(string operation, double param1, double param2, double param3, double param4, double param5, double param6, double param7)
    {
        DataTable dt = new DataTable();
        var val = dt.Compute(string.Format(operation, param1, param2, param3, param4, param5, param6, param7), string.Empty);
        return double.Parse(val.ToString(), System.Globalization.CultureInfo.InvariantCulture);
    }

    public static double Operation(string operation, double param1, double param2, double param3, double param4, double param5, double param6, double param7, double param8)
    {
        DataTable dt = new DataTable();
        var val = dt.Compute(string.Format(operation, param1, param2, param3, param4, param5, param6, param7,param8), string.Empty);
        return double.Parse(val.ToString(), System.Globalization.CultureInfo.InvariantCulture);
    }

    public static double Operation(string operation, double param1, double param2, double param3, double param4, double param5, double param6, double param7, double param8, double param9)
    {
        DataTable dt = new DataTable();
        var val = dt.Compute(string.Format(operation, param1, param2, param3, param4, param5, param6, param7, param8,param9), string.Empty);
        return double.Parse(val.ToString(), System.Globalization.CultureInfo.InvariantCulture);
    }

    public override void InitManager()
    {
        
    }
}

public abstract class GameData
{
    public abstract double GetNumber(string row, string col);
    public abstract double GetNumber(int row, string col);

}

public enum TABLE 
{
	Empty,
	TextTable,

}
