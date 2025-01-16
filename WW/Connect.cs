using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WW
{
    public class Connect
    {
        static public string host = Properties.Settings.Default.host;
        static public string user = Properties.Settings.Default.user;
        static public string db = Properties.Settings.Default.db;
        static public string pwd = Properties.Settings.Default.pwd;
        static public string conStr = $@"host=127.0.0.1;uid=root;pwd=root;database=home001;";
        static public string conStr2 = $@"host={host};uid={user};pwd={pwd};";
        static public string name;
        static public string surname;
        static public string patronymic;
        static public string role;
    }
}
