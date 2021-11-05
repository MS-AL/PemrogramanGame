using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class UnityAdsButton : MonoBehaviour
{
    public Button btnAdd;
    public Button btnUse;
    public Text txCoin;

    int coin = 0;

    // durasi video 30 detik dan tidak dapat dilewati
    string placementId = "rewardedVideo";

    // video dapat dilewati setelah 5 detik
    // string placementId = "video";

 // Menggunakan Game ID berdasarkan Platform yang digunakan
#if UNITY_IOS
    private string gameId = "4437840";
#elif UNITY_ANDROID
    private string gameId = "4437841";
#endif

    void Start()
    {
        // menghandle button
        if (btnAdd) btnAdd.onClick.AddListener(ShowAd);
        if (btnUse) btnUse.onClick.AddListener(UseCoin);

        // inisialisasi Game ID ke Unity Ads
        if (Advertisement.isSupported)
        {
            Advertisement.Initialize(gameId, true);
        }
    }

    void Update()
    {
        // menentukan tombol dapat interakasi atau tidak
        if (btnAdd) btnAdd.interactable = Advertisement.IsReady(placementId);
        btnUse.interactable = (coin > 0);
    }

    void ShowAd()
    {
        // menampilkan iklan
        ShowOptions options = new ShowOptions();
        options.resultCallback = HandleShowResult;

        Advertisement.Show(placementId, options);
    }

    void HandleShowResult(ShowResult result)
    {
        // merespon feedback, jika berhasil maka coin akan ditambah 50
        if (result == ShowResult.Finished)
        {
            Debug.Log("Video selesai - tawarkan coin ke pemain");
            coin += 50;
            txCoin.text = "Coin: " + coin;
        }
        else if (result == ShowResult.Skipped)
        {
            Debug.LogWarning("Video dilewati - tidak menawarkan coin ke pemain");

        }
        else if (result == ShowResult.Failed)
        {
            Debug.LogError("Video tidak ditampilkan");
        }
    }

    void UseCoin() {
        // koin dikurangi
        if (coin > 0)
        {
            coin -= 10;
            txCoin.text = "Coin: " + coin;
        }
    }
}