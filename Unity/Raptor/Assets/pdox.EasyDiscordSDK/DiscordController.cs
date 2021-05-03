//* Morgan Finney
//* www.pdox.uk

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Discord;


namespace pdox.EasyDiscordSDK
{
    public class DiscordController : MonoBehaviour
    {
        [Header("Client ID")]
        [Tooltip("Client ID from application page")]
        public long clientID;

        [Header("DiscordSDK Refrances")]
        public Discord.Discord discordMain;
        public Discord.ActivityManager discordActivityManager;

        [Header("Default / Current Activity State")]
        [Tooltip("The Current DiscordActivity Details [First Line in Discord]")]
        [SerializeField] private string details;
        [Tooltip("The Current DiscordActivity State [Second Line in Discord]")]
        [SerializeField] private string state;
        [Tooltip("The Current DiscordActivity Large Image Name [AssetKeyName from your Rich Presence Art Assets]")]
        [SerializeField] private string largeImg;
        [Tooltip("The Current DiscordActivity Large Image Text [Text displayed when hovering over large icon]")]
        [SerializeField] private string largeImgText;
        [Tooltip("The Current DiscordActivity Small Image Name [AssetKeyName from your Rich Presence Art Assets]")]
        [SerializeField] private string smallImg;
        [Tooltip("The Current DiscordActivity Small Image Text [Text displayed when hovering over small icon]")]
        [SerializeField] private string smallImgText;
        [Tooltip("Time the game was started [In UNIX format, Set Automaticlly unless specified]")]
        [SerializeField] private int startTime;
        [Tooltip("Time the game will end [In UNIX format, 0 to disable]")]
        [SerializeField] private int endTime;

        [Header("EasyDiscordSDK Management")]
        [Tooltip("Enables the discord activity manager")]
        [SerializeField] private bool isEnabled = true;
        [Tooltip("Has Then Activity Changed Since Last UpdateActivity()")]
        [SerializeField] private bool isChanged = false;
        [Tooltip("Time Elapsed Since Last Activity Change")]
        [SerializeField] private float timeSinceLastChange = 0;

        private void Awake()
        {
            GameObject[] DiscordSDKs = GameObject.FindGameObjectsWithTag("EasyDiscordSDK");
            if (DiscordSDKs.Length > 1)
                Destroy(this.gameObject);
            DontDestroyOnLoad(this.gameObject);
        }

        void Start()
        {
            StartUp();
            if (isEnabled)
                UpdateActivity();
        }

        void Update()
        {
            timeSinceLastChange += Time.deltaTime;

            discordMain.RunCallbacks();

            if (isEnabled && isChanged && timeSinceLastChange > 15)
                UpdateActivity();
            else if (!isEnabled && isChanged && timeSinceLastChange > 15)
                ClearActivity();
                
        }

        int CurrentUnixTime()
        {
            DateTime unixStart = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return ((int)(DateTime.UtcNow - unixStart).TotalSeconds);
        }

        void StartUp()
        {
            startTime = CurrentUnixTime();

            //* Use Discord.CreateFlags.Default for debugging and use Discord.CreateFlags.NoRequireDiscord for release unless your game requires discord.
            discordMain = new Discord.Discord(clientID, (UInt64)Discord.CreateFlags.NoRequireDiscord);

            discordActivityManager = discordMain.GetActivityManager();
        }

        void ClearActivity()
        {
            discordActivityManager.ClearActivity((result) =>
            {
                if (result == Discord.Result.Ok)
                {
                    Debug.unityLogger.Log("Success!");

                }
                else
                {
                    Debug.unityLogger.Log("Failed");
                }
            });

            timeSinceLastChange = 0f;
        }

        void UpdateActivity()
        {
            var activity = new Discord.Activity
            {
                State = state,
                Details = details,
                Timestamps =
             {
                Start = startTime,
                End = endTime,
             },
                Assets =
            {
                LargeImage = largeImg,
                LargeText = largeImgText,
                SmallImage = smallImg,
                SmallText = smallImgText,
            },
            };
            discordActivityManager.UpdateActivity(activity, (res) =>
            {
                if (res == Discord.Result.Ok)
                {
                    Debug.unityLogger.Log("Everything is fine!");
                }
            });

            timeSinceLastChange = 0f;
            isChanged = false;
        }

        public void POSTState(string newState)
        {
            state = newState;

            isChanged = true;
        }

        public void POSTDetails(string newDetails)
        {
            details = newDetails;

            isChanged = true;
        }
    }
}