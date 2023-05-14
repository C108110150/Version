using server;
using System;






TEST1 ABC = new TEST1();
ABC.B = "hi";
ABC.sayhi();

TEST1 BBC = new TEST1(); //類別
BBC.B = "FUCK";
BBC.sayhi();
string IP = "192.168.4.1";
int PORT = int.Parse("11999");
var message = new
{
    cmd = "SettingSSID",
    cmd_seq = DateTime.Now.ToString(),
    ssid = "302",
    password = "00302302"
};

BBC.SendMessage(message,IP,PORT);

TEST999 ppt = new TEST999(); //繼承
ppt.B = "去洗碗";
ppt.sayhi();