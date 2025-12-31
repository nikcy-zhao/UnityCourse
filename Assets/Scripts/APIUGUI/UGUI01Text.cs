
using UnityEngine;
using TMPro;

public class UGUI01Text : MonoBehaviour
{
  public TextMeshProUGUI text;

  void Awake()
  {
    if (text == null)
    {
      text = GameObject.Find("MyText").GetComponent<TextMeshProUGUI>();
    }
  }

  void Start()
  {
    // UGUI默认开启富文本和转义字符支持，可以使用HTML标签设置颜色、字体，以及使用\n等转义字符
    text.text = "Hello  <color=red>World</color> \n I love you";

    // 参数化字符串 - 使用字符串插值（推荐）
    string world = "World";
    text.text = $"Hello {world}";

    //NOTE: 
    // 1. SetText方法，参数一般为string, StringBuilder, char[]等重载版本
    // 2. SetText不支持字符串插值语法
    // 3. SetText格式化字符串时，参数必须为值类型，不能为引用类型，否则会报错
    text.SetText("Hello {0}", 1);

    // NOTE: 如果想用 SetText 方法进行参数化字符串，可以使用 string.Format 进行格式化
    text.SetText(string.Format("Hello {0}", world));
  }
}
