using System.Collections.Generic;
using System;
using Newtonsoft.Json;


[Serializable]
public class TextTable  : GameData
{	
	 [JsonProperty] public TextTableProb[] Datas{get; private set;}
	 IReadOnlyDictionary<string, TextTableProb> _DicDatas;

	public void SetJson(string json)
    {
        var data = JsonConvert.DeserializeObject <TextTable> (json);
        TextTableProb[] arr = data.Datas;
        Datas = arr;

		var dic = new Dictionary<string, TextTableProb>();

        for (int i = 0; i < Datas.Length; ++i)
            dic[Datas[i].TextID.ToString()] = Datas[i];

        _DicDatas = dic;

    }

	public bool ContainsColumnKey(string name)
    {
        switch (name)
        {
				case "TextID": return true;
				case "Korean": return true;

		  default: return false;

        }
    }

	public override double GetNumber(int row, string col)
    {
        return double.Parse(this[row, col].ToString(), System.Globalization.CultureInfo.InvariantCulture);
    }

    public override double GetNumber(string row, string col)
    {
        return double.Parse(this[row, col].ToString(), System.Globalization.CultureInfo.InvariantCulture);
    }


	public object this[int row, string col]
    {
        get
        {
            TextTableProb data = this[row];
            switch (col)
            {
				case "TextID": return data.TextID;
				case "Korean": return data.Korean;


                default: return null;
            }
        }
    }


    public object this[string row, string col]
    {
        get
        {
             TextTableProb data = this[row];
            switch (col)
            {
				case "TextID": return data.TextID;
				case "Korean": return data.Korean;


                default: return null;
            }
        }
    }


	 public object this[int row, int col]
    {
        get
        {
            TextTableProb data = Datas[row];

            switch (col)
            {
				case 0: return data.TextID;
				case 1: return data.Korean;

                default: return null;
            }
        }
    }

    public TextTableProb this[string name]
    {
        get
        {
            return _DicDatas[name];
        }
    }


    public TextTableProb this[int index]
    {
        get
        {
            return Datas[index];
        }
    }

    public bool ContainsKey(string name)
    {
        return _DicDatas.ContainsKey(name);
    }



    public int Count
    {
        get
        {
            return Datas.Length;
        }
    }
}

[Serializable]
public class TextTableProb
{
		[JsonProperty] public readonly string TextID;
	[JsonProperty] public readonly string Korean;

}
