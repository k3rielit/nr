namespace LibNR.RawClasses {
    public class rSessionUserInfo {
        public rSessionUser user { get; set; } = new();
        public rSessionPersona persona { get; set; } = new();
        public List<rSessionPersona> others { get; set; } = new();
        public string persona_count { get; set; } = string.Empty;
    }

    // Classes used by rSessionUserInfo
    public class rSessionUser {
        public string ID { get; set; } = string.Empty;
        public string created { get; set; } = string.Empty;
        public string EMAIL { get; set; } = string.Empty;
        public string isAdmin { get; set; } = string.Empty;
        public string isLocked { get; set; } = string.Empty;
        public string lastLogin { get; set; } = string.Empty;
        public string premium { get; set; } = string.Empty;
        public string selectedPersonaIndex { get; set; } = string.Empty;
        public string isYoutuber { get; set; } = string.Empty;
        public string isDeveloper { get; set; } = string.Empty;
        public string discord { get; set; } = string.Empty;
        public string discord_name { get; set; } = string.Empty;
        public string crew_persona { get; set; } = string.Empty;
        public string DiscordID { get; set; } = string.Empty;
        public string nicknameColor { get; set; } = string.Empty;
        public string maxCarSlots { get; set; } = string.Empty;
        public string state { get; set; } = string.Empty;
    }
    public class rSessionPersona {
        public string ID { get; set; } = string.Empty;
        public string boost { get; set; } = string.Empty;
        public string cash { get; set; } = string.Empty;
        public string created { get; set; } = string.Empty;
        public string curCarIndex { get; set; } = string.Empty;
        public string first_login { get; set; } = string.Empty;
        public string iconIndex { get; set; } = string.Empty;
        public string lst_login { get; set; } = string.Empty;
        public string level { get; set; } = string.Empty;
        public string motto { get; set; } = string.Empty;
        public string name { get; set; } = string.Empty;
        public string percentToLevel { get; set; } = string.Empty;
        public string rating { get; set; } = string.Empty;
        public string rep { get; set; } = string.Empty;
        public string repAtCurrentLevel { get; set; } = string.Empty;
        public string score { get; set; } = string.Empty;
        public string USERID { get; set; } = string.Empty;
        public string prestige { get; set; } = string.Empty;
        public string deleted_at { get; set; } = string.Empty;
        public string lastNickChange { get; set; } = string.Empty;
    }
    public class rSessionCrew {
        public string have { get; set; } = string.Empty;
        public string can_join { get; set; } = string.Empty;
        public rSessionCrewCurrent? current { get; set; } = new();
    }
    public class rSessionCrewCurrent {
        public string ID { get; set; } = string.Empty;
        public string ownerUserId { get; set; } = string.Empty;
        public string date_join { get; set; } = string.Empty;
        public string canManage { get; set; } = string.Empty;
        public string name { get; set; } = string.Empty;
        public string tag { get; set; } = string.Empty;
    }
}
