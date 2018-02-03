using System.Data.SQLite;
using System.Net;

namespace qBitTelNotice
{
    class Program
    {
        // BOT Token 읽어와 등록하기
        private static readonly string botid = System.IO.File.ReadAllText(@"BOT_Token.txt");

        // Chat Id 읽어와 등록하기
        private static readonly string chatid = System.IO.File.ReadAllText(@"Chat_Id.txt");

        // SQLite 경로 설정
        private static readonly string path_sqlite = "./db.sqlite";

        // SQLiteConnection 선언 및 초기화
        private static SQLiteConnection conn = null;

        static int Main(string[] args)
        {
            // 인수가 0개라면 종료
            if (args.Length <= 0)
                return 0;

            // db.sqlite 체크
            System.IO.FileInfo sqlite_chk = new System.IO.FileInfo(path_sqlite);
            if (!sqlite_chk.Exists)
                SQLiteConnection.CreateFile(path_sqlite); // db.sqlite 생성

            // db.sqlite 연결
            conn = new SQLiteConnection("Data Source=" + path_sqlite + ";Version=3;");
            conn.Open();
            SQLiteCommand cmd = new SQLiteCommand("", conn);

            // qBittorrent 테이블 생성
            cmd.CommandText = "create table if not exists qBittorrent (name varchar(200))";
            cmd.ExecuteNonQuery();

            // qBittorrent 테이블 안에 중복 값 체크
            cmd.CommandText = "select * from qBittorrent";
            SQLiteDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                // 중복시 종료
                if (rdr["name"].ToString() == args[0])
                    return 0;
            }

            rdr.Close();

            // qBittorrent 테이블 name 값 추가
            cmd.CommandText = "insert into qBittorrent (name) values ('" + args[0] + "')";
            cmd.ExecuteNonQuery();

            conn.Close();

            string url = "https://api.telegram.org/bot" + botid + "/sendMessage?chat_id=" + chatid + "&text=" + System.Web.HttpUtility.UrlEncode(args[0]);

            WebRequest request = WebRequest.Create(url);
            ((HttpWebRequest)request).UserAgent = "qBitTelNotice Client";
            request.Method = "POST";
            request.GetResponse();

            return 0;
        }
    }
}
