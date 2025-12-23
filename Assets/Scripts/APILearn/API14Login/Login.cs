using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

/// <summary>
/// 登录界面控制（可在 Inspector 指派 UI 引用以避免运行时 Find）
/// </summary>
public class LoginUI : MonoBehaviour
{
  [Header("UI组件对象")]
  // 健康游戏忠告文本
  [SerializeField] private TextMeshProUGUI healthNotice;
  // 出版许可证文本
  [SerializeField] private TextMeshProUGUI publicationLicense;
  // 同意协议勾选框
  [SerializeField] private Toggle agreementToggle;
  // 同意协议旧版文本组件
  [SerializeField] private Text agreementLabelLegacy;
  // 登录按钮
  [SerializeField] private Button loginButton;
  // 加载进度条
  [SerializeField] private Slider slider;
  // 加载进度百分比文本
  [SerializeField] private TextMeshProUGUI progressText;

  [Header("设置")]
  [SerializeField] private string mainSceneName = "MainScene";
  [SerializeField] private float progressSmoothSpeed = 3f; // 越大越快

  [Header("确认面板组件")]
  // 确认面板（可在 Inspector 指派以避免运行时查找）
  [SerializeField] private RectTransform comfirmPanel;
  // 确认按钮
  [SerializeField] private Button comfirmButton;
  // 确认文本
  [SerializeField] private TextMeshProUGUI comfirmLabelTMP;

  void Awake()
  {
    // 如果没有在 Inspector 指派，则尝试按名称查找（向后兼容）
    if (healthNotice == null)
      healthNotice = FindComponentByName<TextMeshProUGUI>("HealthNotice");
    if (healthNotice != null)
    {
      Debug.Log("LoginUI: 健康游戏忠告组件已查找");
      healthNotice.text = "健康游戏忠告\n抵制不良游戏，拒绝盗版游戏，注意自我保护，谨防上当受骗\n适度游戏益脑，沉迷游戏伤身，合理安排时间，享受健康生活\n本公司积极履行《网格游戏行业防沉迷自律公约》";
    }
    else
    {
      Debug.LogWarning("LoginUI: 未找到健康游戏忠告组件，请检查 UI 层级结构");
    }

    if (publicationLicense == null)
      publicationLicense = FindComponentByName<TextMeshProUGUI>("PublicationLicense");
    if (publicationLicense != null)
    {
      Debug.Log("LoginUI: 出版许可证组件已查找");
      publicationLicense.text = "审批文号：国新出审[2025]2987号\t出版物号：ISBN978-7-478-08539-9\n著作权人：猪知遥网格科技有限公司\t出版单位：猪知遥网格科技有限公词";
    }
    else
    {
      Debug.LogWarning("LoginUI: 未找到出版许可证组件，请检查 UI 层级结构");
    }

    // 同意协议勾选框
    if (agreementToggle == null)
      agreementToggle = FindComponentByName<Toggle>("Agreement");

    // 查找同意协议文本
    if (agreementToggle != null)
    {
      var label = agreementToggle.transform.Find("Label");
      if (label != null)
      {
        agreementLabelLegacy = label.GetComponent<Text>();
      }
    }

    // 设置用户协议默认值
    if (agreementToggle != null)
      agreementToggle.isOn = false;
    SetAgreementLabel("已阅读并同意《用户协议》、《隐私政策》、《儿童隐私政策》");

    // 登录按钮
    if (loginButton == null)
      loginButton = FindComponentByName<Button>("LoginButton");

    // 加载进度条
    if (slider == null)
      slider = FindComponentByName<Slider>("LoginSlider");

    // 设置进度条默认值
    if (slider != null)
    {
      slider.minValue = 0f;
      slider.maxValue = 1f;
      slider.value = 0f;
      slider.gameObject.SetActive(false);
    }

    // 设置进度文本默认值
    if (progressText == null)
      progressText = FindComponentByName<TextMeshProUGUI>("ProgressText");
    if (progressText != null)
      progressText.gameObject.SetActive(false);

    // 查找确认面板，并默认隐藏
    if (comfirmPanel == null)
    {
      comfirmPanel = transform.Find("ConfirmPanel").GetComponent<RectTransform>();
      if (comfirmPanel != null)
      {
        // 默认隐藏
        comfirmPanel.gameObject.SetActive(false);

        // 在确认面板中查找文本组件
        InitializeConfirmPanelComponents();
      }
      else
      {
        Debug.LogWarning("LoginUI: 未找到确认面板 ConfirmPanel，请检查 UI 层级结构");
      }
    }

  }

  void Start()
  {
    // 登录按钮点击事件
    if (loginButton != null)
    {
      loginButton.onClick.AddListener(OnLoginButtonClicked);
      Debug.Log("LoginUI: 登录按钮监听器已添加");
    }
    else
    {
      Debug.LogWarning("LoginUI: 登录按钮为空，无法添加监听器");
    }
  }

  void OnLoginButtonClicked()
  {
    if (agreementToggle != null && agreementToggle.isOn)
    {
      // 禁用交互，防止重复点击
      if (loginButton != null)
        loginButton.interactable = false;
      if (agreementToggle != null)
        agreementToggle.interactable = false;

      // 点击登录后显示加载进度条
      ShowLoadingUI(true);
      // 开始加载场景
      StartCoroutine(LoadMainScene(mainSceneName));
    }
    else
    {
      // 显示确认面板
      ShowComfirmPanel(true);
    }
  }

  // 加载主场景，异步方式
  private IEnumerator LoadMainScene(string sceneName)
  {
    AsyncOperation op = SceneManager.LoadSceneAsync(sceneName);
    if (op == null)
      yield break;

    op.allowSceneActivation = false;

    // 确保 slider 初始值
    if (slider != null && slider.gameObject.activeSelf == false)
      slider.gameObject.SetActive(true);
    if (progressText != null && progressText.gameObject.activeSelf == false)
      progressText.gameObject.SetActive(true);

    float displayedProgress = (slider != null) ? slider.value : 0f;

    while (!op.isDone)
    {
      float target = Mathf.Clamp01(op.progress / 0.9f);

      // 平滑过渡显示值
      displayedProgress = Mathf.MoveTowards(displayedProgress, target, progressSmoothSpeed * Time.deltaTime);
      if (slider != null)
        slider.value = displayedProgress;
      if (progressText != null)
        progressText.text = ((int)(displayedProgress * 100f)).ToString() + "%";

      if (op.progress >= 0.9f)
      {
        // 完成并显示 100%
        if (slider != null) slider.value = 1f;
        if (progressText != null) progressText.text = "100%";
        // 确保用户看到 100%，短暂停顿
        yield return new WaitForSeconds(0.1f);
        op.allowSceneActivation = true;
      }

      yield return null;
    }
  }

  /// 初始化确认面板中的组件
  private void InitializeConfirmPanelComponents()
  {
    if (comfirmPanel == null) return;

    // 查找确认文本组件
    if (comfirmLabelTMP == null)
    {
      // 先在确认面板的直接子对象中查找
      comfirmLabelTMP = comfirmPanel.GetComponentInChildren<TextMeshProUGUI>();

      // 如果没找到，尝试按名称查找
      if (comfirmLabelTMP == null)
      {
        var confirmTextObj = comfirmPanel.Find("ConfirmationText");
        // 找到对象后获取组件
        if (confirmTextObj != null)
          comfirmLabelTMP = confirmTextObj.GetComponent<TextMeshProUGUI>();
      }

      if (comfirmLabelTMP != null)
      {
        comfirmLabelTMP.text = "请阅读并同意《用户协议》、《隐私政策》、《儿童隐私政策》";
      }
      else
      {
        Debug.LogWarning("LoginUI: 未找到确认文本组件，请检查 ConfirmPanel 中是否有 TMP_Text 组件");
      }
    }

    // 查找确认按钮
    if (comfirmButton == null)
    {
      // 先在确认面板的直接子对象中查找
      comfirmButton = comfirmPanel.GetComponentInChildren<Button>();

      // 如果没找到，尝试按名称查找
      if (comfirmButton == null)
      {
        var confirmButtonObj = comfirmPanel.Find("ConfirmButton");
        if (confirmButtonObj != null)
          comfirmButton = confirmButtonObj.GetComponent<Button>();
      }

      if (comfirmButton != null)
      {
        // 添加点击事件监听器
        comfirmButton.onClick.AddListener(OnComfirmButtonClicked);
      }
      else
      {
        Debug.LogWarning("LoginUI: 未找到确认按钮，请检查 ConfirmPanel 中是否有 Button 组件");
      }
    }
  }

  /// 显示/隐藏确认面板
  private void ShowComfirmPanel(bool show)
  {
    if (comfirmPanel != null)
    {
      comfirmPanel.gameObject.SetActive(show);

      if (show)
      {
        // 确保文本内容是最新的
        SetConfirmPanelText("请阅读并同意《用户协议》、《隐私政策》、《儿童隐私政策》");
        Debug.Log("LoginUI: 确认面板已显示");
      }
      else
      {
        Debug.Log("LoginUI: 确认面板已隐藏");
      }
    }
    else
    {
      Debug.LogWarning("LoginUI: 确认面板为空，无法显示/隐藏");
    }
  }

  void OnComfirmButtonClicked()
  {
    // 隐藏确认面板并选中协议
    if (comfirmPanel != null)
    {
      comfirmPanel.gameObject.SetActive(false);
    }

    if (agreementToggle != null)
    {
      agreementToggle.isOn = true;
    }
  }

  private void ShowLoadingUI(bool show)
  {
    if (slider != null)
      slider.gameObject.SetActive(show);
    if (progressText != null)
      progressText.gameObject.SetActive(show);
  }

  private void SetAgreementLabel(string text)
  {
    if (agreementLabelLegacy != null)
      agreementLabelLegacy.text = text;
  }

  /// 设置确认面板的文本内容
  private void SetConfirmPanelText(string text)
  {
    if (comfirmLabelTMP != null)
    {
      comfirmLabelTMP.text = text;
      Debug.Log($"LoginUI: 确认面板文本已设置为: {text}");
    }
    else
    {
      Debug.LogWarning("LoginUI: 确认面板文本组件为空，无法设置文本");
    }
  }

  // 按名称查找组件，T 必须是 Component 派生类
  private T FindComponentByName<T>(string name) where T : Component
  {
    var go = GameObject.Find(name);
    if (go == null) return null;
    return go.GetComponent<T>();
  }
}
