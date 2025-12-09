using System;
using System.Collections.Generic;

namespace App4.Views
{
    public static class ScoreData
    {
        public static List<Client> clientlist { get; set; } = new List<Client>();

    }


    public class Portfolio
    {
        public string proID { get; set; }
        public string status { get; set; }
        public string type { get; set; }
        public string feecode { get; set; }
        public int inival { get; set; }
        public string currency { get; set; }
        public int clientid { get; set; }
    }

    public class Scoreboard
    {
        public string Client { get; set; }
        public string Security { get; set; }
        public string KYC { get; set; }
    }

    public class Client
    {
        public int UserID { get; set; }
        public int clientID { get; set; }
        public string Fname { get; set; }
        public string LName { get; set; }
        public string DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public string Domicile { get; set; }
        public string Language { get; set; }
        public string sector { get; set; }
        public string Status { get; set; }
        public string BankService { get; set; }
        public string Currency { get; set; }
        public int Score { get; set; }
        public string IM { get; set; }


    }


    public class TradingActivities
    {
        public int TID { get; set; }
        public string securityCode { get; set; }
        public string TDate { get; set; }
        public string TType { get; set; }
        public int TAmount { get; set; }
        public string PortfolioID { get; set; }
    }

    public class TradingActivitiesRed
    {
        public int TID { get; set; }
        public string securityCode { get; set; }
        public string TDate { get; set; }
        public string TType { get; set; }
        public int TAmount { get; set; }
        public string PortfolioID { get; set; }
    }

    public class Security
    {
        public int securityID { get; set; }
        public string securityCode { get; set; }
        public string description { get; set; }
        public string currency { get; set; }
        public int price { get; set; }
        public string priceDate { get; set; }
    }
    public class SecurityRed
    {
        public int securityID { get; set; }
        public string securityCode { get; set; }
        public string description { get; set; }
        public string currency { get; set; }
        public int price { get; set; }
        public string priceDate { get; set; }
    }

    public class Log
    {
        public string table { get; set; }
        public string ID { get; set; }
        public string column { get; set; }
        public string type { get; set; }
        public string oldvalue { get; set; }
        public string newvalue { get; set; }
        public string time { get; set; }
        public string text { get; set; }

        public string img { get; set; }

        public int Score { get; set; }


    }

    public class kyc
    {
        public string GDA { get; set; }
        public string PEP { get; set; }
        public string SOW { get; set; }
        public DateTime DOB { get; set; }
        public string Address { get; set; }
        public string Fname { get; set; }
        public string Sname { get; set; }
        public string MAddress { get; set; }

        public string ANum { get; set; }
        public int ID { get; set; }
        public string CK { get; set; }
        public string PM { get; set; }

        public int score { get; set;}



    }
}
