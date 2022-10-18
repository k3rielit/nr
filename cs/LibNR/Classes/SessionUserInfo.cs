using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LibNR {

    public class SessionUserInfo {
        public static SessionUserInfo FromJson(string json) {
            SessionUserInfo info = new();
            try {
                info = JsonConvert.DeserializeObject<SessionUserInfo>(json,Converter.Settings) ?? new();
            }
            catch(Exception ex) {
                Console.WriteLine($"ERROR SessionUserInfo.FromJson(): {ex.Message}");
            }
            return info;
        }

        [JsonProperty("user")]
        public SessionUserInfo_User User { get; set; } = new();

        [JsonProperty("persona")]
        public SessionUserInfo_Persona Persona { get; set; } = new();

        [JsonProperty("others")]
        public List<SessionUserInfo_Persona> Others { get; set; } = new();

        [JsonProperty("persona_count")]
        public int PersonaCount { get; set; } = 0;

        [JsonProperty("crew")]
        public SessionUserInfo_Crew Crew { get; set; } = new();
    }

    public class SessionUserInfo_User {
        [JsonProperty("ID")]
        public long Id { get; set; } = 0;

        [JsonProperty("created")]
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.MinValue;

        [JsonProperty("EMAIL")]
        public string Email { get; set; } = string.Empty;

        [JsonProperty("isAdmin")]
        [JsonConverter(typeof(IntToBoolConverter))]
        public bool IsAdmin { get; set; } = false;

        [JsonProperty("isLocked")]
        [JsonConverter(typeof(IntToBoolConverter))]
        public bool IsLocked { get; set; }

        [JsonProperty("lastLogin")]
        public DateTimeOffset LastLogin { get; set; } = DateTimeOffset.MinValue;

        [JsonProperty("premium")]
        [JsonConverter(typeof(IntToBoolConverter))]
        public bool IsPremium { get; set; } = false;

        [JsonProperty("selectedPersonaIndex")]
        public int SelectedPersonaIndex { get; set; } = 0;

        [JsonProperty("isYoutuber")]
        [JsonConverter(typeof(IntToBoolConverter))]
        public bool IsYoutuber { get; set; } = false;

        [JsonProperty("isDeveloper")]
        [JsonConverter(typeof(IntToBoolConverter))]
        public bool IsDeveloper { get; set; } = false;

        [JsonProperty("discord")]
        public long Discord { get; set; } = 0;

        [JsonProperty("discord_name")]
        public string DiscordName { get; set; } = string.Empty;

        [JsonProperty("crew_persona")]
        public int CrewPersona { get; set; } = 0;

        [JsonProperty("DiscordID")]
        public long DiscordId { get; set; } = 0;

        [JsonProperty("nicknameColor")]
        public string NicknameColor { get; set; } = string.Empty;

        [JsonProperty("maxCarSlots")]
        public int MaxCarSlots { get; set; } = 0;

        [JsonProperty("state")]
        public string State { get; set; } = string.Empty;
    }

    public class SessionUserInfo_Persona {
        [JsonProperty("ID")]
        public int Id { get; set; } = 0;

        [JsonProperty("boost")]
        public int SpeedBoost { get; set; } = 0;

        [JsonProperty("cash")]
        public int Cash { get; set; } = 0;

        [JsonProperty("created")]
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.MinValue;

        [JsonProperty("curCarIndex")]
        public int CurrentCarIndex { get; set; } = 0;

        [JsonProperty("first_login")]
        public DateTimeOffset FirstLoginAt { get; set; } = DateTimeOffset.MinValue;

        [JsonProperty("iconIndex")]
        public int IconIndex { get; set; } = 0;

        [JsonProperty("last_login")]
        public DateTimeOffset LastLoginAt { get; set; } = DateTimeOffset.MinValue;

        [JsonProperty("level")]
        public int Level { get; set; } = 0;

        [JsonProperty("motto")]
        public string Motto { get; set; } = string.Empty;

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("percentToLevel")]
        public int PercentToLevel { get; set; } = 0;

        [JsonProperty("rating")]
        public int Rating { get; set; } = 0;

        [JsonProperty("rep")]
        public int Rep { get; set; } = 0;

        [JsonProperty("repAtCurrentLevel")]
        public int RepAtCurrentLevel { get; set; } = 0;

        [JsonProperty("score")]
        public int Score { get; set; } = 0;

        [JsonProperty("USERID")]
        public int UserId { get; set; } = 0;

        [JsonProperty("prestige")]
        public int Prestige { get; set; } = 0;

        [JsonProperty("deletedAt")]
        public DateTimeOffset DeletedAt { get; set; } = DateTimeOffset.MinValue;

        [JsonProperty("lastNickChange")]
        public DateTimeOffset LastNickChangeAt { get; set; } = DateTimeOffset.MinValue;
    }

    public class SessionUserInfo_Crew {
        [JsonProperty("current")]
        public SessionUserInfo_Current Current { get; set; } = new();

        [JsonProperty("have")]
        public bool Have { get; set; } = false;

        [JsonProperty("can_join")]
        public bool CanJoin { get; set; } = false;
    }

    public class SessionUserInfo_Current {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("ownerUserId")]
        public int OwnerUserId { get; set; }

        [JsonProperty("date_join")]
        public DateTimeOffset JoinedAt { get; set; } = DateTimeOffset.MinValue;

        [JsonProperty("canManage")]
        [JsonConverter(typeof(IntToBoolConverter))]
        public bool CanManage { get; set; } = false;

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("tag")]
        public string Tag { get; set; } = string.Empty;
    }
}
