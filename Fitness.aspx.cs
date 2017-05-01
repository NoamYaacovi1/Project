using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.IO; // מחלקת המאפשרת קריאה וכתיבה לקובץ אקסאםאל

public partial class Fitness : System.Web.UI.Page
{
    public string comments = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.Form["submit"] != null)
        {

            insertComment(Request.Form["writer"], Request.Form["content"]);
        }
        string XMLFile = Server.MapPath("Comments.xml");
        XmlDocument document = new XmlDocument();
        document.Load(XMLFile); // טוענת את המסמך של התגובות לכאן
        XmlNodeList writer = document.GetElementsByTagName("writer"); // מביא את הרשימה של כל המשתמשים שכתבו תגובות
        XmlNodeList content = document.GetElementsByTagName("content"); // מביא את הרשימה של כל תכני התגובות

        comments = "<h2> תגובות לכתבה זו </h2>";
        int count = content.Count; // סופר את מספר התגובות
        for (int i = 0; i < count; i++)
        {
            comments += "<p>";
            comments += "The writer:" + writer[i].InnerText + "<br/>";
            comments += "The comment:" + content[i].InnerText + "<br/>" + "</p>"; // ,שומר את כל התגובות שהאנשים רשמו, אחכ נדפיס את זה בהטמל       
        }


    }
    public string insertValid = "";
    void insertComment(string writer, string content) // הכנסת תגובות
    {
        XmlElement commentEle, userEle, contentEle;
        XmlDocument doc = new XmlDocument();
        string XMLfile = Server.MapPath("Comments.xml");
        doc.Load(XMLfile);
        //יצירת הרכיבים
        userEle = doc.CreateElement("writer"); // יוצר את הרכיב של הכותב, את התגית
        contentEle = doc.CreateElement("content");
        commentEle = doc.CreateElement("comment");

        userEle.InnerText = writer; // מכניס את השם שהכניסו, לתוך התגית/רכיב רייטר
       
        contentEle.InnerText = content; // אותו דבר על התגובה

        //הכנסת הרכיבים כבנים לרכיב
        commentEle.AppendChild(userEle); // הופך את הכותב ל"ילד" של תגובה - תגית הכותב תהייה בתוך תגית התגובה
        commentEle.AppendChild(contentEle);
     
        doc.DocumentElement.InsertBefore(commentEle, doc.DocumentElement.FirstChild); // מכניס את התגובה  
        // סגירת העדכון בקובץ והפיכתו לשמיש בעתיד
        FileStream fsxml = new FileStream(XMLfile, FileMode.Truncate, FileAccess.Write, FileShare.ReadWrite);
        doc.Save(fsxml);
        fsxml.Close();
        
    }

}