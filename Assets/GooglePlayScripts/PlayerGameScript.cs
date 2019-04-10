using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class PlayerGameScript : MonoBehaviour
{
    [SerializeField]
    public UnityEngine.UI.Text texta;

    public static UnityEngine.UI.Text textb;

    void Start()
    {
        textb = texta;
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
            var dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {
                // Create and hold a reference to your FirebaseApp,
                // where app is a Firebase.FirebaseApp property of your application class.
                //   app = Firebase.FirebaseApp.DefaultInstance;

                // Set a flag here to indicate whether Firebase is ready to use by your app.
            }
            else
            {
                UnityEngine.Debug.LogError(System.String.Format(
                  "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                // Firebase Unity SDK is not safe to use here.
            }
        });
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();

        SignIn();
    }

    void SignIn()
    {
        if (!Social.localUser.authenticated)
        {
            Social.localUser.Authenticate(success =>
            {
                texta.text = success.ToString();

                if (!success)
                {
                    SignIn();
                }
            });
        }
    }

    #region LeaderBoards

    public static void AddScoreToLeaderboard(string leaderboardId, long score)
    {
        Social.ReportScore(score, leaderboardId, success => { textb.text = success.ToString(); });
    }

    public static void ShowLeaderboardsUI()
    {
        Social.ShowLeaderboardUI();
    }

    #endregion
}
