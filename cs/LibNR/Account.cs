using LibNR.Data;

namespace LibNR {
    public static class Account {
        public static AuthToken Token { get; private set; } = new AuthToken();
        public static bool LoggedIn { get; private set; } = false;
        public static void Login(AuthToken token) {
            if(token.easharpptr_u.Length > 0 && token.easharpptr_p.Length > 0) { // try getting SessionUserInfo with the token to test it
                LoggedIn = true;
                Token = token;
            }
        }
    }
}