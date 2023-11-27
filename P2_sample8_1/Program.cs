using Microsoft.Data.SqlClient;

// パラメータ用文字列の入力
Console.Write("修正したいIDを入力してください＞");
int id = int.Parse(Console.ReadLine()!);
Console.Write("新しい役職名を入力してください＞");
string newPosition = Console.ReadLine()!;

// 接続文字列の設定
string connectionString = @"";

// データベースへの接続準備
using (SqlConnection conn = new SqlConnection())
{
    conn.ConnectionString = connectionString;

    // コマンドの準備
    string query = "UPDATE M_Position SET PositionName = @pos WHERE PositionID = @id;";
    using (SqlCommand cmd = new SqlCommand())
    {
        cmd.Connection = conn;
        cmd.CommandText = query;

        // データベース処理は失敗する可能性があるので、例外処理の準備
        try
        {
            // データベースへの接続
            conn.Open();

            // パラメータの設定
            cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@pos", System.Data.SqlDbType.NVarChar).Value = newPosition;

            // コマンドの実行
            int recordCount = cmd.ExecuteNonQuery();
            if (recordCount >= 1)
            {
                Console.WriteLine("更新は成功しました！");
            }
            else
            {
                Console.WriteLine("更新に失敗しました。");
            }
        }
        catch
        {
            // 例外が出た場合の処理
            Console.WriteLine("エラーが発生しました。");
        }
    }
}
