using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Exam.QuestionForms;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace Exam
{
    internal class Repository : RepoDisposable
    {
        string conStr;
        string DbPath;
        public bool IsFinded = false; // Flaga czy znalezione rekordy.
        public Repository(string dbPath)
        {
            DbPath = dbPath;
            conStr = "Data Source=" + dbPath;
        }
        internal bool CreateDB()
        {
            try
            {
                if (String.IsNullOrEmpty(DbPath))
                    return false;
                SQLiteConnection.CreateFile(DbPath);
                string sql = "CREATE TABLE [Questions] (" +
                        "  [ID] INTEGER NOT NULL " +
                        ", [Question] text NULL " +
                        ", [Type] bigint NULL " +
                        ", [A] text NULL " +
                        ", [B] text NULL " +
                        ", [C] text NULL " +
                        ", [D] text NULL " +
                        ", [E] text NULL " +
                        ", [F] text NULL " +
                        ", [G] text NULL " +
                        ", [H] text NULL " +
                        ", [HH] text NULL " +
                        ", [I] text NULL " +
                        ", [J] text NULL " +
                        ", [K] text NULL " +
                        ", [QType] bigint NULL " +
                        ", [ImageText] text NULL " +
                        ", [ImageTextAlt] text NULL " + // nowe pole
                        ", CONSTRAINT[sqlite_master_PK_Questions] PRIMARY KEY([ID]));";

                using (SQLiteConnection con = new SQLiteConnection(conStr))
                {
                    SQLiteCommand cmd = new SQLiteCommand(sql, con);
                    try
                    {
                        con.Open();
                        if (con.State == System.Data.ConnectionState.Open)
                        {
                            cmd.ExecuteNonQuery();
                            return true;
                        }
                    }
                    catch
                    {
                        System.Windows.Forms.MessageBox.Show("Problemik - nie udało się utworzyć bazy pytań");
                        con.Close();
                        return false;
                    }
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        internal bool AlterDB(string columnName)
        {
            try
            {
                if (String.IsNullOrEmpty(DbPath))
                    return false;
                string sql = "ALTER TABLE Questions ADD COLUMN "+ columnName+ " text NULL;";
                using (SQLiteConnection con = new SQLiteConnection(conStr))
                {
                    SQLiteCommand cmd = new SQLiteCommand(sql, con);
                    try
                    {
                        con.Open();
                        if (con.State == System.Data.ConnectionState.Open)
                        {
                            cmd.ExecuteNonQuery();                          
                            return true;
                        }
                    }
                    catch (Exception exc)
                    {
                        con.Close();
                        return false;
                    }
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        internal bool UpdateNewColumns()
        {
            string sql = "Update [Questions] SET ImageTextAlt = ImageText";
            using (SQLiteConnection con = new SQLiteConnection(conStr))
            {
                SQLiteCommand cmd = new SQLiteCommand(sql, con);
                try
                {
                    con.Open();
                    if (con.State == System.Data.ConnectionState.Open)
                    {
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
                catch
                {                   
                    con.Close();
                    return false;
                }
                return false;
            }
        }
        internal bool NewDB()
        {
            string sql = "SELECT ImageTextAlt, HH, I, J, K FROM [Questions]";
            using (SQLiteConnection con = new SQLiteConnection(conStr))
            {
                SQLiteCommand cmd = new SQLiteCommand(sql, con);
                try
                {
                    con.Open();
                    if (con.State == System.Data.ConnectionState.Open)
                    {
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                            }
                        }
                    }
                }
                catch
                {
                    return false;
                }
            }
            return true;
        }
        internal List<DbQuestion> GetQuestions(bool isRandom, string[] toFind = null, bool? isExam = null, int? questions = null)
        { 
            string where = "";
            if (toFind != null)
            {
                for (int i = 0; i < toFind.Length; i++)
                {
                    toFind[i] = toFind[i].ReplaceSymbolToApostrophe();             
                    if (i == 0)
                        where += " WHERE Question Like '%" + toFind[i] + "%' ";
                    else
                        where += "AND Question Like '%" + toFind[i] + "%' ";
                }
            }
            List<DbQuestion> list = new List<DbQuestion>();
            string sql = "SELECT * FROM [Questions]" + where;
            using (SQLiteConnection con = new SQLiteConnection(conStr))
            {
                SQLiteCommand cmd = new SQLiteCommand(sql, con);
                try
                {
                    con.Open();
                    if (con.State == System.Data.ConnectionState.Open)
                    {
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(new DbQuestion
                                {
                                    ID = Convert.ToInt16(reader["ID"]),
                                    Type = Convert.ToInt16(reader["Type"]),
                                    question = reader["Question"].ToString(),
                                    A = reader["A"].ToString().ReplaceApostropheToSymbol(),
                                    B = reader["B"].ToString().ReplaceApostropheToSymbol(),
                                    C = reader["C"].ToString().ReplaceApostropheToSymbol(),
                                    D = reader["D"].ToString().ReplaceApostropheToSymbol(),
                                    E = reader["E"].ToString().ReplaceApostropheToSymbol(),
                                    F = reader["F"].ToString().ReplaceApostropheToSymbol(),
                                    G = reader["G"].ToString().ReplaceApostropheToSymbol(),
                                    H = reader["H"].ToString().ReplaceApostropheToSymbol(),
                                    HH = reader["HH"].ToString().ReplaceApostropheToSymbol(),
                                    I = reader["I"].ToString().ReplaceApostropheToSymbol(),
                                    J = reader["J"].ToString().ReplaceApostropheToSymbol(),
                                    K = reader["K"].ToString().ReplaceApostropheToSymbol(),
                                    QType = Convert.ToInt16(reader["QType"]),                                    
                                    ImageText = reader["ImageText"].ToString(),                                   
                                    ImageTextAlt = reader["ImageTextAlt"].ToString()
                                });
                            }
                        }
                    }
                    if (isExam == true)
                    {
                        foreach (var item in list)
                        {
                            item.ImageTextAlt = null;
                            item.ImageAlt = null;
                        }
                    }
                    else if (isExam == false)
                    {
                        foreach (var item in list)
                        {
                            item.ImageText = null;
                            item.Image = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("Problemik w bazie lub z bazą... " + ex);
                    con.Close();
                    list = new List<DbQuestion>();
                }
            }
            if (list.Count > 0 && toFind != null) // Szukane cosie istnieją! :)
                IsFinded = true;
            else
                IsFinded = false;
            if (!isRandom)
                return list;
            else
            {
                List<DbQuestion> randomList = new List<DbQuestion>();
                Random rand = new Random();
                if (list.Count >= questions)
                {
                    for (int i = 0; i < questions; i++)
                    {
                        int index = rand.Next(list.Count - 1);
                        randomList.Add(list[index]);
                        list.RemoveAt(index);
                    }
                    return randomList;
                }
                else
                    return list;
            }

        }
        internal Image[] loadImages(short id)
        {
            Image[] images = new Image[2];       
            string sql = "SELECT ImageText, ImageTextAlt FROM [Questions] where ID = " + id;
            using (SQLiteConnection con = new SQLiteConnection(conStr))
            {
                SQLiteCommand cmd = new SQLiteCommand(sql, con);
                try
                {
                    con.Open();
                    if (con.State == System.Data.ConnectionState.Open)
                    {
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (!String.IsNullOrEmpty(reader["ImageText"].ToString()))
                                    images[0] = StringToImage(reader["ImageText"].ToString());
                                if (!String.IsNullOrEmpty(reader["ImageTextAlt"].ToString()))
                                    images[1] = StringToImage(reader["ImageTextAlt"].ToString());
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("Problemik w bazie lub z bazą... " + ex);
                    con.Close();
                }
            }
            return images;
        }
        internal DbQuestion GetQuestion(short id, bool? withImages = null)
        {
            DbQuestion question = new DbQuestion();
            string sql = "SELECT * FROM [Questions] where ID = " + id;
            using (SQLiteConnection con = new SQLiteConnection(conStr))
            {
                SQLiteCommand cmd = new SQLiteCommand(sql, con);
                try
                {
                    con.Open();
                    if (con.State == System.Data.ConnectionState.Open)
                    {
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                question.ID = Convert.ToInt16(reader["ID"]);
                                question.Type = Convert.ToInt16(reader["Type"]);
                                question.question = reader["Question"].ToString();
                                question.A = reader["A"].ToString().ReplaceApostropheToSymbol();
                                question.B = reader["B"].ToString().ReplaceApostropheToSymbol();
                                question.C = reader["C"].ToString().ReplaceApostropheToSymbol();
                                question.D = reader["D"].ToString().ReplaceApostropheToSymbol();
                                question.E = reader["E"].ToString().ReplaceApostropheToSymbol();
                                question.F = reader["F"].ToString().ReplaceApostropheToSymbol();
                                question.G = reader["G"].ToString().ReplaceApostropheToSymbol();
                                question.H = reader["H"].ToString().ReplaceApostropheToSymbol();
                                question.HH = reader["HH"].ToString().ReplaceApostropheToSymbol();
                                question.I = reader["J"].ToString().ReplaceApostropheToSymbol();
                                question.J = reader["J"].ToString().ReplaceApostropheToSymbol();
                                question.K = reader["K"].ToString().ReplaceApostropheToSymbol();
                                question.QType = Convert.ToInt16(reader["QType"]);
                                if (withImages==true)
                                {                                    
                                   question.ImageText = reader["ImageText"].ToString();                                    
                                   question.ImageTextAlt = reader["ImageTextAlt"].ToString();
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("Problemik w bazie lub z bazą... " + ex);
                    con.Close();
                }
            }
            return question;
        }
        internal List<short> GetIds()
        {
            List<short> l = new List<short>();
            string sql = "SELECT ID FROM [Questions]; ";
            using (SQLiteConnection con = new SQLiteConnection(conStr))
            {
                SQLiteCommand cmd = new SQLiteCommand(sql, con);
                try
                {
                    con.Open();
                    if (con.State == System.Data.ConnectionState.Open)
                    {
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                l.Add(Convert.ToInt16(reader["ID"]));                               
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("Problemik w bazie lub z bazą... " + ex);
                    con.Close();
                }
            }
            return l;
        }
        internal bool Add(DbQuestion question)
        {
            if (question.Image != null)
                question.ImageText = ImageToString(question.Image);
            if (question.ImageAlt != null)
                question.ImageTextAlt = ImageToString(question.ImageAlt);
            string sql = "Insert into [Questions] (Question, Type, A, B, C, D, E, F, G, H, HH, I, J, K, QType, ImageText, ImageTextAlt) Values ( " +
                "'" + question.question + "'" + " , " +
                question.Type + " , " +
                "'" + question.A.ReplaceSymbolToApostrophe() + "'" + " , " +
                "'" + question.B.ReplaceSymbolToApostrophe() + "'" + " , " +
                "'" + question.C.ReplaceSymbolToApostrophe() + "'" + " , " +
                "'" + question.D.ReplaceSymbolToApostrophe() + "'" + " , " +
                "'" + question.E.ReplaceSymbolToApostrophe() + "'" + " , " +
                "'" + question.F.ReplaceSymbolToApostrophe() + "'" + " , " +
                "'" + question.G.ReplaceSymbolToApostrophe() + "'" + " , " +
                "'" + question.H.ReplaceSymbolToApostrophe() + "'" + " , " +
                "'" + question.HH.ReplaceSymbolToApostrophe() + "'" + " , " +
                "'" + question.I.ReplaceSymbolToApostrophe() + "'" + " , " +
                "'" + question.J.ReplaceSymbolToApostrophe() + "'" + " , " +
                "'" + question.K.ReplaceSymbolToApostrophe() + "'" + " , " +
                question.QType + " , " +
                "'" + question.ImageText + "'" + " , " +
                "'" + question.ImageTextAlt + "'" +
                " )";
            using (SQLiteConnection con = new SQLiteConnection(conStr))
            {
                SQLiteCommand cmd = new SQLiteCommand(sql, con);
                try
                {
                    con.Open();
                    if (con.State == System.Data.ConnectionState.Open)
                    {
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show("Problemik w bazie - nie udało się dodać\n" + e);
                    con.Close();
                    return false;
                }
                return false;
            }
        }
        internal bool Update(DbQuestion question)
        {
            if (question.Image != null)
                question.ImageText = ImageToString(question.Image);
            if (question.ImageAlt != null)
                question.ImageTextAlt = ImageToString(question.ImageAlt);
            string sql = "Update [Questions] SET "
                + "Question = '" + question.question + "', "
                + "Type = " + question.Type + ", "
                + "QType = " + question.QType + ", "
                + "A = '" + question.A.ReplaceSymbolToApostrophe() + "', "
                + "B = '" + question.B.ReplaceSymbolToApostrophe() + "', "
                + "C = '" + question.C.ReplaceSymbolToApostrophe() + "', "
                + "D = '" + question.D.ReplaceSymbolToApostrophe() + "', "
                + "E = '" + question.E.ReplaceSymbolToApostrophe() + "', "
                + "F = '" + question.F.ReplaceSymbolToApostrophe() + "', "
                + "G = '" + question.G.ReplaceSymbolToApostrophe() + "', "
                + "HH = '" + question.HH.ReplaceSymbolToApostrophe() + "', "
                + "I = '" + question.I.ReplaceSymbolToApostrophe() + "', "
                + "J = '" + question.J.ReplaceSymbolToApostrophe() + "', "
                + "K = '" + question.K.ReplaceSymbolToApostrophe() + "', "
                + "ImageText = '" + question.ImageText + "', "
                + "ImageTextAlt = '" + question.ImageTextAlt + "', "
                + "H = '" + question.H.ReplaceSymbolToApostrophe() + "'"
                + " WHERE ID = " + question.ID;
            using (SQLiteConnection con = new SQLiteConnection(conStr))
            {
                SQLiteCommand cmd = new SQLiteCommand(sql, con);
                try
                {
                    con.Open();
                    if (con.State == System.Data.ConnectionState.Open)
                    {
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
                catch
                {
                    System.Windows.Forms.MessageBox.Show("Problemik w bazie - nie udało się dodać");
                    con.Close();
                    return false;
                }
                return false;
            }
        }
        internal bool Delete(long id)
        {
            string sql = "Delete from [Questions] "
                + " WHERE ID = " + id;
            using (SQLiteConnection con = new SQLiteConnection(conStr))
            {
                SQLiteCommand cmd = new SQLiteCommand(sql, con);
                try
                {
                    con.Open();
                    if (con.State == System.Data.ConnectionState.Open)
                    {
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
                catch
                {
                    System.Windows.Forms.MessageBox.Show("Problemik w bazie - nie udało się usunąć");
                    con.Close();
                    return false;
                }
                return false;
            }
        }
        internal bool Delete(List<long> ids, bool deleteIds)
        {
            string sql;
            if (deleteIds)
            {
                sql = "Delete from [Questions] "
                    + " WHERE ID = " + ids[0];
                if (ids.Count > 1)
                    for (int i = 1; i < ids.Count; i++)
                    {
                        sql += " OR ID = " + ids[i];
                    }
            }
            else
            {
                sql = "Delete from [Questions] "
                   + " WHERE ID <> " + ids[0];
                if (ids.Count > 1)
                    for (int i = 1; i < ids.Count; i++)
                    {
                        sql += " AND ID <> " + ids[i];
                    }
            }
            using (SQLiteConnection con = new SQLiteConnection(conStr))
            {
                SQLiteCommand cmd = new SQLiteCommand(sql, con);
                try
                {
                    con.Open();
                    if (con.State == System.Data.ConnectionState.Open)
                    {
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
                catch
                {
                    System.Windows.Forms.MessageBox.Show("Problemik w bazie - nie udało się usunąć");
                    con.Close();
                    return false;
                }
                return false;
            }
        }

        internal string ImageToString(Image image)
        {
            byte[] byteArray = new byte[0];
            using (MemoryStream stream = new MemoryStream())
            {
                try
                {
                    image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                catch
                {
                    image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                }
                stream.Close();
                byteArray = stream.ToArray();
            }
            string base64String = Convert.ToBase64String(byteArray);
            return base64String;
        }
        internal Image StringToImage(string base64String)
        {
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }
        internal bool CheckDB()
        {          
            if (!NewDB())
            {
                DialogResult dialog = MessageBox.Show("Baza danych nie jest dostosowana do aktualnej wersji programu, czy chcesz teraz zaktualizować strukturę bazy?", "Uwaga!", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    try
                    {
                        string message = "Nie udało sie zaktualizować bazy!!!";
                        if (AlterDB("HH") && AlterDB("I") && AlterDB("J") && AlterDB("K"))
                        {
                            message = "OK";                            
                        }
                        if (AlterDB("ImageTextAlt") && UpdateNewColumns())
                        {
                            MessageBox.Show(message);
                            return true;
                        }
                        else
                        {
                            MessageBox.Show(message);
                            return false;
                        }
                    }
                    catch
                    {
                        return false;
                    }
                }
                else
                    return false;
            }           
            return true;
        }
    }
}
